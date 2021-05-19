using CalidadT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositorio
{
    public interface Usuario_Inter
    {
        public Usuario FindUserByNameAndPassword(string username, string password);
    }
    public class Usuario_Repositorio : Usuario_Inter
    {
        private readonly IAppBibliotecaContext context;
        public Usuario_Repositorio(IAppBibliotecaContext context)
        {
            this.context = context;
        }
        public Usuario FindUserByNameAndPassword(string username, string password)
        {
            return context.Usuarios.Where(o => o.Username == username && o.Password == password).FirstOrDefault();
        }
    }
}
