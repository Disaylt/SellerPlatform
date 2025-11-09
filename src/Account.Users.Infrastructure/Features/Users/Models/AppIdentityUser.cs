using Account.Users.Domain.Entities;
using Account.Users.Domain.Events;
using Core.Abstraction.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
namespace Account.Users.Infrastructure.Features.Users.Models;

public class AppIdentityUser : IdentityUser, INotificationsStore
{
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public AppIdentityUser()
    {
        Id = Guid.NewGuid().ToString();

        var user = new User
        {
            Id = Id,
            Email = Email ?? throw new NullReferenceException($"{nameof(Email)} is null."),
            Name = UserName ?? throw new NullReferenceException($"{nameof(UserName)} is null."),
            Created = Created
        };
        var createdUserEvent = new CreatedUserDomainEvent(user);
        AddNotification(createdUserEvent);
    }

    public IReadOnlyCollection<INotification> Notifications => _notifications;

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
