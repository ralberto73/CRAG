﻿using CRAG.DataAccess.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRAG.DataAccess.Data
{
    public interface IADOUnitOfWork : IDisposable
    {

        public IBrandRepository  Brands {get;set;}
    }
}