using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts.Config.Common
{
    public class GrpcServiceConfig
    {
        public IList<string> Addresses { get; set; } = [];
    }
}
