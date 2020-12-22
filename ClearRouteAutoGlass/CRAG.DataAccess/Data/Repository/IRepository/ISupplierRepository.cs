using CRAG.DataAccess.Data;
using CRAG.Models;
using System.Collections.Generic;

namespace CRAG.DataAccess
{
    public interface ISupplierRepository : IADOReepository<Supplier, int>
    {
        int Create(Supplier active_record);
        bool Update(Supplier active_record);

        public Supplier GetById(int id);
        List<Supplier>  GetAll();
        int Delete(int id);


    }
}