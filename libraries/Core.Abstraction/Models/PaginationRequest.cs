namespace Core.Abstraction.Models
{
    public record PaginationRequest
    {
        public int Take { get; init; } = 20;
        public int Skip { get; init; } = 0;
    }
}
