using BibliotecaDairy.Models;
using BibliotecaDairy.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaDairy.Services
{
    public class EditoriaService
    {
       
            public readonly BibliotecaDbContext _DbContext;
            public EditoriaService(BibliotecaDbContext DbContext)
            {
                _DbContext = DbContext;
            }

            public List<Editoria> Ver()
            {
                var buscado = _DbContext.Editoria.OrderByDescending(x => x.Ideditoria).ToList();
                return buscado;
            }

            public bool Guardar(Editoria EditoriaGuardar)
            {
                try
                {
                    _DbContext.Editoria.Add(EditoriaGuardar);
                    _DbContext.SaveChanges();
                    return true;

                }
                catch
                {
                    return false;
                }

            }

            public bool Eliminar(int Ideditoria)
            {
                try
                {
                    var Eliminar = _DbContext.Editoria.FirstOrDefault(x => x.Ideditoria == Ideditoria);
                    _DbContext.Editoria.Remove(Eliminar);
                    _DbContext.SaveChanges();
                    return true;
                }
                catch 
                {
                    return false;
                }

            }

            public bool Editar(Editoria EditoriaEditar)
            {
                try
                {
                    var editar = _DbContext.Editoria.FirstOrDefault(x => x.Ideditoria == EditoriaEditar.Ideditoria);
                    editar.nombre = EditoriaEditar.nombre;
                    editar.fechadefundacion = EditoriaEditar.fechadefundacion;
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
