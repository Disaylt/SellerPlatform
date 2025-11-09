using Account.Notifications.Infrastructure.Features.Notifications.Utilities.Abstraction;

namespace Account.Notifications.Infrastructure.Features.Notifications.Utilities.Implementation;

public class NotificationUtilitiesFactory(
    Func<INotificationFilterUtility> notificationFilterUtilityCreator)
    : INotificationUtilitiesFactory
{
    public INotificationFilterUtility CreateFilterUtility() => notificationFilterUtilityCreator();
}