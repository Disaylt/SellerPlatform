using Core.Abstraction.Interfaces;
using MediatR;

namespace Core.Abstraction.Models;

public abstract class BaseEntity : INotificationsStore
{
    public IReadOnlyCollection<INotification> Notifications => _notifications;
    public DateTime Updated { get; set; } = DateTime.UtcNow;
    public DateTime Created { get; private set; } = DateTime.UtcNow;
    public string? CorrelationId { get; set; }


    private readonly List<INotification> _notifications = [];


    public void AddNotification(INotification notification)
    {
        _notifications.Add(notification);
    }

    public void RemoveNotification(INotification notification)
    {
        _notifications.Remove(notification);
    }

    public void ClearNotifications()
    {
        _notifications.Clear();
    }
}