using Common.Logging;
using Retalix.Client.Common.Log;
using Retalix.Client.Common.ServiceAgents;
using Retalix.Client.POS.BusinessObjects.ServiceAgents;
using Retalix.Contracts.Generated.Common;
using Retalix.Jumbo.Client.POS.API.Model;
using Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Builders;
using Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Parsers;
using Retalix.Jumbo.Client.POS.API.Model.Services;
using Retalix.Jumbo.Contracts.Generated.BusinessUnit;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.ServiceAgents
{
    [Export(typeof(IServiceAgent))]
    [Export(typeof(IBusinessUnitServiceAgent))]
    public class BusinessUnitServiceAgent : ServiceAgentBase, IBusinessUnitServiceAgent
    {
        private static readonly ILog Log = ClientLog.ClientBusinessFlows;

        [Import]
        private IBusinessUnitMaintenanceService _service;

        public string AddorUpdateBusinessUnit(BusinessUnitConfigurationType businessUnitConfigurationType, ActionTypeCodes Action)
        {
            Log.DebugFormat("BusinessUnitMaintenanceServiceAgent.Execute:Start");

            var requestBuilder = Resolver.Resolve<IBusinessUnitMaintenanceServiceBuilder>();

            var request = requestBuilder.Build(businessUnitConfigurationType, Action);

            var response = _service.AddorUpdateBusinessUnit(request);

            var parser = Resolver.Resolve<IBusinessUnitMaintenanceServiceParser>();

            var configValue = parser.Parse(response);


            Log.DebugFormat("BusinessUnitMaintenanceServiceAgent.Execute:End");
            return configValue;
        }
    }
}
