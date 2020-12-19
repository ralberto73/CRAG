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

        public int Create( Insurance Insurance)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id) => base.Delete("Insurances_Delete", new SqlParameter("@id", SqlDbType.Int), id);
        List<Insurance> IInsuranceRepository.GetAll() => base.GetAll("Insurances_GetAll", null, null);        

        public Insurance GetById(int id) => base.GetById("Insurances_Delete", new SqlParameter("@id", SqlDbType.Int), id);

        public bool Update(Insurance Insurance)
        {
            throw new NotImplementedException();
        }

    }
}
