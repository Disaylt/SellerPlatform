using MediatR;

namespace Core.Abstraction.Interfaces;

public interface INotificationsStore
{
    IReadOnlyCollection<INotification> Notifications { get; }
    void AddNotification(INotification notification);
    void RemoveNotification(INotification notification);
    void ClearNotifications();
}
