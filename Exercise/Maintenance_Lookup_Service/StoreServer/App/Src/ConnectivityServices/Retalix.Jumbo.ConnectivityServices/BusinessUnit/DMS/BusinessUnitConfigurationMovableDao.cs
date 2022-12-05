using Common.Logging;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using Retalix.Jumbo.Common.Utils;
using Retalix.Jumbo.Model.BusinessUnit;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using Retalix.StoreServices.Infrastructure.Cache;
using Retalix.StoreServices.Model.Infrastructure.DataAccess;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Model.Infrastructure.DataMovement.DeleteAllProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.ConnectivityServices.BusinessUnit
{
    [RegisterAddition]
    public class BusinessUnitConfigurationMovableDao : IBusinessUnitConfigurationDao
    {
        protected static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private const string BusinessUnitConfigurationKey = "BusinessUnitConfiguration";

        private readonly ISessionProvider _sessionProvider;

        public BusinessUnitConfigurationMovableDao(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        private ISession Session
        {
            get { return _sessionProvider.GetDefaultSession<ISession>(); }
        }

        public void SaveOrUpdate(IBusinessUnitConfiguration businessUnitPointConfiguration)
        {
            Session.SaveOrUpdate(businessUnitPointConfiguration);
            CleanCache();
        }

        public void Delete(IBusinessUnitConfiguration businessUnitConfiguration)
        {
            CleanCache();
            Session.Delete(businessUnitConfiguration);
        }

        public IEnumerable<IBusinessUnitConfiguration> GetByCriteria(BusinessUnitConfigurationCriteria searchingCriteria)
        {
            if (searchingCriteria == null)
                return new IBusinessUnitConfiguration[] { };

            var businessUnitId = searchingCriteria.BusinessUnitId;
            var businessUnitName = searchingCriteria.BusinessUnitName;
            var businessUnitLocation = searchingCriteria.BusinessUnitLocation;
            var businessUnitAddress = searchingCriteria.BusinessUnitAddress;

            string cacheKey = string.Format("{0}|{1}|{2}|{3}|{4}", BusinessUnitConfigurationKey, (businessUnitId), (businessUnitName ?? ""),  (businessUnitLocation ?? ""), (businessUnitAddress ?? ""));
            return CacheProvider.GetCache().AddOrGetNullable(cacheKey, () => GetByCriteria( businessUnitId, businessUnitName, businessUnitLocation, businessUnitAddress), new CacheItemPolicy());

        }

        private IEnumerable<IBusinessUnitConfiguration> GetByCriteria(int businessUnitId, string businessUnitName, string businessUnitLocation, string businessUnitAddress)
        {
            var criteria = Session.CreateCriteria<IBusinessUnitConfiguration>();

                criteria.Add(Restrictions.Eq("BusinessUnitId", businessUnitId));
            
            if (!string.IsNullOrEmpty(businessUnitName))
                criteria.Add(Restrictions.Eq("BusinessUnitName", businessUnitName));

            if (!string.IsNullOrEmpty(businessUnitLocation))
                criteria.Add(Restrictions.Eq("BusinessUnitLocation", businessUnitLocation));

            if (!string.IsNullOrEmpty(businessUnitAddress))
                criteria.Add(Restrictions.Eq("BusinessUnitAddress", businessUnitAddress));

            return criteria.List<IBusinessUnitConfiguration>();
        }

        public List<IBusinessUnitConfiguration> GetAllBusinessServiceForAllBusinessUnitId(BusinessUnitConfigurationCriteria searchingCriteria)
        {
            if (searchingCriteria == null)
                return new List<IBusinessUnitConfiguration>();

            return Session.Query<IBusinessUnitConfiguration>().AsQueryable().ToList();
        }

        public void Add(IEnumerable<IMovable> movables)
        {
            Log.Info(message => message("BusinessUnitConfigurationDao.Add enter"));
            try
            {
                foreach (var movable in movables.OfType<IBusinessUnitConfiguration>())
                {
                    SaveOrUpdate(movable);
                }
                CleanCache();
            }
            catch (Exception e)
            {
                Log.Error("BusinessUnitConfigurationDao:Add ", e);
                throw;
            }
        }

        public void Delete(IEnumerable<IMovable> movables)
        {
            Log.Info(message => message("BusinessUnitConfigurationDao.Delete enter"));
            try
            {
                foreach (var movable in movables.OfType<IBusinessUnitConfiguration>())
                {
                    Delete(movable);
                }
                CleanCache();
            }
            catch (Exception e)
            {
                Log.Error("BusinessUnitConfigurationDao:Delete ", e);
                throw;
            }

        }

        public void DeleteAll(ITruncateHelperDao truncateHelperDao)
        {
            Log.Info(message => message("BusinessUnitConfigurationDao.DeleteAll enter"));

            try
            {
                truncateHelperDao.TruncateTable("BusinessUnitConfiguration");
                CleanCache();
            }
            catch (Exception e)
            {
                Log.Error("BusinessUnitConfigurationDao:DeleteAll ", e);
                throw;
            }
        }

        public IList<string> GetTableNamesInDependencyOrder()
        {
            return new List<string>
                    {
                        "BusinessUnitConfiguration",
                    };
        }

        public IEnumerable<IMovable> GetAll(IMovable startingPosition)
        {
            Log.Info(message => message("BusinessUnitConfigurationDao.GetAll startingPosition enter"));
            var startingAccount = (IBusinessUnitConfiguration)startingPosition;
            var accounts = GetAll().OfType<IBusinessUnitConfiguration>().ToList();
            var filteredAccounts = new List<IBusinessUnitConfiguration>();
            var foundStartingAccount = false;
            for (var i = 0; i < accounts.Count(); i++)
            {
                if (foundStartingAccount)
                {
                    filteredAccounts.Add(accounts[i]);
                }
                else if (accounts[i].BusinessUnitId.Equals(startingAccount.BusinessUnitId) &&
                         accounts[i].BusinessUnitName.Equals(startingAccount.BusinessUnitName) &&
                         accounts[i].BusinessUnitLocation.Equals(startingAccount.BusinessUnitLocation)
                    )
                {
                    foundStartingAccount = true;
                }
            }

            return filteredAccounts;
        }

        public IEnumerable<IMovable> GetAll()
        {
            Log.Info(message => message("BusinessUnitConfigurationDao.GetAll enter"));
            return Session.QueryOver<IBusinessUnitConfiguration>().List();
        }

        public void Update(IEnumerable<IMovable> movables)
        {
            Log.Info(message => message("Entering BusinessUnitConfigurationDao: Executing SaveOrUpdate"));
            try
            {
                foreach (var movable in movables.OfType<IBusinessUnitConfiguration>())
                {
                    SaveOrUpdate(movable);
                }
                CleanCache();
            }
            catch (Exception e)
            {
                Log.Error("BusinessUnitConfigurationDao:Update ", e);
                throw;
            }
        }

        private static void CleanCache()
        {
            CacheProvider.GetCache().CleanCache(BusinessUnitConfigurationKey);
        }
    }
}
