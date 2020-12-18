using CRAG.DataAccess.Data.Repository.IRepository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Threading;

namespace CRAG.DataAccess.Data.Repository
{
    public class ADORepository<T, K> : IADOReepository<T, K> where T : class , new() 
    {

        private readonly string  _connection_string;
        private SqlConnection _connection = null;
        public ADORepository(string connection_string)
        {
            _connection_string = connection_string;
            _connection = new SqlConnection(connection_string);
        }

        private SqlConnection DBConnection
        {
            get
            {
                if  (_connection.State == ConnectionState.Connecting)
                {
                    while (_connection.State == ConnectionState.Connecting)
                        Thread.Sleep(1000);
                }
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                return _connection;
            }
        }

        public K Create(string procedure_name, List<SqlParameter> sql_parameters, params object[] params_values)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///    Updates the Entity 
        /// </summary>
        /// <param name="procedure_name">Procedure Name</param>
        /// <param name="sql_parameters">List of Sql Parameters </param>
        /// <param name="params_values"> Parametres List </param>
        /// <returns></returns>
        public int Update(string procedure_name, List<SqlParameter> sql_parameters, params object[] params_values)
        {
            Object result = GetValueFromSp<int>(procedure_name, sql_parameters, params_values);  //  Calls the SP
            return Convert.ToInt32(result);
        }


        public List<T> GetAll(string procedure_name, List<SqlParameter> sql_parameters, params object[] params_values)
        {
            return GetListFromStoredProcedure(procedure_name, sql_parameters, params_values);
        }



        public T GetById(string procedure_name, SqlParameter sql_parameter, K id)
        {
            T result = null;
            using (SqlCommand cmd = new SqlCommand(procedure_name, DBConnection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(sql_parameter);
                cmd.Parameters[procedure_name].Value = id;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if  (reader.Read())
                         result = MapValues<T>(reader);
                }
            }
            return result;
        }

        public int Delete(string procedure_name, SqlParameter sql_parameter, K id)
        {
            var delete_parameters = new List<SqlParameter>(); //  Creates the list of Parameteres 
            delete_parameters.Add(sql_parameter);             //  Inserts the delete parameter
            Object result = GetValueFromSp<int>(procedure_name, delete_parameters, id);  //  Calls the SP
            return Convert.ToInt32(result);                                             // returns teh Rows deleted 
        }


        #region SQL_Helpers
            private T MapValues<T>(SqlDataReader reader) where T : class, new()
            {
           
                T result = new T();
                // var columnShemas = ;

                foreach (var schema in reader.GetColumnSchema())
                {
                    var property_name = schema.ColumnName.Trim();
                    var type = result.GetType();
                    // Get the PropertyInfo object by passing the property name.
                    PropertyInfo myPropInfo = type.GetProperty(property_name);
                    if (myPropInfo != null)
                        // Fill  the property.
                        myPropInfo.SetValue(result, reader[property_name], null);
                }
                return result;
            }

            public Object GetValueFromSp<T>(string procedure_name, List<SqlParameter> sql_parameters, params object[] params_values)
            {
                Object result;


                    using (SqlCommand cmd = new SqlCommand(procedure_name, DBConnection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        //  Fills  All Sp Parameters
                        if (sql_parameters != null && sql_parameters.Count > 0 && sql_parameters.Count == params_values.Length)
                        {
                            int pos = 0;
                            foreach (SqlParameter parameter in sql_parameters)
                            {

                                cmd.Parameters.Add(parameter);
                                cmd.Parameters[parameter.ParameterName].Value = params_values[pos];
                                pos++;
                            }
                        }
                        result = cmd.ExecuteScalar();
                    }

                return result;
            }

            private List<T> GetListFromStoredProcedure(string procedure_name, List<SqlParameter> sql_parameters, object[] params_values)
            {
                List<T> result_list = new List<T>();
                using (SqlCommand cmd = new SqlCommand(procedure_name, DBConnection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //  Fills  All Sp Parameters
                    if (sql_parameters != null && sql_parameters.Count > 0 && sql_parameters.Count == params_values.Length)
                    {
                        int pos = 0;
                        foreach (SqlParameter parameter in sql_parameters)
                        {
                            cmd.Parameters.Add(parameter);
                            cmd.Parameters[parameter.ParameterName].Value = params_values[pos];
                            pos++;
                        }
                    }
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //   var a = reader.GetColumnSchema();
                            var r = MapValues<T>(reader);
                            result_list.Add(r);
                        }
                    }
                }
                return result_list;
            }

        #endregion


    }
}
