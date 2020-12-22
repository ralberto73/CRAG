using CRAG.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CRAG.DataAccess.Data.Repository
{
    public class SupplierRepository : ADORepository<Supplier, int>, ISupplierRepository
    {
        public SupplierRepository(string connection_string) : base(connection_string) { }

        public int Create( Supplier active_record)
        {
            List<SqlParameter> list_of_insert_parametres = new List<SqlParameter>();
            list_of_insert_parametres.Add(new SqlParameter("@SupplierName", SqlDbType.NVarChar, 50));
            list_of_insert_parametres.Add(new SqlParameter("@user", SqlDbType.VarChar, 100));
            return base.Create("Suppliers_AddNew"
                                , list_of_insert_parametres
                                , active_record.SupplierName
                                , active_record.CreatedBy);
        }

        public int Delete(int id) => base.Delete("Suppliers_Delete", new SqlParameter("@id", SqlDbType.Int), id);
   
        public List<Supplier> GetAll() => base.GetAll("Suppliers_GetAll", null, null);
        public Supplier GetById(int id) => base.GetById("Suppliers_GetById", new SqlParameter("@id", SqlDbType.Int), id);

        public bool Update(Supplier active_record)
        {
            List<SqlParameter> list_of_insert_parametres = new List<SqlParameter>();
            list_of_insert_parametres.Add(new SqlParameter("@id", SqlDbType.Int));
            list_of_insert_parametres.Add(new SqlParameter("@SupplierName", SqlDbType.NVarChar, 50));
            list_of_insert_parametres.Add(new SqlParameter("@user", SqlDbType.VarChar, 100));
            return base.Create("Suppliers_Update"
                                , list_of_insert_parametres
                                , active_record.SupplierId
                                , active_record.SupplierName
                                , active_record.UpdatedBy) > 0;
        }

       
    }
}
