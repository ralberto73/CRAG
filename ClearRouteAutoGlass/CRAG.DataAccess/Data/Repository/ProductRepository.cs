using CRAG.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CRAG.DataAccess.Data.Repository
{
    public class ProductRepository : ADORepository<Product, int>, IProductRepository
    {
        public ProductRepository(string connection_string) : base(connection_string) { }

        public int Create( Product active_record)
        {
            List<SqlParameter> list_of_insert_parametres = new List<SqlParameter>();
            list_of_insert_parametres.Add(new SqlParameter("@ProductName", SqlDbType.NVarChar, 50));
            list_of_insert_parametres.Add(new SqlParameter("@user", SqlDbType.VarChar, 100));
            return base.Create("Products_AddNew"
                                , list_of_insert_parametres
                                , active_record.ProductName
                                , active_record.CreatedBy);
        }

        public int Delete(int id) => base.Delete("Products_Delete", new SqlParameter("@id", SqlDbType.Int), id);
   
        public List<Product> GetAll() => base.GetAll("Products_GetAll", null, null);
        public Product GetById(int id) => base.GetById("Products_GetById", new SqlParameter("@id", SqlDbType.Int), id);

        public bool Update(Product active_record)
        {
            List<SqlParameter> list_of_insert_parametres = new List<SqlParameter>();
            list_of_insert_parametres.Add(new SqlParameter("@id", SqlDbType.Int));
            list_of_insert_parametres.Add(new SqlParameter("@ProductName", SqlDbType.NVarChar, 50));
            list_of_insert_parametres.Add(new SqlParameter("@user", SqlDbType.VarChar, 100));
            return base.Create("Products_Update"
                                , list_of_insert_parametres
                                , active_record.ProductId
                                , active_record.ProductName
                                , active_record.UpdatedBy) > 0;
        }

       
    }
}
