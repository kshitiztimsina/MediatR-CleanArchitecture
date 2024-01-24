using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Context
{
    public class AppDbContext : DbContext
    {
        public  AppDbContext(DbContextOptions options) : base(options) { 
        }
        public DbSet<Person> person { get; set; }
    }
}
