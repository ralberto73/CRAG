using CRAG.DataAccess.Data.Repository;
using CRAG.DataAccess.Data.Repository.IRepository;
using CRAG.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRAG.DataAccess.Data.Repository
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        void LockUser(string userId);

        void UnLockUser(string userId);
    }
}
