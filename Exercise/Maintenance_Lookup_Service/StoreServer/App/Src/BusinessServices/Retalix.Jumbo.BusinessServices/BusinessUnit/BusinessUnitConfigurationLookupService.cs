using Retalix.Jumbo.BusinessServices.Common;
using Retalix.Jumbo.Contracts.Generated.BusinessUnit;
using Retalix.Jumbo.Model.BusinessUnit;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.BusinessServices.BusinessUnit
{
    [RegisterAddition("BusinessUnitConfigurationLookupService")]
    public class BusinessUnitConfigurationLookupService : BusinessService<BusinessUnitConfigurationLookupRequest, BusinessUnitConfigurationLookupResponse>
    {
        private readonly IBusinessUnitConfigurationProvider _businessUnitConfigurationProvider;

        public BusinessUnitConfigurationLookupService(IBusinessUnitConfigurationProvider businessUnitConfigurationProvider)
        {
            _businessUnitConfigurationProvider = businessUnitConfigurationProvider;
        }

        public override BusinessUnitConfigurationLookupResponse ExecuteService(BusinessUnitConfigurationLookupRequest request)
        {
            var response = new BusinessUnitConfigurationLookupResponse();

            var criteria = CreateCriteria(request);
            IEnumerable<IBusinessUnitConfiguration> businessUnitConfigurations;
            if (criteria != null && criteria.BusinessUnitId!=0 )
            {

                var businessUnitConfiguration = _businessUnitConfigurationProvider.GetUnitConfiguration(criteria.BusinessUnitId);
                businessUnitConfigurations = businessUnitConfiguration;
            }
            else
            {
                businessUnitConfigurations = _businessUnitConfigurationProvider.GetUnitConfigurations(criteria);
            }

            if (businessUnitConfigurations != null)
            {
                var contractUnitConfigurations =
                    businessUnitConfigurations.ToList().ConvertAll(ConvertModelToContract).ToArray();
                response.BusinessUnitConfigurations = contractUnitConfigurations;
            }
            return response;
        }


        private BusinessUnitConfigurationCriteria CreateCriteria(BusinessUnitConfigurationLookupRequest request)
        {
            BusinessUnitConfigurationCriteria criteria = null;

            if (request.SearchCriteria != null)
            {
                criteria = CreateCriteriaFromRequest(request);
            }

            return criteria;
        }

        private BusinessUnitConfigurationCriteria CreateCriteriaFromRequest(
            BusinessUnitConfigurationLookupRequest request)
        {
            return new BusinessUnitConfigurationCriteria
            {
                BusinessUnitId = request.SearchCriteria.BusinessUnitId
            };
        }

        private static BusinessUnitConfigurationType ConvertModelToContract(
            IBusinessUnitConfiguration businessUnitConfiguration)
        {
            return new BusinessUnitConfigurationType
            {
                BusinessUnitId = businessUnitConfiguration.BusinessUnitId,
                BusinessUnitName = businessUnitConfiguration.BusinessUnitName,
                BusinessUnitLocation = businessUnitConfiguration.BusinessUnitLocation,
                BusinessUnitAddress = businessUnitConfiguration.BusinessUnitAddress
            };
        }
    }
}
