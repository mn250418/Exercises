using Retalix.Jumbo.Model.BusinessUnit;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.ConnectivityServices.BusinessUnit.DMS
{
    [RegisterAddition]
    class BusinessUnitConfigurationFactory : IBusinessUnitConfigurationFactory
    {
        public IBusinessUnitConfiguration Create(int businessUnitId, string businessUnitName, string businessUnitLocation, string businessUnitAddress)
        {
            return new BusinessUnitConfiguration
            {
                BusinessUnitId = businessUnitId,
                BusinessUnitName = businessUnitName,
                BusinessUnitLocation = businessUnitLocation,
                BusinessUnitAddress = businessUnitAddress
            };
        }
    }
}
