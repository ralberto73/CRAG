using CRAG.DataAccess.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRAG.DataAccess.Data
{
    public interface IUnitOfWork :  IDisposable
    {

        public ISystemSettingRepository SystemSetting { get; }

        public IUserRepository Users { get; }

        void Save();
    }
}
