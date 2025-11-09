using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts.Config.SolutionConfig.ExternalServices.Account;

namespace Core.Contracts.Config.SolutionConfig.ExternalServices;

public class ExternalServicesModel
{
    public AccountModel Account { get; set; } = new();
}
