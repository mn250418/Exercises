using Retalix.Jumbo.Contracts.Generated.BusinessUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Parsers
{
    public interface IBusinessUnitMaintenanceServiceParser
    {
        string Parse(BusinessUnitConfigurationMaintenanceResponse appConfigResponse);
    }
}
