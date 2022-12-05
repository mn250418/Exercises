using Retalix.Client.POS.API.Infrastructure.Service;
using Retalix.Jumbo.Client.POS.API.Model.Services;
using Retalix.Jumbo.Contracts.Generated.BusinessUnit;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.Services
{
    [Export(typeof(IBusinessUnitMaintenanceService))]
    class BusinessUnitMaintenanceService : ServiceBase, IBusinessUnitMaintenanceService
    {
        private const string ServiceName = "BusinessUnitConfigurationMaintenance";
        public BusinessUnitConfigurationMaintenanceResponse AddorUpdateBusinessUnit(BusinessUnitConfigurationMaintenanceRequest request)
        {
            return Execute<BusinessUnitConfigurationMaintenanceRequest, BusinessUnitConfigurationMaintenanceResponse>(request, ServiceName);
        }
    }
}
