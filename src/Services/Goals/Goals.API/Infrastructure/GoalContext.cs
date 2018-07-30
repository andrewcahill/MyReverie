using Microsoft.EntityFrameworkCore;
using Goals.API.Model;
namespace Goals.API.Infrastructure
{
    public class GoalContext : DbContext
    {
        public GoalContext(DbContextOptions<GoalContext> options) : base(options)
        {
        }

        public DbSet<Goal> Goals { get; set; }
    }
}
