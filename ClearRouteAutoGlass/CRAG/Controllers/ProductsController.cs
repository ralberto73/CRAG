using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRAG.DataAccess.Data;
using CRAG.Models;

namespace CRAG.Controllers
{
    public class ProductsController : Controller
    {
        private IADOUnitOfWork _unit_of_work;
        public ProductsController(IADOUnitOfWork unit_of_work)
        {
            _unit_of_work = unit_of_work;
        }
        public IActionResult Index() => View();

        public IActionResult Upsert(int? id)
        {
            Product active_record = new Product();
            if (id == null)
            {
                return View(active_record);
            }
            active_record = _unit_of_work.Products.GetById(id.GetValueOrDefault());
            if (active_record == null)
            {
                return NotFound();
            }
            return View(active_record);
        }

        //  Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product active_record)
        {
            if (ModelState.IsValid)
            {
                active_record.UpdatedBy = GetUser();
                if (active_record.ProductId == 0)
                {
                    active_record.CreatedBy = active_record.UpdatedBy;
                    _unit_of_work.Products.Create(active_record);
                }
                else
                {
                    _unit_of_work.Products.Update(active_record);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(active_record);
        }

        private string GetUser()
        {
            return "Cabilla";
        }

        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unit_of_work.Products.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            int rows_deleted = _unit_of_work.Products.Delete(id);
            if (rows_deleted == 0)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            return Json(new { success = "true", message = "Delete successfully." });
        }

        #endregion




    }
}
