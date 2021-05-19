using CalidadT2.Controllers;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Calidad.Controler_Test
{
    class Biblioteca_Test
    {
        [Test]
        public void MostrarTodosLosLibrosConAutor()
        {
            var MockAuth = new Mock<Biblioteca_Repositorio>();
            var cookie = new Mock<ClaimService>();
            var controller = new BibliotecaController(MockAuth.Object, cookie.Object);

            var view = controller.Index();

            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void AniadirLibroHP5ABibliotecaUsuario()
        {
            var MockAuth = new Mock<Biblioteca_Repositorio>();
            var cookie = new Mock<ClaimService>();
            var controller = new BibliotecaController(MockAuth.Object, cookie.Object);

            var view = controller.Add(It.IsAny<int>());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
        [Test]
        public void MarcarComoTerminado()
        {
            var MockAuth = new Mock<Biblioteca_Repositorio>();

            var cookie = new Mock<ClaimService>();
            var controller = new BibliotecaController(MockAuth.Object, cookie.Object);

            var view = controller.MarcarComoTerminado(It.IsAny<int>());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
        [Test]
        public void MarcarComoLeyendo()
        {
            var MockAuth = new Mock<Biblioteca_Repositorio>();

            var cookie = new Mock<ClaimService>();
            var controller = new BibliotecaController(MockAuth.Object, cookie.Object);

            var view = controller.MarcarComoLeyendo(It.IsAny<int>());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }
}
