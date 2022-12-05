using Retalix.Client.POS.Presentation.ViewModels.ViewModels;
using Retalix.Client.Presentation.Core.Command;
using Retalix.Jumbo.Client.POS.API.Model.CommanHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Retalix.Jumbo.Client.POS.Presentation.ViewModels.ViewModels
{
    public class BusinessUnitInputViewModel : PosViewModelBase
    {
        public ICommand AddCommand { get; private set; }
        public ICommand BackCommand { get; private set; }


        private int _businessUnitId;
        public int BusinessUnitId
        {
            get { return _businessUnitId; }
            set
            {
                _businessUnitId = value;
                NotifyPropertyChanged("BusinessUnitId");
            }
        }

        private string _businessUnitName;
        public string BusinessUnitName
        {
            get { return _businessUnitName; }
            set
            {
                _businessUnitName = value;
                NotifyPropertyChanged("BusinessUnitName");
            }
        }

        private string _businessUnitLocation;
        public string BusinessUnitLocation
        {
            get { return _businessUnitLocation; }
            set
            {
                _businessUnitLocation = value;
                NotifyPropertyChanged("BusinessUnitLocation");
            }
        }

        private string _businessUnitAddress;
        public string BusinessUnitAddress
        {
            get { return _businessUnitAddress; }
            set
            {
                _businessUnitAddress = value;
                NotifyPropertyChanged("BusinessUnitAddress");
            }
        }

        public BusinessUnitInputViewModel()
        {
            Init();
        }
        private void Init()
        {
            InitCommands();
        }

        private void InitCommands()
        {
            AddCommand = new CommandAction<object>(ExecuteAddCommand, CanExecuteAddCommand);
            BackCommand = new CommandAction<object>(ExecuteBackCommand, x => true);


        }

        private bool CanExecuteAddCommand(object obj)
        {
            return !string.IsNullOrWhiteSpace(BusinessUnitId.ToString());
        }

        protected virtual void ExecuteAddCommand(object obj)
        {

            ExecuteBusinessUnitCommandHandler(_businessUnitId,_businessUnitName,_businessUnitLocation,_businessUnitAddress);
        }

        protected virtual void ExecuteBackCommand(object obj)
        {

            //ExecuteBackCommandHandler();
        }

        protected virtual void ExecuteBusinessUnitCommandHandler(int BusinessUnitId, string BusinessUnitName,string BusinessUnitLocation, string BusinessUnitAddress)
        {
            var command = CommandHandlerFactory.Create<IBusinessUnitCommandHandler>();
            command.Init(BusinessUnitId,BusinessUnitName,BusinessUnitLocation,BusinessUnitAddress);
            ExecuteCommandHandlerAndStartFlow(command);
        }

        //protected virtual void ExecuteBackCommandHandler()
        //{
        //    var command = CommandHandlerFactory.Create<ICarBackCommandHandler>();
        //    ExecuteCommandHandlerAndStartFlow(command);
        //}
    }
}
