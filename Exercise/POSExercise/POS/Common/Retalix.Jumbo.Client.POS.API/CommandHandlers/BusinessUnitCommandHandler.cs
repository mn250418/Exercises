using Retalix.Client.POS.BusinessObjects.CommandHandlers;
using Retalix.Contracts.Generated.Common;
using Retalix.Jumbo.Client.POS.API.Model;
using Retalix.Jumbo.Client.POS.API.Model.CommanHandler;
using Retalix.Jumbo.Contracts.Generated.BusinessUnit;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Retalix.Jumbo.Client.POS.API
{
    [Export(typeof(IBusinessUnitCommandHandler))]
    class BusinessUnitCommandHandler : PosCommandHandlerBase, IBusinessUnitCommandHandler
    {
        private const string AppConfigStatus = "BusinessUnitConfiguration";
        private int _businessUnitId;
        private string _businessUnitName;
        private string _businessUnitLocation;
        private string _businessUnitAddress;
        public void Init(int BusinessUnitId)
        {
            _businessUnitId = BusinessUnitId;
        }

        public void Init(int businessUnitId, string businessUnitName, string businessUnitLocation, string businessUnitAddress)
        {
            _businessUnitId = businessUnitId;
            _businessUnitName = businessUnitName;
            _businessUnitLocation = businessUnitLocation;
            _businessUnitAddress = businessUnitAddress;
        }

        protected override string ExecuteLogic()
        {
            var appConfigMaintenanceServiceAgent = GetServiceAgent<IBusinessUnitServiceAgent>();
            BusinessUnitConfigurationType businessUnitConfigurationType = new BusinessUnitConfigurationType();
            businessUnitConfigurationType.BusinessUnitId = _businessUnitId;
            businessUnitConfigurationType.BusinessUnitName = _businessUnitName;
            businessUnitConfigurationType.BusinessUnitLocation = _businessUnitLocation;
            businessUnitConfigurationType.BusinessUnitAddress = _businessUnitAddress;

            var appConfigMaintenanceResult = appConfigMaintenanceServiceAgent.AddorUpdateBusinessUnit(businessUnitConfigurationType, ActionTypeCodes.AddOrUpdate);

            MessageBox.Show(appConfigMaintenanceResult + " added successfully. ", "Business Unit add");



            return AppConfigStatus;
        }
    }
}
