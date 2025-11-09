using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstraction.Models
{
    public class MessageEvent : BaseEntity
    {
        public string Id { get; set; } = null!;
        public required string Type { get; set; }
        public required string ContractName { get; set; }
        public string? Payload { get; set; }
        public int Attempts { get; set; }
        public DateTime? SendDate { get; set; }
    }
}
