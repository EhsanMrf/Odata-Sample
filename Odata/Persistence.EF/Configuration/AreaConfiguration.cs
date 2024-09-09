using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EF.Configuration;

public class AreaConfiguration :IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder.ToTable("Area");
        builder.Property(t => t.Title).HasMaxLength(50);
        builder.Property(t => t.Code);

        builder.Property(x => x.CreatedOn).HasColumnName("CreatedDate");
        builder.Property(x => x.ModifiedOn).HasColumnName("ModifiedDate");

        builder.HasQueryFilter(x => x.IsDeleted == false);
    }
}