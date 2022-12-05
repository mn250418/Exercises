using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Model.BusinessUnit
{
    public interface IBusinessUnitConfigurationDao : IMovableDao
    {
        void SaveOrUpdate(IBusinessUnitConfiguration businessUnitConfiguration);
        void Delete(IBusinessUnitConfiguration businessUnitConfiguration);
        IEnumerable<IBusinessUnitConfiguration> GetByCriteria(BusinessUnitConfigurationCriteria criteria);
        List<IBusinessUnitConfiguration> GetAllBusinessServiceForAllBusinessUnitId(BusinessUnitConfigurationCriteria searchingCriteria);
    }
}
