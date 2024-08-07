using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BW_5.Models;
using BW5.DataContext;

namespace BW_5.Controllers
{
    public class AccountController : Controller
    {
        private readonly ClinicaDbContext _context;

        public AccountController(ClinicaDbContext context)
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
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(model);
                _context.SaveChanges();

                // Registrazione riuscita, redirigi alla pagina di login
                return RedirectToAction("Login");
            }

            // Se abbiamo raggiunto questo punto, qualcosa è fallito; ridisplay il form
            return View(model);
        }
    }
}
