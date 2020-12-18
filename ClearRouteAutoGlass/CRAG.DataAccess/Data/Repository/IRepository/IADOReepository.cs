using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRAG.DataAccess
{ 
    public interface  IADOReepository<T, K> where T : new()
    {
        /// <summary>
        ///   Generic Create - Returns the inserted Key ( K )
        /// </summary>
        /// <param name="procedure_name">Procedure Name [Table]</param>
        /// <param name="sql_parameters"></param>
        /// <param name="params_values"></param>
        /// <returns></returns>
        public K Create(string procedure_name,
               List<SqlParameter> sql_parameters,
               params object[] params_values);

        public int Update(string procedure_name,
                       List<SqlParameter> sql_parameters,
                       params object[] params_values);

        public List<T> GetAll(  string procedure_name, 
                               List<SqlParameter> sql_parameters, 
                               params object[] params_values);

       public T GetById(string procedure_name,
                        SqlParameter sql_parameter, 
                        K id);

        public int Delete( string procedure_name,
                           SqlParameter sql_parameter,
                           K id);



    }
}
