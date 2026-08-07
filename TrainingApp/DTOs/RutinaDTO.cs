using System.ComponentModel.DataAnnotations;

namespace TrainingApp.DTOs
{
    public class RutinaDTO
    {
        [Required]
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

    }
}
