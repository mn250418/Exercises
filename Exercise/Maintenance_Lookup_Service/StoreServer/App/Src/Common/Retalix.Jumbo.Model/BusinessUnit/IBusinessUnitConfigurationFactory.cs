using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Model.BusinessUnit
{
    public interface IBusinessUnitConfigurationFactory
    {
        IBusinessUnitConfiguration Create(int businessUnitId, string businessUnitName, string businessUnitLocation, string businessUnitAddress);
    }
}
