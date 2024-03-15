using Microsoft.EntityFrameworkCore;
using WebApplication1.Infrastructure;
using WebApplication1.Models;

namespace WebApplication1.Infrastructure
{
    public class ConnectionContextUser : DbContext
    {
    public ConnectionContextUser(DbContextOptions<ConnectionContextUser> options)
       : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

}
}
