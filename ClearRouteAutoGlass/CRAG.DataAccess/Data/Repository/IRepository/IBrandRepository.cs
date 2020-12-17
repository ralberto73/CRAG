﻿using MyBusiness.Models;
using System.Collections.Generic;

namespace CRAG.DataAccess.Data.Repository
{
    public interface IBrandRepository
    {
        List<Brand> GetAll();
        Brand GetById(int id);
    }
}