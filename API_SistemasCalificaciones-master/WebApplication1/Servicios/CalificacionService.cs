using Newtonsoft.Json;
using WebApplication1.Dtos.Calificacion;
using WebApplication1.Dtos.Estudiante;
using WebApplication1.Servicios.Comunes;
using WebApplication1.Servicios.Interfaces;

namespace WebApplication1.Servicios
{
    public class CalificacionService : ICalificacionService
    {
        public readonly string _JSON_CALIFICACIONES = "Data/calificaciones.json";
        public readonly string _JSON_ESTUDIANTES = "Data/estudiantes.json";
        public async Task<List<CalificacionDto>> ObtenerTodoAsync()
        {
            return await ArchivoJSON.ReadFromFileAsync<CalificacionDto>(_JSON_CALIFICACIONES);
        }
        public async Task<CalificacionDto> CrearAsync(CrearCalificacionDto entidad)
        {
            var calificaciones = await ArchivoJSON.ReadFromFileAsync<CalificacionDto>(_JSON_CALIFICACIONES);
            var estudiantes = await ArchivoJSON.ReadFromFileAsync<EstudianteEntidad>(_JSON_ESTUDIANTES);
            if (estudiantes.Find(x => x.Id == entidad.IdEstudiante) == null)
            {
                throw new Exception("El id del estudiante no existe!");
            }
            var calificacionCreada = new CalificacionDto() {
                Id = Guid.NewGuid().ToString(),
                Materia = entidad.Materia,
                IdEstudiante = entidad.IdEstudiante,
                Nota = entidad.Nota,
            };
            calificaciones.Add(calificacionCreada);
            await ArchivoJSON.WriteToFileAsync(calificaciones, _JSON_CALIFICACIONES);
            return calificacionCreada;
        }
        public async Task<CalificacionDto> ActualizarAsync(ActualizarCalificacionDto entidad)
        {
            var calificaciones = await ArchivoJSON.ReadFromFileAsync<CalificacionDto>(_JSON_CALIFICACIONES);
            var estudiantes = await ArchivoJSON.ReadFromFileAsync<EstudianteEntidad>(_JSON_ESTUDIANTES);
            var calificacionActualizada = calificaciones.Find(x => x.Id == entidad.Id);
            if (calificacionActualizada == null) 
                throw new Exception("No existe el ID de la calificación");
            if (estudiantes.Find(x => x.Id == entidad.IdEstudiante) == null) 
                throw new Exception("El id del estudiante no existe!");
            calificacionActualizada.IdEstudiante = entidad.IdEstudiante;
            calificacionActualizada.Materia = entidad.Materia;
            calificacionActualizada.Nota = entidad.Nota;
            calificaciones = calificaciones.Select(x => x.Id == calificacionActualizada.Id ? calificacionActualizada : x).ToList();
            await ArchivoJSON.WriteToFileAsync(calificaciones, _JSON_CALIFICACIONES);
            return calificacionActualizada;
        }


        public async Task<CalificacionDto> EliminarAsync(string id)
        {
            var calificaciones = await ArchivoJSON.ReadFromFileAsync<CalificacionDto>(_JSON_CALIFICACIONES);
            var calificacionEliminada = calificaciones.Find(x => x.Id == id);
            if (calificacionEliminada == null)
                throw new Exception("No existe el ID de la calificación");
           calificaciones = calificaciones.Where(x => x.Id != id).ToList();
            await ArchivoJSON.WriteToFileAsync(calificaciones, _JSON_CALIFICACIONES);
            return calificacionEliminada;
        }

        
    }
}
