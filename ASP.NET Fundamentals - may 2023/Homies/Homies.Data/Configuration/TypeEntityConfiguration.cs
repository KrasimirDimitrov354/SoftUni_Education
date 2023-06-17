namespace Homies.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Homies.Data.Seeder;

using Type = Models.Type;

public class TypeEntityConfiguration : IEntityTypeConfiguration<Type>
{
    private readonly TypeSeeder typeSeeder;

    public TypeEntityConfiguration()
    {
        typeSeeder = new TypeSeeder();
    }

    public void Configure(EntityTypeBuilder<Type> builder)
    {
        builder.HasData(typeSeeder.GenerateTypes());
    }
}
