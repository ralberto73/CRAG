using CRAG.DataAccess.Data;
using CRAG.Models;
using System.Collections.Generic;

namespace CRAG.DataAccess
{
    public interface IBrandRepository : IADOReepository<Brand, int>
    {

        int Create(Brand brand);
        bool Update(Brand brand);

        public Brand GetById(int id);
        List<Brand>  GetAll();
        int Delete(int id);


    }
}