using Retalix.Contracts.Generated.Common;
using Retalix.Jumbo.Contracts.Generated.BusinessUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Builders
{
    public interface IBusinessUnitMaintenanceServiceBuilder
    {
        BusinessUnitConfigurationMaintenanceRequest Build(BusinessUnitConfigurationType businessUnitConfigurationType, ActionTypeCodes Action);
    }
}
