using WebApplication1.Dtos.Estudiante;

namespace WebApplication1.Servicios.Interfaces
{
    public interface IEstudianteService
    {
        Task<List<EstudianteDto>> ObtenerTodo();
        Task<EstudianteDto> ObtenerEstudiantePorId(string id);
    }
}
