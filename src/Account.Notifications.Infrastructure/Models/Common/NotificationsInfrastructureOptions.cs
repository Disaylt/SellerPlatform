using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Notifications.Infrastructure.Models.Common
{
    public class NotificationsInfrastructureOptions
    {
        public MongoDb MongoDb { get; set; } = new();
    }

    public class MongoDb
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
