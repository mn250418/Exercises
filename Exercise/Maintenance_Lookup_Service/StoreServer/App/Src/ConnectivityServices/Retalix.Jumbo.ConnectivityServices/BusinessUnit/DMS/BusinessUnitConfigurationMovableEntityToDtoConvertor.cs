using Retalix.Jumbo.Model.BusinessUnit;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Model.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.ConnectivityServices.BusinessUnit.DMS
{
    public class BusinessUnitConfigurationMovableEntityToDtoConvertor : IBusinessUnitConfigurationMovableEntityToDtoConvertor
    {
        public IMovable[] MapBackFromDto(IEnumerable<INamedObject> dtos, DataChangeType changeType)
        {
            if (dtos == null)
                return Enumerable.Empty<IMovable>() as IMovable[];

            return dtos.Cast<BusinessUnitConfiguration>().Select(ToMovable).ToArray();
        }

        public INamedObject[] MapToDto(IEnumerable<IMovable> movables, DataChangeType changeType)
        {
            if (movables == null)
                return Enumerable.Empty<INamedObject>() as INamedObject[];

            return movables.Select(ToDTO).ToArray();
        }

        protected IMovable ToMovable(BusinessUnitConfiguration dto)
        {
            return dto;
        }

        protected BusinessUnitConfiguration ToDTO(IMovable movable)
        {
            var dto = movable as BusinessUnitConfiguration;
            return dto;
        }

        public Type DtoType()
        {
            return typeof(BusinessUnitConfiguration);
        }
    }
}
