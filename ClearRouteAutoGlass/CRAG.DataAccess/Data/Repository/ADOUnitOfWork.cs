using System;
using System.Collections.Generic;
using System.Text;

namespace CRAG.DataAccess.Data.Repository
{
    public class ADOUnitOfWork : IADOUnitOfWork
    {
        public IBrandRepository     Brands { get; set; }
        public IInsuranceRepository Insurances { get; set; }

        public ADOUnitOfWork( string connection_String)
        {
            Brands = new BrandRepository(connection_String);
            Insurances  = new InsuranceRepository(connection_String);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
