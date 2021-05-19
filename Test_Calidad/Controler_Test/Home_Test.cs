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
    class Home_Test
    {
        [Test]
        public void RetornaLibrosConAutor()
        {
            var mockHome = new Mock<Libro_Repositorio>();
            var controller = new HomeController(mockHome.Object);
            var view = controller.Index();
            Assert.IsInstanceOf<ViewResult>(view);
        }
    }
}
