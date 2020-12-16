using CRAG.DataAccess.Data;
using CRAG.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CRAG.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        
        public IActionResult Index()
        {
            IEnumerable<ApplicationUser> list_of_users;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claims != null)
            {
         
                list_of_users = _unitOfWork.Users.GetAll(u => u.Id != claims.Value);
            }
            else
                list_of_users = new List<ApplicationUser>();
            return View(list_of_users);
        }
    }
}
