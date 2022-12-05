using Common.Logging;
using Retalix.Jumbo.Model.BusinessUnit;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using Retalix.StoreServices.Model.Infrastructure.StoreApplication;
using Retalix.StoreServices.Model.Organization.BusinessUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.BusinessComponents.BusinessUnit.BusinessUnitConfiguration
{
    [RegisterAddition("BusinessUnitConfigurationProvider")]
    public class BusinessUnitConfigurationProvider : IBusinessUnitConfigurationProvider
    {
        private readonly IBusinessUnitConfigurationDao _businessUnitConfigurationDao;
        private readonly IStoreNetRequest _storeNetRequest;
        private readonly IBusinessUnitDao _businessUnitDao;
        private readonly ILog _logger;

        public BusinessUnitConfigurationProvider(
            IBusinessUnitConfigurationDao businessUnitConfigurationDao, IStoreNetRequest storeNetRequest,
            IBusinessUnitDao businessUnitDao)
        {
            _businessUnitConfigurationDao = businessUnitConfigurationDao;
            _logger = LogManager.GetCurrentClassLogger();
            _businessUnitDao = businessUnitDao;
            _storeNetRequest = storeNetRequest;
        }

        public IEnumerable<IBusinessUnitConfiguration> GetUnitConfigurations(BusinessUnitConfigurationCriteria criteria)
        {
            return GetAllUnitConfigurations(criteria);
        }


        //private IEnumerable<IBusinessUnitConfiguration> GetUnitConfiguration(
        //    BusinessUnitConfigurationCriteria criteria)
        //{
        //    IEnumerable<IBusinessUnitConfiguration> touchpointConfigurations = new List<IBusinessUnitConfiguration> { };

        //    //while (businessUnit != null)
        //    //{
        //        //criteria.BusinessUnitId = businessUnit.Id;
        //        touchpointConfigurations = _businessUnitConfigurationDao.GetByCriteria(criteria);

        //        if (touchpointConfigurations.Any())
        //            return touchpointConfigurations;

        //        //businessUnit = businessUnit.ParentUnit;
        //    //}
        //    return touchpointConfigurations;
        //}

        private IEnumerable<IBusinessUnitConfiguration> GetAllUnitConfigurations(BusinessUnitConfigurationCriteria criteria)
        {
            BusinessUnitConfigurationCriteria businessUnitConfigurationCriteria = new BusinessUnitConfigurationCriteria
            {
                BusinessUnitId = criteria.BusinessUnitId
            };
            List<IBusinessUnitConfiguration> allUnitConfigurations = _businessUnitConfigurationDao.GetAllBusinessServiceForAllBusinessUnitId(businessUnitConfigurationCriteria);

            List<IBusinessUnitConfiguration> touchpointConfigurations = new List<IBusinessUnitConfiguration>();

            if (allUnitConfigurations != null)
            {
                List<IBusinessUnitConfiguration> businessUnitList;
                if (criteria.BusinessUnitId == 0)
                {
                    businessUnitList = allUnitConfigurations.ToList();
                }
                else
                {
                    businessUnitList = allUnitConfigurations.Where(o => o.BusinessUnitId == criteria.BusinessUnitId).ToList();
                }
                
                businessUnitList.ForEach(configuration => AddUnitConfigurationToFinalList(touchpointConfigurations, configuration));

            }

            return touchpointConfigurations;
        }

        private static void AddUnitConfigurationToFinalList(List<IBusinessUnitConfiguration> touchpointConfigurations,
            IBusinessUnitConfiguration businessUnitConfiguration)
        {
            if (touchpointConfigurations.Any(o => o.BusinessUnitId == businessUnitConfiguration.BusinessUnitId 
                && o.BusinessUnitName == businessUnitConfiguration.BusinessUnitName
                && o.BusinessUnitLocation == businessUnitConfiguration.BusinessUnitLocation
                && o.BusinessUnitAddress == businessUnitConfiguration.BusinessUnitAddress)) return;

            touchpointConfigurations.Add(businessUnitConfiguration);
        }

        public IEnumerable<IBusinessUnitConfiguration> GetUnitConfiguration(int businessUnitId)
        {
            BusinessUnitConfigurationCriteria criteria = BuildCriteria(businessUnitId);
            return GetTouchpointConfigurationValue(criteria);
        }

        private IEnumerable<IBusinessUnitConfiguration> GetTouchpointConfigurationValue(BusinessUnitConfigurationCriteria criteria)
        {
            var touchpointConfigurations = GetUnitConfigurations(criteria);
            if (touchpointConfigurations == null || !touchpointConfigurations.Any())
            {
                //throw new Exception(criteria);
            }

            return touchpointConfigurations;
        }

        private BusinessUnitConfigurationCriteria BuildCriteria(int businessUnitId)
        {
            BusinessUnitConfigurationCriteria criteria = new BusinessUnitConfigurationCriteria();
            criteria.BusinessUnitId = businessUnitId;
            return criteria;
        }
    }
}
