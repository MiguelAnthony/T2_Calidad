using System;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    public class LibroController : Controller
    {
        private readonly Libro_Inter repository;
        private readonly ClaimService_Inter cookie;

        public LibroController(Libro_Inter repository, ClaimService_Inter cookie)
        {
            this.repository = repository;
            this.cookie = cookie;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = repository.DetallesPorLibro(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddComentario(Comentario comentario)
        {
            Usuario user = LoggedUser();

            repository.AddComentario(comentario, user);
            var libro = repository.FindLibroById(comentario);
            repository.AddPuntajePorLibro(libro, comentario);

            return RedirectToAction("Details", new { id = comentario.LibroId });
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
