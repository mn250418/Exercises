using Retalix.Jumbo.Model.BusinessUnit;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Model.Infrastructure.DataMovement.Versioning;
using Retalix.StoreServices.Model.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.ConnectivityServices.BusinessUnit.DMS
{
    public class BusinessUnitConfigurationEntityToDtoMapper : IEntityToDtoMapper
    {
        private const string OldVersion = "2.0.0";

        public DtosForVersions[] Map(IMovable[] movables, MappingMetadata mappingMetadata, DataChangeType changeType)
        {
            var newVersions = mappingMetadata.TargetNodesVersion.Where(o => !o.StartsWith(OldVersion)).ToArray();
            if (newVersions.Any())
                return CreateDtosForVersions(movables.OfType<IBusinessUnitConfiguration>(), newVersions);

            return new DtosForVersions[0];
        }

        private static DtosForVersions[] CreateDtosForVersions(IEnumerable<IBusinessUnitConfiguration> movables, IEnumerable<string> newVersions)
        {
            return new[]
                       {
                           new DtosForVersions
                               {
                                   Dtos = movables.Select(CreateDto).ToArray(),
                                   Versions = newVersions.ToArray(),
                               }
                       };
        }

        private static INamedObject CreateDto(IBusinessUnitConfiguration movable)
        {
            return new BusinessUnitConfiguration
            {
                BusinessUnitId = movable.BusinessUnitId,
                BusinessUnitName = movable.BusinessUnitName,
                BusinessUnitLocation = movable.BusinessUnitLocation,
                BusinessUnitAddress = movable.BusinessUnitAddress
            };
        }

        public IMovable[] MapBack(INamedObject[] dtos, MappingMetadata mappingMetadata, DataChangeType changeType)
        {

            return dtos.Select(CreateMovable).ToArray();
        }

        private static IMovable CreateMovable(INamedObject dtos)
        {
            var item = dtos as BusinessUnitConfiguration;
            if (item != null)
            {
                return new BusinessUnitConfiguration
                {
                    BusinessUnitId = item.BusinessUnitId,
                    BusinessUnitName = item.BusinessUnitName,
                    BusinessUnitLocation = item.BusinessUnitLocation,
                    BusinessUnitAddress = item.BusinessUnitAddress
                };
            }
            return null;
        }

        public string[] GetEntityNamesForVersion(string entityName, MappingMetadata mappingMetadata, DataChangeType changeType)
        {
            return new[] { "BusinessUnitConfiguration" };
        }

        public Type GetNamedObjectType(string entityName, MappingMetadata mappingMetadata)
        {
            return typeof(BusinessUnitConfiguration);
        }
    }
}
