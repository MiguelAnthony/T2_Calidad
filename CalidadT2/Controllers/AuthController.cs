using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CalidadT2.Controllers
{
    public class AuthController : Controller
    {
            private readonly Usuario_Inter repository;
            private readonly ClaimService_Inter cookie;

            public AuthController(Usuario_Inter repository, ClaimService_Inter cookie)
            {
                this.repository = repository;
                this.cookie = cookie;
            }

            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Login(string username, string password)
            {
                var usuario = repository.FindUserByNameAndPassword(username, password);

                if (usuario != null)
                {
                    var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username)
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    cookie.SetHttpContext(HttpContext);
                    cookie.Login(claimsPrincipal);

                    return RedirectToAction("Index", "Home");
                }

                ViewBag.Validation = "Usuario y/o contraseña incorrecta";
                return View();
            }


            public ActionResult Logout()
            {
                cookie.SetHttpContext(HttpContext);
                cookie.Logout();
                return RedirectToAction("Login");
            }
        }
    }

