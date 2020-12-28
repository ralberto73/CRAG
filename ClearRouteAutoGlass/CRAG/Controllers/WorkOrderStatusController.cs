using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRAG.Controllers
{
    public class WorkOrderStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
