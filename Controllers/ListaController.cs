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
    public class ListaController : Controller
    {
        private readonly ILogger<ListaController> _logger;
        private readonly MyDatabaseContext _context;

        public ListaController(ILogger<ListaController> logger, MyDatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userClaims = User.Identity as System.Security.Claims.ClaimsIdentity;
            Profesor prof = new Profesor();
            prof.Name =userClaims?.FindFirst("name")?.Value;
            prof.Username= userClaims?.FindFirst("preferred_username")?.Value;
            prof.Hora=DateTime.Now;
            await _context.Profesores.AddAsync(prof);  
            await _context.SaveChangesAsync();

            dynamic model = new ExpandoObject(); 
            model.Alumnos= await _context.Alumnos.ToListAsync();
            model.Profesores = await _context.Profesores.ToListAsync();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
