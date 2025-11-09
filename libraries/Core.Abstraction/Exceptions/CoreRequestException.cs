using System.Net;

namespace Core.Abstraction.Exceptions;

public class CoreRequestException : Exception
{
    private readonly Dictionary<string, List<string>> _keyAndMessagesPairs = [];

    public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.BadRequest;
    public IReadOnlyDictionary<string, IReadOnlyCollection<string>> KeyAndMessagesPairs =>
        _keyAndMessagesPairs.ToDictionary(
            x => x.Key,
            x => x.Value.ToList().AsReadOnly() as IReadOnlyCollection<string>);

    public CoreRequestException SetStatusCode(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;

        return this;
    }

    public CoreRequestException AddMessages(params string[] messages)
    {
        return AddKeyMessages("Common", messages);
    }

    public CoreRequestException AddKeyMessages(string key, params string[] messages)
    {
        if (_keyAndMessagesPairs.TryAdd(key, [.. messages]) == false)
        {
            _keyAndMessagesPairs[key].AddRange(messages);
        }

        return this;
    }

}