using CRAG.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CRAG.DataAccess.Data.Repository
{
    public class InsuranceRepository : ADORepository<Insurance, int>, IInsuranceRepository
    {
        public InsuranceRepository(string connection_string) : base(connection_string) { }

        public int Create( Insurance new_entity)
        {
            List<SqlParameter> list_of_insert_parametres = new List<SqlParameter>();
            list_of_insert_parametres.Add(new SqlParameter("@InsuranceName", SqlDbType.NVarChar, 50));
            list_of_insert_parametres.Add(new SqlParameter("@user", SqlDbType.VarChar, 100));
            return base.Create("Insurances_AddNew"
                                , list_of_insert_parametres
                                , new_entity.InsuranceName
                                , new_entity.CreatedBy);
        }

        public int Delete(int id) => base.Delete("Insurances_Delete", new SqlParameter("@id", SqlDbType.Int), id);
        List<Insurance> IInsuranceRepository.GetAll() => base.GetAll("Insurances_GetAll", null, null);

        public Insurance GetById(int id) => base.GetById("Insurances_GetById", new SqlParameter("@id", SqlDbType.Int), id);

        public bool Update(Insurance Insurance)
        {
            List<SqlParameter> list_of_insert_parametres = new List<SqlParameter>();
            list_of_insert_parametres.Add(new SqlParameter("@id", SqlDbType.Int));
            list_of_insert_parametres.Add(new SqlParameter("@InsuranceName", SqlDbType.NVarChar, 50));
            list_of_insert_parametres.Add(new SqlParameter("@user", SqlDbType.VarChar, 100));
            return base.Create("Insurances_Update"
                                , list_of_insert_parametres
                                , Insurance.InsuranceId
                                , Insurance.InsuranceName
                                , Insurance.UpdatedBy) > 0;
        }

    }
}
