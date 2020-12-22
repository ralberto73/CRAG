using CRAG.DataAccess.Data;
using CRAG.Models;
using System.Collections.Generic;

namespace CRAG.DataAccess
{
    public interface IProductRepository : IADOReepository<Product, int>
    {
        int Create(Product active_record);
        bool Update(Product active_record);

        public Product GetById(int id);
        List<Product>  GetAll();
        int Delete(int id);


    }
}