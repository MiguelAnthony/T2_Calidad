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
    class Auth_Test
    {
        [Test]
        public void probarInicioDeSesionExitoso()
        {
            var MockAuth = new Mock<Usuario_Inter>();
            MockAuth.Setup(o => o.FindUserByNameAndPassword("admin", It.IsAny<String>()))
                .Returns(new Usuario());

            var cookie = new Mock<ClaimService_Inter>();
            var controller = new AuthController(MockAuth.Object, cookie.Object);

            var view = controller.Login("admin", "admin");
            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void probarInicioDeSesionFallido()
        {
            var MockAuth = new Mock<Usuario_Inter>();
            MockAuth.Setup(o => o.FindUserByNameAndPassword("admin", It.IsAny<String>()));

            var cookie = new Mock<ClaimService_Inter>();
            var controller = new AuthController(MockAuth.Object, cookie.Object);

            var view = controller.Login("admin", "admin");
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void LogOutExitoso()
        {
            var MockAuth = new Mock<Usuario_Inter>();
            var cookie = new Mock<ClaimService_Inter>();
            var controller = new AuthController(MockAuth.Object, cookie.Object);

            var view = controller.Logout();
            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }
}
