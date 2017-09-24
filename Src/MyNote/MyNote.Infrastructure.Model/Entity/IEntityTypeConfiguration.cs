using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyNote.Infrastructure.Model.Entity
{
    public interface IEntityTypeConfiguration<TEntity> where TEntity: class 
    {
        void Configure(EntityTypeBuilder<TEntity> entityTypeBuilder);
    }
}