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
            List<SqlParameter> list_of_insert_parametres = new List<SqlParameter>();
            list_of_insert_parametres.Add(new SqlParameter("@BrandName", SqlDbType.NVarChar,50));
            list_of_insert_parametres.Add(new SqlParameter("@user"     , SqlDbType.VarChar, 100));
            return base.Create("Brands_AddNew"
                                , list_of_insert_parametres
                                , brand.BrandName
                                , brand.CreatedBy);
        }

        public int Delete(int id) => base.Delete("Brands_Delete", new SqlParameter("@id", SqlDbType.Int), id);
        List<Brand> IBrandRepository.GetAll() => base.GetAll("Brands_GetAll", null, null);        

        public Brand GetById(int id) => base.GetById("Brands_Delete", new SqlParameter("@id", SqlDbType.Int), id);

        public bool Update( Brand brand)
        {
            List<SqlParameter> list_of_insert_parametres = new List<SqlParameter>();
            list_of_insert_parametres.Add(new SqlParameter("@id", SqlDbType.Int));
            list_of_insert_parametres.Add(new SqlParameter("@BrandName", SqlDbType.NVarChar, 50));
            list_of_insert_parametres.Add(new SqlParameter("@user", SqlDbType.VarChar, 100));
            return base.Create("Brands_Update"
                                , list_of_insert_parametres
                                , brand.BrandId
                                , brand.BrandName
                                , brand.UpdatedBy) > 0;
        }

    }
}
