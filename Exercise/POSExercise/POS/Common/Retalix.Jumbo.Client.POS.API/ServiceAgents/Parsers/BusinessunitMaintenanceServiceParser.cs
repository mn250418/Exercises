using Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Parsers;
using Retalix.Jumbo.Contracts.Generated.BusinessUnit;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.ServiceAgents.Parsers
{
    [Export(typeof(IBusinessUnitMaintenanceServiceParser))]
    public class BusinessunitMaintenanceServiceParser : IBusinessUnitMaintenanceServiceParser
    {
        public string Parse(BusinessUnitConfigurationMaintenanceResponse appConfigResponse)
        {
            return appConfigResponse.ToString();
        }
    }
}
