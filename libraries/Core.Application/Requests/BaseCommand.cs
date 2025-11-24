using MediatR;

namespace Core.Application.Requests;

public abstract class BaseCommand<T> : BaseRequest<T>;
