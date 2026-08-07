using System.ComponentModel.DataAnnotations;

namespace TrainingApp.DTOs
{
    public class EjercicioDTO
    {
        [Required]
        public string? Nombre { get; set; }  
        public float Kilogramo { get; set; }
        public int Series {  get; set; }
        public int Repeticiones { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int RutinaId { get; set; }

    }
}
