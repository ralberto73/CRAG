using CRAG.DataAccess.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRAG.DataAccess.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            SystemSetting = new SystemSettingRepository(_db);
            Users = new UserRepository(_db);
        }

        public ISystemSettingRepository SystemSetting { get; private set; }
        public IUserRepository           Users { get; private set; }


        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
