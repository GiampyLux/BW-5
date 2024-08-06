using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BW_5.Models;
using BW_5.DataContext;

namespace BW_5.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Cerca l'utente nel database
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                // Login riuscito, redirigi alla pagina di home o dashboard
                return RedirectToAction("Index", "Home");
            }

            // Login fallito, mostra un messaggio di errore
            ModelState.AddModelError("", "Email o password non validi.");
            return View();
        }
    }
}
