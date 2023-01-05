using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.EntityConfigurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> categoryConfiguration)
        {
            categoryConfiguration.ToTable("categories");

            categoryConfiguration.HasKey(o => o.Id);

            categoryConfiguration.Ignore(b => b.DomainEvents);

            categoryConfiguration.Property(o => o.Id)
                .ValueGeneratedOnAdd();

            categoryConfiguration
                .Property<string>("_name")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Name")
                .IsRequired();

            categoryConfiguration
                .Property<string>("_description")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Description")
                .IsRequired(false);

            categoryConfiguration
                .Property<DateTime>("_createdAt")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CreatedAt")
                .IsRequired();

        }
    }
}
