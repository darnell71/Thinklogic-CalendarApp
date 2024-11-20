using Microsoft.EntityFrameworkCore;

namespace CalendarApp.Models
{
    public class CalendarDbContext : DbContext
    {
        public CalendarDbContext(DbContextOptions<CalendarDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}
