using IdClaimsPractice3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdClaimsPractice3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Products> Products { get; set; } = null!;
        public DbSet<Department> Department { get; set; } = null!;
        public DbSet<Employee> Employee { get; set; } = null!;
        public DbSet<Location> Location { get; set; } = null!;
        public DbSet<Machine> Machine { get; set; } = null!;
        //public DbSet<Permission> Permission { get; set; }

      
    }
}
