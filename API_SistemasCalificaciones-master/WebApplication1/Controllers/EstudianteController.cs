using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Servicios.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService estudianteService;

        public EstudianteController(IEstudianteService estudianteService)
        {
            this.estudianteService = estudianteService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodo()
        {
            try
            {
                var data = await estudianteService.ObtenerTodo();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new { Mensaje = e.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerEstudiantePorId(string id)
        {
            try
            {
                var data = await estudianteService.ObtenerEstudiantePorId(id);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(new { Mensaje = e.Message });
            }
        }
    }
}
