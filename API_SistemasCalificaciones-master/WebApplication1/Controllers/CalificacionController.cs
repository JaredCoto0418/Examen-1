using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos.Calificacion;
using WebApplication1.Servicios.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        private readonly ICalificacionService calificacionService;

        public CalificacionController(ICalificacionService calificacionService)
        {
            this.calificacionService = calificacionService;
        }

        [HttpGet]
        public async Task<ActionResult> ObtenerTodo()
        {
            try
            {
                var data = await calificacionService.ObtenerTodoAsync();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new { Mensaje = e.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Agregar(CrearCalificacionDto dto)
        {
            try
            {
                var data = await calificacionService.CrearAsync(dto);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new { Mensaje = e.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Actualizar(ActualizarCalificacionDto dto)
        {
            try
            {
                var data = await calificacionService.ActualizarAsync(dto);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new { Mensaje = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(string id)
        {
            try
            {
                var data = await calificacionService.EliminarAsync(id);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new { Mensaje = e.Message });
            }
        }
    }
}
