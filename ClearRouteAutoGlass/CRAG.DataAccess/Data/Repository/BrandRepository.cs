using CRAG.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CRAG.DataAccess.Data.Repository
{
    public class BrandRepository : ADORepository<Brand, int>, IBrandRepository
    {
        public BrandRepository(string connection_string) : base(connection_string) { }

        public List<Brand> GetAll()
        {
            return base.GetAll("Brands_GetAll", null, null);
        }

        public Brand GetById(int id)
        {
            return base.GetById("Brands_GetById",
                                 new SqlParameter("@Id", SqlDbType.Int),
                                 id);
        }

        public int Delete (int id) //(string procedure_name, SqlParameter sql_parameter, )
        {
            return base.Delete("Brands_Delete", new SqlParameter("@Id", SqlDbType.Int), id);
        }

    }
}
