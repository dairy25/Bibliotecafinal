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
    public class AutorController : ControllerBase
    {
        private readonly AutorService _servicio;

        public AutorController(AutorService servicio)
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
        public IActionResult Guardar([FromBody] Autor AutorGuardar)
        {
            if (_servicio.Guardar(AutorGuardar))
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
        public IActionResult Editar([FromBody] Autor AutorEditar)
        {
            if (_servicio.Editar(AutorEditar))
            {
                return Ok("Editado");
            }
            else
            {
                return BadRequest();
            }

        }

        [Route("Eliminar/{IdAutor}")]
        [HttpGet]
        public IActionResult Eliminar(int IdAutor)
        {
            if (_servicio.Eliminar(IdAutor))
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