using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations;

public class DataConfigurations : IEntityTypeConfiguration<Data>
{
    public void Configure(EntityTypeBuilder<Data> builder)
    {
        builder.HasKey(d => d.DataId);

        builder.Property(d => d.EnChars).HasMaxLength(10);
        builder.Property(d => d.RuChars).HasMaxLength(10);
    }
}