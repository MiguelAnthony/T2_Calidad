using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CalidadT2.Repositorio
{
    public interface ClaimService_Inter
    {
        public void SetHttpContext(HttpContext httpContext);
        public void Login(ClaimsPrincipal claim);
        public void Logout();
        public string UsuarioLogueado();
    }
    public class ClaimService : ClaimService_Inter
    {
        private HttpContext httpContext;
        public void SetHttpContext(HttpContext httpContext)
        {
            this.httpContext = httpContext;
        }
        public void Login(ClaimsPrincipal claim)
        {
            httpContext.SignInAsync(claim);
        }
        public void Logout()
        {
            httpContext.SignOutAsync();
        }
        public string UsuarioLogueado()
        {
            var claim = httpContext.User.Claims.FirstOrDefault();
            return claim.Value;
        }
    }
}
