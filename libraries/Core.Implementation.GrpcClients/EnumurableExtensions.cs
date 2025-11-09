namespace Core.Implementation.GrpcClients;

internal static class EnumurableExtensions
{
    public static T GetRandom<T>(this IEnumerable<T> values)
    {
        int total = values.Count();

        if (total == 0) throw new ArgumentException($"List type:{typeof(T).FullName} is empty");

        int index = Random.Shared.Next(total);

        return values.Skip(index).First();
    }
}
