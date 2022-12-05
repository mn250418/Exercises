using Retalix.Client.Common.Handlers;
using Retalix.Client.POS.BusinessObjects.Factory;
using Retalix.Client.Presentation.Core.ViewModels;
using Retalix.Jumbo.Client.POS.API.Model.CommanHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.Commands
{
    [Export(typeof(IExtendedCommand))]
    class BusinessUnitCommand : IExtendedCommand
    {
        [Import]
        private ICommandHandlerFactory _commandHandlerFactory;
        public string CommandName
        {
            get
            {
                return "BusinessUnitConfiguration";
            }
        }

        public ICommandHandler GetCommandHandler(ViewModelBase viewModel)
        {
            return _commandHandlerFactory.Create<IBusinessUnitCommandHandler>();
        }
    }
}
