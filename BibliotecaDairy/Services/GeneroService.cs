using BibliotecaDairy.Models;
using BibliotecaDairy.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaDairy.Services
{
    public class GeneroService
    {
        public readonly BibliotecaDbContext _DbContext;
        public GeneroService(BibliotecaDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public List<Genero> Ver()
        {
            var buscado = _DbContext.Genero.OrderByDescending(x => x.Idgenero).ToList();
            return buscado;
        }

        public bool Guardar(Genero GeneroGuardar)
        {
            try
            {
                _DbContext.Genero.Add(GeneroGuardar);
                _DbContext.SaveChanges();
                return true;

            }
            catch 
            {
                return false;
            }

        }

        public bool Eliminar(int Idgenero)
        {
            try
            {
                var Eliminar = _DbContext.Genero.FirstOrDefault(x => x.Idgenero == Idgenero);
                _DbContext.Genero.Remove(Eliminar);
                _DbContext.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }

        }

        public bool Editar(Genero GeneroEditar)
        {
            try
            {
                var editar = _DbContext.Genero.FirstOrDefault(x => x.Idgenero == GeneroEditar.Idgenero);
                editar.nombre = GeneroEditar.nombre;
                editar.definicion = GeneroEditar.definicion;
                _DbContext.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }

        }
    }
}
