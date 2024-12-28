using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions options) : base(options) { }

       public DbSet<Tarefa> Tarefas { get; set; }
    }
}
