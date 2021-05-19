using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositorio
{
    public interface Home_Inter
    {
        List<Libro> ListaLibros();

    }
    public class Home_Repositorio : Home_Inter
    {
        private readonly IAppBibliotecaContext app;

        public Home_Repositorio(IAppBibliotecaContext app)
        {
            this.app = app;
        }
        public List<Libro> ListaLibros()
        {
            return app.Libros.Include(o => o.Autor).ToList();
        }
    }
}
