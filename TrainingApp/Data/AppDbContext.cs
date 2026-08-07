using Microsoft.EntityFrameworkCore;
using TrainingApp.Models;

namespace TrainingApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Rutina> Rutinas { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 

        }

    }
}
