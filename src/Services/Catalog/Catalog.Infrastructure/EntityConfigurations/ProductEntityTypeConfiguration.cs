namespace Catalog.Infrastructure.EntityConfigurations;

class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> productConfiguration)
    {
        productConfiguration.ToTable("products");

        productConfiguration.HasKey(o => o.Id);

        productConfiguration.Ignore(b => b.DomainEvents);

        productConfiguration.Property(o => o.Id)
            .ValueGeneratedOnAdd();

        productConfiguration
            .Property<string>("_name")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Name")
            .IsRequired();

        productConfiguration
            .Property<decimal>("_price")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Price")
            .IsRequired();

        productConfiguration.Property<string>("_description")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Description")
            .IsRequired(false);

        productConfiguration.Property<int?>("_categoryId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("CategoryId")
            .IsRequired(false);

        productConfiguration
            .Property<DateTime>("_createdAt")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("CreatedAt")
            .IsRequired();
        
    }
}
