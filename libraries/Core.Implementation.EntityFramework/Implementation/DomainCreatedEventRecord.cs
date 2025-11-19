using Core.Abstraction.Models;
using Core.Implementation.EntityFramework.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Implementation.EntityFramework.Implementation;

public class DomainCreatedEventRecord<T>
    : DomainBaseEventRecord<T>
    where T : class
{
    public override EntityState State => EntityState.Added;
}
