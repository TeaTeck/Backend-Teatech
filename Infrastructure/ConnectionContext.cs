using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options)
           : base(options)
        {
        }
        public DbSet<ChildAssisted> ChildAssisteds { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Responsible> Responsibles { get; set; }

    } 
}
