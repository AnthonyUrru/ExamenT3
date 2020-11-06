using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Examen_T3.Models;
using Examen_T3.Models.GenerarEjercicios;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Examen_T3.Controllers
{
    public class ExamenT3Controller : Controller
    {
        private readonly ExamenT3Context _context;
        private readonly IConfiguration configuration;
        public int nveces;
        public List<Ejercicio> a= new List<Ejercicio>();
        public Ejercicio[] list = new Ejercicio[1000];
        public List<int> f = new List<int>();
        public ExamenT3Controller(ExamenT3Context context, IConfiguration configuration)
        {
            _context = context;
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var rutines = _context.Rutines.Where(o=>o.UserId==LoggerUser().Id)
                .ToList();

            var rutinesEjerci = _context.EjercicioRutines.Where(o => o.Usserid == LoggerUser().Id)
                 .Include(o => o.ejercicio).ToList();
            var rut = _context.EjercicioRutines.ToList();
            for(int i = 0; i < rutinesEjerci.Count; i++)
            {
                var v=rutinesEjerci[i].ejercicio;

                     a.Add(v);
                    //list[i] = v;
                
                
            }
            //a = list.ToList();
        ViewBag.Ejercicios = a;
            
            //foreach (var item in rutinesEjerci)
            //{
            //    a.Add(item.ejercicio);
            //}

            return View(rutines);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string contraseña)
        {
            var user = _context.Users.Where(o=>o.Username==username&&o.Password==CreateHash(contraseña))
                .FirstOrDefault();
            if (user!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(claimsPrincipal);
                var rutines = _context.Rutines
               .ToList();
                return RedirectToAction("Index",rutines);
            }
            // ModelState.AddModelError("Login", "Usuario o contraseña incorrectos");
           
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View("Register", new User());
        }
        [HttpPost]
        public ActionResult Register(User user, string name, string lastname, string username, string contraseña, string verfcontraseña)
        {
            if (ModelState.IsValid)
            {
                user.Name = name;
                user.LastName = lastname;
                user.Username = username;
                user.Password = CreateHash(contraseña);
                user.VerfPassword = CreateHash(verfcontraseña);
                _context.Users.Add(user);
                _context.SaveChanges();
                var rutines = _context.Rutines.Where(o => o.UserId == LoggerUser().Id)
                 .ToList();
                return RedirectToAction("Index",rutines);
            }
            return View("Register", user);
        }
        [HttpGet]
        public ActionResult CrearRutina()
        {
            return View("CrearRutina", new Rutine());
        }
        [HttpPost]
        public ActionResult CrearRutina(Rutine rutine, string Tipo)
        {
            //var rutine1 = _context.Rutines.First();
            //var ejercicio1 = _context.Ejercicios.First();
            //guardar la rutina
            rutine.UserId = LoggerUser().Id;
            _context.Rutines.Add(rutine);
            _context.SaveChanges();
            _context.SaveChanges();
            var rutinass = _context.Rutines.Where(o => o.UserId == LoggerUser().Id)
                 .ToList();
            ///guardar relacion
            InterfaceGenerar c = null;
            InterfaceGenerar g = null;
            if (Tipo == "Principiante")
            {
               
                    c = new Principiante();
                    g = new GenerarTp();
                nveces = 5;
                
            }
            if (Tipo=="Intermemdio")
            {

                c = new Intermedio();
                g = new GenerarTi();
                nveces = 10;
            }
            if (Tipo == "Avanzado")
            {
                c = new Avanzado();
                g = new GenerarTa();
                nveces = 15;
            }

            if (rutine!=null)
            {
                for (int i = 0; i < nveces; i++)
                {
                    var ejercicioRutine = new EjercicioRutine();
                    ejercicioRutine.RutineId = rutine.Id;
                    ejercicioRutine.EjercicioId = c.generar();
                    ejercicioRutine.tiempo = g.generar();
                    ejercicioRutine.Usserid = LoggerUser().Id;

                    _context.EjercicioRutines.Add(ejercicioRutine);
                    _context.SaveChanges();
                }
                var rutinesEjerci = _context.EjercicioRutines.Where(o => o.Usserid == LoggerUser().Id)
                .Include(o => o.ejercicio).ToList();

                for (int i = 0; i < rutinesEjerci.Count; i++)
                {
                    var v = rutinesEjerci[i].ejercicio;
                    
                    a.Add(v);
                }
                ViewBag.Ejercicios = a;

                return View("Index", rutinass);
            }
            return View();
        }
        private string CreateHash(string input)
        {
            var sha = SHA256.Create();
            input += configuration.GetValue<string>("Token");
            var hash = sha.ComputeHash(Encoding.Default.GetBytes(input));
            return Convert.ToBase64String(hash);
        }
        public User LoggerUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = _context.Users.Where(o => o.Username == claim.Value).FirstOrDefault();
            return user;
        }

    }
}
