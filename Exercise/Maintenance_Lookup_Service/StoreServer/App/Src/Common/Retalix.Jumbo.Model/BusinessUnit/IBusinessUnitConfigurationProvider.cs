using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Model.BusinessUnit
{
    public interface IBusinessUnitConfigurationProvider
    {
        /// <summary>
        /// Gets Business Unit Configurations for the given criteria
        /// </summary>
        /// <returns></returns>
        IEnumerable<IBusinessUnitConfiguration> GetUnitConfigurations(BusinessUnitConfigurationCriteria criteria);

        /// <summary>
        /// Gets Unit Configuration value for the given BusinessUnitId
        /// </summary>
        /// <returns></returns>
        IEnumerable<IBusinessUnitConfiguration> GetUnitConfiguration(int businessUnitId);
    }
}
