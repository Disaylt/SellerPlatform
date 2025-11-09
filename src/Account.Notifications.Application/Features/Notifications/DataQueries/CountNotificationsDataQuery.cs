using Account.Notifications.Application.Features.Notifications.Models;
using Core.Abstraction.Interfaces;

namespace Account.Notifications.Application.Features.Notifications.DataQueries;

public record CountNotificationsDataQuery : IDataQuery<long>
{
    public NotificationFilterModel? Filter { get; set; }
}