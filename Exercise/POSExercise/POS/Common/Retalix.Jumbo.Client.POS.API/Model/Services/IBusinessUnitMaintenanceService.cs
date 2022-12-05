using Retalix.Jumbo.Contracts.Generated.BusinessUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.Model.Services
{
    public interface IBusinessUnitMaintenanceService
    {
        BusinessUnitConfigurationMaintenanceResponse AddorUpdateBusinessUnit(BusinessUnitConfigurationMaintenanceRequest request);
    }
}
