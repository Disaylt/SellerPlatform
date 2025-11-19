using Microsoft.EntityFrameworkCore;

namespace Core.Implementation.EntityFramework.Implementation;

public class DomainDeletedEventRecord<T>
    : DomainBaseEventRecord<T>
    where T : class
{
    public override EntityState State => EntityState.Deleted;
}
