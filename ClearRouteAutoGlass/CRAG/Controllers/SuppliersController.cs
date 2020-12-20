using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRAG.Controllers
{
    public class SuppliersController : Controller
    {
        public IActionResult Index() => View();
    }
}
