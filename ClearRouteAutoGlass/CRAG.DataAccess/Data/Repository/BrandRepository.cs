using Microsoft.Data.SqlClient;
using MyBusiness.Models;
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
                                 new SqlParameter("@BarandID", SqlDbType.Int),
                                 id);
        }

    }
}
