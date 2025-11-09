namespace Core.Abstraction.Interfaces
{
    public interface IDataQueryHandler<in TQuery, TData>
        where TQuery : IDataQuery<TData>
    {
        Task<TData> ExecuteAsync(TQuery queryData, CancellationToken ct);
    }
}
