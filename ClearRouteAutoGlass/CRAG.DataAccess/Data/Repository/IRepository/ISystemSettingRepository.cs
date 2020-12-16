using CRAG.DataAccess.Data.Repository.IRepository;
using CRAG.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRAG.DataAccess.Data.Repository
{
    public interface ISystemSettingRepository : IRepository<SystemSetting>
    {
        void Update(SystemSetting system_setting);
    }
}
