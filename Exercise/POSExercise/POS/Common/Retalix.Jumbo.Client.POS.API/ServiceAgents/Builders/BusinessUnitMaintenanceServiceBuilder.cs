using Retalix.Client.POS.BusinessObjects.ServiceAgents;
using Retalix.Contracts.Generated.Common;
using Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Builders;
using Retalix.Jumbo.Contracts.Generated.BusinessUnit;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.ServiceAgents.Builders
{
    [Export(typeof(IBusinessUnitMaintenanceServiceBuilder))]
    class BusinessUnitMaintenanceServiceBuilder : ServiceAgentBase, IBusinessUnitMaintenanceServiceBuilder
    {
        public BusinessUnitConfigurationMaintenanceRequest Build(BusinessUnitConfigurationType businessUnitConfigurationType, ActionTypeCodes Action)
        {
            BusinessUnitConfigurationType[] result = new BusinessUnitConfigurationType[] {
                new BusinessUnitConfigurationType
                {
                    BusinessUnitId = businessUnitConfigurationType.BusinessUnitId,
                    BusinessUnitName = businessUnitConfigurationType.BusinessUnitName,
                    BusinessUnitLocation = businessUnitConfigurationType.BusinessUnitLocation,
                    BusinessUnitAddress = businessUnitConfigurationType.BusinessUnitAddress
                }
            };



            return new BusinessUnitConfigurationMaintenanceRequest
            {
                Header = new RetalixCommonHeaderType(),
                BusinessUnitConfiguration = result
            };
        }
    }
}
