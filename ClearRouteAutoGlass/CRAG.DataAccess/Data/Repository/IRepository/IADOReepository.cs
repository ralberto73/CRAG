using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRAG.DataAccess.Data.Repository.IRepository
{

    public interface  IADOReepository<T, K> where T : new()
    {

        public List<T> GetAll(  string procedure_name, 
                               List<SqlParameter> sql_parameters, 
                               params object[] params_values);

       public T GetById(string procedure_name,
                        SqlParameter sql_parameter, 
                        K id);
    }
}
