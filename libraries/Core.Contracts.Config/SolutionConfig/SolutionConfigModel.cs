using Core.Contracts.Config.SolutionConfig.ExternalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts.Config.SolutionConfig;

public class SolutionConfigModel
{
    public ExternalServicesModel ExternalServices { get; set; } = new();
}
