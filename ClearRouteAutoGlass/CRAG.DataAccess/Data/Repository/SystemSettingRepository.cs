using CRAG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRAG.DataAccess.Data.Repository
{
    public class SystemSettingRepository : Repository<SystemSetting> , ISystemSettingRepository
    {
        private readonly ApplicationDbContext _db;

        public SystemSettingRepository( ApplicationDbContext  db) : base(db)
        {
            _db = db;
        }

        void ISystemSettingRepository.Update(SystemSetting system_setting)
        {
            // _db.Update(system_setting);
            var objFromDb = _db.SystemSetting.FirstOrDefault(s => s.Id == system_setting.Id);
            objFromDb.Key = system_setting.Key;
            objFromDb.Value = system_setting.Value;

        }
    }
}
