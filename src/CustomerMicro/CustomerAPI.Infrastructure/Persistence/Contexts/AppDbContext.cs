using CustomerAPI.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CustomerAPI.Infrastructure.Persistence.Contexts
{
    public class AppDbContext : IdentityDbContext<Customer, CustomerRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
