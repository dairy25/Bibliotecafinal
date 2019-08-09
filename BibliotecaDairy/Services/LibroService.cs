using BibliotecaDairy.Models;
using BibliotecaDairy.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaDairy.Services
{
    public class LibroService
    {
        
            public readonly BibliotecaDbContext _DbContext;
            public LibroService(BibliotecaDbContext DbContext)
            {
                _DbContext = DbContext;
            }

            public List<Libro> Ver()
            {
                var buscado = _DbContext.Libro.OrderByDescending(x => x.Idlibro).ToList();
                return buscado;
            }

            public bool Guardar(Libro LibroGuardar)
            {
                try
                {
                    _DbContext.Libro.Add(LibroGuardar);
                    _DbContext.SaveChanges();
                    return true;

                }
                catch (Exception err)
                {
                    return false;
                }

            }

            public bool Eliminar(int IdLibro)
            {
                try
                {
                    var Eliminar = _DbContext.Libro.FirstOrDefault(x => x.Idlibro == IdLibro);
                    _DbContext.Libro.Remove(Eliminar);
                    _DbContext.SaveChanges();
                    return true;
                }
                catch (Exception err)
                {
                    return false;
                }

            }

            public bool Editar(Libro LibroEditar)
            {
                try
                {
                    var editar = _DbContext.Libro.FirstOrDefault(x => x.Idlibro == LibroEditar.Idlibro);
                    editar.nombre = LibroEditar.nombre;
                    editar.sipnosis = LibroEditar.sipnosis;
                    editar.contenido = LibroEditar.contenido;
                    editar.Idautor = LibroEditar.Idautor;
                    editar.Idgenero = LibroEditar.Idgenero;
                    editar.Ideditoria = LibroEditar.Ideditoria;
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
