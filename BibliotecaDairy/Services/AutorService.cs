using BibliotecaDairy.Models;
using BibliotecaDairy.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaDairy.Services
{
    public class AutorService
    {
        public readonly BibliotecaDbContext _DbContext;
        public AutorService(BibliotecaDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public List<Autor> Ver()
        {
            var buscado = _DbContext.Autor.OrderByDescending(x => x.Idautor).ToList();
            return buscado;
        }
        
        public bool Guardar(Autor AutorGuardar)
        {
            try
            {
                _DbContext.Autor.Add(AutorGuardar);
                _DbContext.SaveChanges();
                return true;

            }catch (Exception err)
            {
                return false;
            }
            
        }

        public bool Eliminar(int IdAutor)
        {
            try
            {
                var Eliminar = _DbContext.Autor.FirstOrDefault(x => x.Idautor == IdAutor);
                _DbContext.Autor.Remove(Eliminar);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }

        }

        public bool Editar(Autor AutorEditar)
        {
            try
            {
                var editar = _DbContext.Autor.FirstOrDefault(x => x.Idautor == AutorEditar.Idautor);
                editar.nombre = AutorEditar.nombre;
                editar.nacionalidad = AutorEditar.nacionalidad;
                editar.fechadenacimiento = AutorEditar.fechadenacimiento;
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }

        }
    }
}
