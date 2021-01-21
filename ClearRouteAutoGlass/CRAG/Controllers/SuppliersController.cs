using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRAG.DataAccess.Data;
using CRAG.Models;

namespace CRAG.Controllers
{
    public class SuppliersController : Controller
    {
        private IADOUnitOfWork _unit_of_work;
        public SuppliersController (IADOUnitOfWork unit_of_work)
        {
            _unit_of_work = unit_of_work;
        }
        public IActionResult Index()
        {
            //  var a = unit_of_work.Brands.GetAll();
            return View();
        }

        #region APIs

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unit_of_work.Suppliers.GetAll() });
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
