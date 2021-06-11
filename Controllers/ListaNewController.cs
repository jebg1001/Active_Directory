using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Active_Directory.Models;

namespace Active_Directory.Controllers
{
    public class ListaNewController : Controller
    {
        private readonly ILogger<ListaController> _logger;

        
        public ListaNewController(ILogger<ListaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Lista()
        {
            var userClaims = User.Identity as System.Security.Claims.ClaimsIdentity;
            dynamic model = new ExpandoObject(); 
            model.Usuario=userClaims?.FindFirst("name")?.Value;
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
