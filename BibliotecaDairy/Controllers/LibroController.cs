using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaDairy.Models;
using BibliotecaDairy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaDairy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly LibroService _servicio;

        public LibroController(LibroService servicio)
        {
            _servicio = servicio;
        }

        [Route("Ver")]
        public IActionResult Ver()
        {
            var resultado = _servicio.Ver();
            return Ok(resultado);
        }

        [Route("Guardar")]
        [HttpPost]
        public IActionResult Guardar([FromBody] Libro LibroGuardar)
        {
            if (_servicio.Guardar(LibroGuardar))
            {
                return Ok("Agregado");
            }
            else
            {
                return BadRequest();
            }

        }

        [Route("Editar")]
        [HttpPut]
        public IActionResult Editar([FromBody] Libro LibroEditar)
        {
            if (_servicio.Editar(LibroEditar))
            {
                return Ok("Editado");
            }
            else
            {
                return BadRequest();
            }

        }

        [Route("Eliminar/{IdLibro}")]
        [HttpGet]
        public IActionResult Eliminar(int IdLibro)
        {
            if (_servicio.Eliminar(IdLibro))
            {
                return Ok("Eliminado");
            }
            else
            {
                return BadRequest();
            }

        }
    }
}