using Core.Application.Requests;
using MediatR;

namespace Account.Notifications.Application.Features.Notifications.Commands.DeleteByCorrelation;

public class DeleteNotificationsByCorrelationCommand : BaseCommand<Unit>;
