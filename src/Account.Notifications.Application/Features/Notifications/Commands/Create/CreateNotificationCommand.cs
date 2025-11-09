using Account.Notifications.Application.Features.Notifications.Models;
using Core.Abstraction.Interfaces;
using Core.Application.Interfaces;
using MediatR;

namespace Account.Notifications.Application.Features.Notifications.Commands.Create;

public class CreateNotificationCommand : IRequest<NotificationDto>, ITransactionRequest
{
    public required string UserId { get; set; }
    public string? CorrelationId { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool IsRead { get; set; }
}