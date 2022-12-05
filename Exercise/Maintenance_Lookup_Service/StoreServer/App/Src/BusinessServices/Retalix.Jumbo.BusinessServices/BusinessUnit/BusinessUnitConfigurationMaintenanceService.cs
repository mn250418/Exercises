using Retalix.Contracts.Generated.Common;
using Retalix.Jumbo.BusinessServices.Common;
using Retalix.Jumbo.Contracts.Generated.BusinessUnit;
using Retalix.Jumbo.Model.BusinessUnit;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using Retalix.StoreServices.Model.Customer.Legacy.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.BusinessServices.BusinessUnit
{
    [RegisterAddition("BusinessUnitConfigurationMaintenanceService")]
    public class BusinessUnitConfigurationMaintenanceService : BusinessService<BusinessUnitConfigurationMaintenanceRequest, BusinessUnitConfigurationMaintenanceResponse>
    {
        private readonly IBusinessUnitConfigurationDao _businessUnitConfigurationDao;
        private readonly IBusinessUnitConfigurationFactory _businessUnitConfigurationFactory;

        public BusinessUnitConfigurationMaintenanceService(
            IBusinessUnitConfigurationDao businessUnitConfigurationDao, IBusinessUnitConfigurationFactory businessUnitConfigurationFactory)
        {
            _businessUnitConfigurationDao = businessUnitConfigurationDao;
            _businessUnitConfigurationFactory = businessUnitConfigurationFactory;
        }

        public override BusinessUnitConfigurationMaintenanceResponse ExecuteService(BusinessUnitConfigurationMaintenanceRequest request)
        {
            HandleBusinessUnitConfigurationMaintenanceAction(request);

            return new BusinessUnitConfigurationMaintenanceResponse();
        }

        private void HandleBusinessUnitConfigurationMaintenanceAction(BusinessUnitConfigurationMaintenanceRequest businessUnitConfigurationMaintenanceRequest)
        {
            switch (businessUnitConfigurationMaintenanceRequest.Action)
            {
                case ActionTypeCodes.Add:
                case ActionTypeCodes.Update:
                case ActionTypeCodes.AddUpdate:
                case ActionTypeCodes.AddOrUpdate:
                    ExecuteAddOrUpdateAction(businessUnitConfigurationMaintenanceRequest);
                    break;
                case ActionTypeCodes.Delete:
                    ExecuteDeleteAction(businessUnitConfigurationMaintenanceRequest);
                    break;
            }
        }

        private void ExecuteAddOrUpdateAction(BusinessUnitConfigurationMaintenanceRequest businessUnitConfigurationMaintenanceRequest)
        {
            foreach (var configuration in businessUnitConfigurationMaintenanceRequest.BusinessUnitConfiguration)
            {
                ValidateRequest(configuration);
                var configurationModel = ConvertContractToModel(configuration);
                _businessUnitConfigurationDao.SaveOrUpdate(configurationModel);
            }
        }

        private void ExecuteDeleteAction(BusinessUnitConfigurationMaintenanceRequest businessUnitConfigurationMaintenanceRequest)
        {
            foreach (var configuration in businessUnitConfigurationMaintenanceRequest.BusinessUnitConfiguration)
            {
                if (configuration.BusinessUnitId == 0)
                    throw new MissingMandatoryFieldException(PropertyResolver.GetName<BusinessUnitConfigurationType>(u => u.BusinessUnitId));
                var configurationModel = ConvertContractToModel(configuration);
                _businessUnitConfigurationDao.Delete(configurationModel);
            }
        }

        private void ValidateRequest(BusinessUnitConfigurationType businessUnitConfigurationType)
        {
            if (businessUnitConfigurationType == null) throw new ArgumentNullException("businessUnitConfigurationType");

            if (string.IsNullOrEmpty(businessUnitConfigurationType.BusinessUnitId.ToString()))
                throw new MissingMandatoryFieldException(PropertyResolver.GetName<BusinessUnitConfigurationType>(u => u.BusinessUnitId));

            if (string.IsNullOrEmpty(businessUnitConfigurationType.BusinessUnitName))
                throw new MissingMandatoryFieldException(PropertyResolver.GetName<BusinessUnitConfigurationType>(u => u.BusinessUnitName));

            if (string.IsNullOrEmpty(businessUnitConfigurationType.BusinessUnitLocation))
                throw new MissingMandatoryFieldException(PropertyResolver.GetName<BusinessUnitConfigurationType>(u => u.BusinessUnitLocation));
        }

        private IBusinessUnitConfiguration ConvertContractToModel(BusinessUnitConfigurationType businessUnitConfigurationType)
        {
            return _businessUnitConfigurationFactory.Create(businessUnitConfigurationType.BusinessUnitId,
                businessUnitConfigurationType.BusinessUnitName, businessUnitConfigurationType.BusinessUnitLocation,
                businessUnitConfigurationType.BusinessUnitAddress);

        }
    }
}
