using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRAG.DataAccess.Data.Repository.IRepository
{
    /// <summary>
    ///   Signature of Data repository 
    /// </summary>
    /// <typeparam name="T">Model's Class</typeparam>
    /// <typeparam name="K">Primary Key Type </typeparam>
    public interface  IADOReepository<T, K> where T : class
    {

        /// <summary>
        ///   Call  Stored procedure  [Identity]_GetById 
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <param name="procedure_Name">Procedure Name</param>
        /// <returns></returns>
        public T Get(string procedure_name, SqlParameter sql_parameter, K id);


        /// <summary>
        /// Get Stored Procedure
        /// </summary>
        /// <param name="sql_parameters">List of parameters </param>
        /// <param name="params_values">List of Values</param>
        /// <returns></returns>
        IEnumerable<T> GetAll(List<SqlParameter> sql_parameters, params object[] params_values);
    }
}
