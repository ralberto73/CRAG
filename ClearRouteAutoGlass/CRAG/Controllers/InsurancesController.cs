using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRAG.DataAccess.Data;
using CRAG.Models;

namespace CRAG.Controllers
{
    public class InsurancesController : Controller
    {
        private  IADOUnitOfWork _unit_of_work;
        public InsurancesController(IADOUnitOfWork  unit_of_work )
        {
            _unit_of_work = unit_of_work;
        }
        public IActionResult Index() => View();


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

        //  Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Brand brand)
        {
            if (ModelState.IsValid)
            {
                brand.UpdatedBy = GetUser();
                if (brand.BrandId == 0)
                {
                    brand.CreatedBy = brand.UpdatedBy;
                    _unit_of_work.Brands.Create(brand);
                }
                else
                {
                    _unit_of_work.Brands.Update(brand);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        private string GetUser()
        {
            return "Cabilla";
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unit_of_work.Insurances.GetAll() });
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
