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
    public class GeneroController : ControllerBase
    {
        private readonly GeneroService _servicio;

        public GeneroController(GeneroService servicio)
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
        public IActionResult Guardar([FromBody] Genero GeneroGuardar)
        {
            if (_servicio.Guardar(GeneroGuardar))
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
        public IActionResult Editar([FromBody] Genero GeneroEditar)
        {
            if (_servicio.Editar(GeneroEditar))
            {
                return Ok("Editado");
            }
            else
            {
                return BadRequest();
            }

        }

        [Route("Eliminar/{IdGenero}")]
        [HttpGet]
        public IActionResult Eliminar(int IdGenero)
        {
            if (_servicio.Eliminar(IdGenero))
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