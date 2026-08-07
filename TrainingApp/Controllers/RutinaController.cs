using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Data;
using TrainingApp.DTOs;
using TrainingApp.Models;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RutinaController : ControllerBase
{
    //private static List<Rutina> rutinas = new List<Rutina>();
    private readonly AppDbContext _context;
    public RutinaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Rutina> Get()
    {
        return _context.Rutinas;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_context.Rutinas.FirstOrDefault(r =>  r.Id == id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] RutinaDTO rutina)
    {

        var nuevaRutina = new Rutina
        {
            Nombre = rutina.Nombre,
            Descripcion = rutina.Descripcion,
        };

        _context.Rutinas.Add(nuevaRutina);
        _context.SaveChanges();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var rutina = _context.Rutinas.FirstOrDefault(r => r.Id == id);

        if(rutina == null)
        {
            return NotFound();
        } else
        {
            _context.Rutinas.Remove(rutina);
        }
        _context.SaveChanges();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Rutina rutina)
    {
        var rutinaExistente = _context.Rutinas.FirstOrDefault(r => r.Id == id);
        if(rutinaExistente == null)
        {
            return NotFound();
        } else
        {
            rutinaExistente.Nombre = rutina.Nombre;
        }
        _context.SaveChanges();
        return Ok();    
    }
}
