﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRAG.DataAccess.Data;
using CRAG.Models;

namespace CRAG.Controllers
{
    public class BrandsController : Controller
    {
        private  IADOUnitOfWork _unit_of_work;
        public BrandsController(IADOUnitOfWork  unit_of_work )
        {
            _unit_of_work = unit_of_work;
        }
        public IActionResult Index()
        {
          //  var a = unit_of_work.Brands.GetAll();
            return View();
        }

        //  Update and Insert  Action 
        //  if id is null => Insert 
        //        else    => Insert
        public IActionResult Upsert(int? id)
        {
            Brand brand = new Brand();
            if (id == null)
            {
                return View(brand);
            }
            brand = _unit_of_work.Brands.GetById(id.GetValueOrDefault());
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unit_of_work.Brands.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
              int rows_deleted = _unit_of_work.Brands.Delete(id);
            if (rows_deleted == 0)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            return Json(new { success = "true", message = "Delete successfully." });
        }

        #endregion
    }
}

/*
 
    //  Update and Insert  Action 
        //  if id is null => Insert 
        //        else    => Insert
        public IActionResult Upsert(int? id) {
            Brand brand = new Brand();
            if (id == null)
            {
                return View(brand);
            }
            brand = _data_repository.Brand.GetById(id.GetValueOrDefault());
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        //  Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Brand brand )
        {
            if (ModelState.IsValid)
            {
                if (brand.BrandId == 0)
                {
                    // _unitOfWork.Category.Add(category);
                    _data_repository.Brand.AddNew(brand, "insert user");
                }
                else
                {
                    //  _unitOfWork.Category.Update(category);
                    _data_repository.Brand.Update(brand, "user update");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _data_repository.Brand.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            int rows_deleted = _data_repository.Brand.Delete(id);
            if ( rows_deleted == 0 )
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            return Json(new { success="true" , message="Delete successfully." });
        }

        #endregion
 
 
 */
