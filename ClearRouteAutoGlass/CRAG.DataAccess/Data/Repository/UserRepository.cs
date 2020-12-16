using CRAG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRAG.DataAccess.Data.Repository
{
     public class UserRepository : Repository<ApplicationUser> , IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository( ApplicationDbContext  db) : base(db)
        {
            _db = db;
        }

        public void LockUser(string userId)
        {
            var user = _db.ApplicationUser.FirstOrDefault(u => u.Id == userId);
            user.LockoutEnd = DateTime.Now.AddYears(1000);
            _db.SaveChanges();
        }

        public void UnLockUser(string userId)
        {
            var user = _db.ApplicationUser.FirstOrDefault(u => u.Id == userId);
            user.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
