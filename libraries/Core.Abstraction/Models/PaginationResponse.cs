namespace Core.Abstraction.Models;

public class PaginationResponse<T>
{
    public IEnumerable<T> Items { get; init; } = [];
    public long Total { get; init; }
}