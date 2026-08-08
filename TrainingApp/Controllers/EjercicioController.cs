using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Data;
using TrainingApp.DTOs;
using TrainingApp.Models;


namespace TrainingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EjercicioController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EjercicioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Ejercicio> Get()
        {
            return _context.Ejercicios;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.Ejercicios.FirstOrDefault(e => e.Id == id));    
        }

        [HttpPost]
        public IActionResult Post([FromBody] EjercicioDTO ejercicio)
        {
            var nuevoEjercicio = new Ejercicio
            {
                Nombre = ejercicio.Nombre,
                Kilogramo = ejercicio.Kilogramo,
                Series = ejercicio.Series,
                Repeticiones = ejercicio.Repeticiones,
                RutinaId = ejercicio.RutinaId
            };

            _context.Add(nuevoEjercicio);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ejercicioEliminar = _context.Ejercicios.FirstOrDefault(e => e.Id == id);

            if(ejercicioEliminar == null)
            {
                return NotFound();
            } else
            {
                _context.Ejercicios.Remove(ejercicioEliminar); 
            }
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Ejercicio ejercicio)
        {
            var ejercicioModificar = _context.Ejercicios.FirstOrDefault(e => e.Id == id);

            if(ejercicioModificar == null)
            {
                return NotFound();
            }
            else
            {
                ejercicioModificar.Nombre = ejercicio.Nombre;
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
