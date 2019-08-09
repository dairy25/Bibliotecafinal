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
    public class EditoriaController : ControllerBase
    {
        private readonly EditoriaService _servicio;

        public EditoriaController(EditoriaService servicio)
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
        public IActionResult Guardar([FromBody] Editoria EditoriaGuardar)
        {
            if (_servicio.Guardar(EditoriaGuardar))
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
        public IActionResult Editar([FromBody] Editoria EditoriaEditar)
        {
            if (_servicio.Editar(EditoriaEditar))
            {
                return Ok("Editado");
            }
            else
            {
                return BadRequest();
            }

        }

        [Route("Eliminar/{IdEditoria}")]
        [HttpGet]
        public IActionResult Eliminar(int IdEditoria)
        {
            if (_servicio.Eliminar(IdEditoria))
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