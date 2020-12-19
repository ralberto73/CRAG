using CRAG.DataAccess.Data;
using CRAG.Models;
using System.Collections.Generic;

namespace CRAG.DataAccess
{
    public interface IInsuranceRepository : IADOReepository<Insurance, int>
    {

        int Create(Insurance Insurance);
        bool Update(Insurance Insurance);

        public Insurance GetById(int id);
        List<Insurance>  GetAll();
        int Delete(int id);


    }
}