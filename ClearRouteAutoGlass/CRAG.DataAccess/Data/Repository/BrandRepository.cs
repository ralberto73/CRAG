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

        public int Create( Brand brand)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id) => base.Delete("Brands_Delete", new SqlParameter("@id", SqlDbType.Int), id);
        List<Brand> IBrandRepository.GetAll() => base.GetAll("Brands_GetAll", null, null);        

        public Brand GetById(int id) => base.GetById("Brands_Delete", new SqlParameter("@id", SqlDbType.Int), id);

        public bool Update(Brand brand)
        {
            throw new NotImplementedException();
        }

    }
}
