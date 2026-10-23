using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TodoLists> TodoLists { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}