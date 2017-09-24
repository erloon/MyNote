using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Mappings
{
    public class ApplicationUserMapping: IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> entityTypeBuilder)
        {
            
        }
    }
}