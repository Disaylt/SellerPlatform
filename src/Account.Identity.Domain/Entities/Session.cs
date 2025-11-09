using Core.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Identity.Domain.Entities;

public class Session : BaseEntity
{
    public required string Id { get; set; }
    public required string UserId { get; set; }
    public DateTime LastUse { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; }
}
