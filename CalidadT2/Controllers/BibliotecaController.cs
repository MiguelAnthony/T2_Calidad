using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalidadT2.Constantes;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    [Authorize]
    public class BibliotecaController : Controller
    {
        private readonly Biblioteca_Inter repository;
        private readonly ClaimService_Inter cookie;

        public BibliotecaController(Biblioteca_Inter repository, ClaimService_Inter cookie)
        {
            this.repository = repository;
            this.cookie = cookie;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Usuario user = LoggedUser();

            var model = repository.BibliotecaDeUsuarioPorAutor(user);
            return View(model);
        }

        [HttpGet]
        public ActionResult Add(int libro)
        {
            Usuario user = LoggedUser();
            repository.SetTempData(TempData);
            repository.AniadirLibroABiblioteca(libro, user);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MarcarComoLeyendo(int libroId)
        {
            Usuario user = LoggedUser();

            var libro = repository.RetornarBiblioteca(libroId, user);

            repository.SetTempData(TempData);
            repository.GuardarCambiosLeyendo(libro);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarcarComoTerminado(int libroId)
        {
            Usuario user = LoggedUser();

            var libro = repository.RetornarBiblioteca(libroId, user);
            repository.SetTempData(TempData);
            repository.GuardarCambiosTerminado(libro);

            return RedirectToAction("Index");
        }

        public Usuario LoggedUser()
        {
            cookie.SetHttpContext(HttpContext);
            var claim = cookie.UsuarioLogueado();
            var user = repository.DevolverUsuarioLogueado(claim);
            return user;
        }
    }
}
