namespace Account.Notifications.Infrastructure.Features.Notifications.Utilities.Abstraction;

public interface INotificationUtilitiesFactory
{
    INotificationFilterUtility CreateFilterUtility();
}