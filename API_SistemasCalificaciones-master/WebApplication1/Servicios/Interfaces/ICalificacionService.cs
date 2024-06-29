using WebApplication1.Dtos.Calificacion;

namespace WebApplication1.Servicios.Interfaces
{
    public interface ICalificacionService
    {
        Task<List<CalificacionDto>> ObtenerTodoAsync();
        Task<CalificacionDto> CrearAsync(CrearCalificacionDto entidad);
        Task<CalificacionDto> ActualizarAsync(ActualizarCalificacionDto entidad);
        Task<CalificacionDto> EliminarAsync(string id);
    }
}
