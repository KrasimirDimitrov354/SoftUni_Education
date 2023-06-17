namespace Homies.Data.Seeder;

using Type = Models.Type;

internal class TypeSeeder
{
    internal Type[] GenerateTypes()
    {
        ICollection<Type> types = new HashSet<Type>();

        Type type;

        type = new Type()
        {
            Id = 1,
            Name = "Animals"
        };
        types.Add(type);

        type = new Type()
        {
            Id = 2,
            Name = "Fun"
        };
        types.Add(type);

        type = new Type()
        {
            Id = 3,
            Name = "Discussion"
        };
        types.Add(type);

        type = new Type()
        {
            Id = 4,
            Name = "Work"
        };
        types.Add(type);

        return types.ToArray();
    }
}
