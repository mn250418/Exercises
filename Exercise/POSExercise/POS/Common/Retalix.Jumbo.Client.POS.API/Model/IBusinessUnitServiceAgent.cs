using Retalix.Client.Common.ServiceAgents;
using Retalix.Contracts.Generated.Common;
using Retalix.Jumbo.Contracts.Generated.BusinessUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.Model
{
    public interface IBusinessUnitServiceAgent : IServiceAgent
    {
        string AddorUpdateBusinessUnit(BusinessUnitConfigurationType businessUnitConfigurationType, ActionTypeCodes Action);
    }
}
