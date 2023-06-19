using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniqueFundraisingEvent.Web.Domain.Entities;

namespace UniqueFundraisingEvent.Web.Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Guest>? Guest { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}