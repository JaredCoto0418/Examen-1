using WebApplication1.Dtos.Calificacion;
using WebApplication1.Dtos.Estudiante;
using WebApplication1.Servicios.Comunes;
using WebApplication1.Servicios.Interfaces;

namespace WebApplication1.Servicios
{
    public class EstudianteService : IEstudianteService
    {
        public readonly string _JSON_CALIFICACIONES = "Data/calificaciones.json";
        public readonly string _JSON_ESTUDIANTES = "Data/estudiantes.json";

        public async Task<EstudianteDto> ObtenerEstudiantePorId(string id)
        {
            var calificaciones = await ArchivoJSON.ReadFromFileAsync<CalificacionDto>(_JSON_CALIFICACIONES);
            var estudiantes = await ArchivoJSON.ReadFromFileAsync<EstudianteEntidad>(_JSON_ESTUDIANTES);
            var estudiante = estudiantes.Find(x => x.Id == id);
            if (estudiante == null) throw new Exception("El Id del estudiante no existe!");
            var calificacionesEstudiante = calificaciones.Where(c => c.IdEstudiante == id);
            var promedio = calificacionesEstudiante.Count() == 0 ? 0 : calificacionesEstudiante.Average(c => c.Nota);

            return new EstudianteDto() { 
                Id = estudiante.Id, 
                Nombre = estudiante.Nombre, 
                Apellido = estudiante.Apellido, 
                Promedio = promedio 
            };
        }

        public async Task<List<EstudianteDto>> ObtenerTodo()
        {
            var calificaciones = await ArchivoJSON.ReadFromFileAsync<CalificacionDto>(_JSON_CALIFICACIONES);
            var estudiantes = await ArchivoJSON.ReadFromFileAsync<EstudianteEntidad>(_JSON_ESTUDIANTES);
            return estudiantes.Select(x =>
            {
                var calificacionesEstudiante = calificaciones.Where(c => c.IdEstudiante == x.Id);
                var promedio = calificacionesEstudiante.Count() == 0 ? 0 : calificacionesEstudiante.Average(c => c.Nota);
                return new EstudianteDto()
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    Promedio = promedio
                };
            }).ToList();
        }
    }
}
