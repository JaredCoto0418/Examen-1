using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos.Calificacion
{
    public class ActualizarCalificacionDto
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public string Id { get; set; }

        [Display(Name = "Materia")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public string Materia { get; set; }

        [Display(Name = "Nota")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        [Range(0, 10, ErrorMessage = "La {0} debe estar entre {1} y {2}.")]
        public double Nota { get; set; }

        [Display(Name = "IdEstudiante")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public string IdEstudiante { get; set; }
    }
}
