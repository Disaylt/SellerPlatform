using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Implementation.MongoDbDriver.Models
{
    public class MongoDatabaseOptions
    {
        internal string ConnectionSting { get; private set; } = string.Empty;
        internal string Database { get; private set; } = string.Empty;

        public void SetConnection(string connection)
        {
            ConnectionSting = connection;
        }

        public void SetDatabaseName(string name)
        {
            Database = name;
        }
    }
}
