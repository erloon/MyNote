using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyNote.Identity.Domain.Mappings;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IContext<ApplicationDbContext>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base((DbContextOptions) (DbContextOptions) options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
        public DbSet<Resource> Resources { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AddressMapping());
            builder.ApplyConfiguration(new CompanyMapping());
            builder.ApplyConfiguration(new OrganizationMapping());
            builder.ApplyConfiguration(new ProjectMapping());
            builder.ApplyConfiguration(new TeamMapping());
            builder.ApplyConfiguration(new UserProjrctMapping());
            builder.ApplyConfiguration(new UserTeamMapping());
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}