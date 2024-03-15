using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Infrastructure
{
    public class ConnectionContextResponsible :DbContext
    {
        public ConnectionContextResponsible(DbContextOptions<ConnectionContextResponsible> options)
           : base(options)
        {
        }

        public DbSet<Responsible> Responsibles { get; set; }

        
    }
}
