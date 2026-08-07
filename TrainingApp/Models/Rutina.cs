namespace TrainingApp.Models
{
    public class Rutina
    {
        public int Id {  get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set;}
        
        public List<Ejercicio>? Ejercicios { get; set; }
    }
}

