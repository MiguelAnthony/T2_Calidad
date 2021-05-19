using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Calidad.Controler_Test
{
    /*class Libro_Test
    {
        [Test]
        public void VistaDetallesDeLibro()
        {
            var LibroMock = new Mock<LibroController>();
            var cookieMock = new Mock<ClaimService>();

            var controller = new LibroController(LibroMock.Object, cookieMock.Object);
            var view = controller.Details(It.IsAny<int>());
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void AddComentarioDeLibro()
        {
            var LibroMock = new Mock<LibroController>();
            var cookieMock = new Mock<ClaimService>();

            var controller = new LibroController(LibroMock.Object, cookieMock.Object);
            var view = controller.AddComentario(new Comentario());
            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }*/
}
