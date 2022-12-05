using Retalix.Client.Common.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.Model.CommanHandler
{
    public interface IBusinessUnitCommandHandler : ICommandHandler
    {
        void Init(int businessUnitId, string businessUnitName, string businessUnitLocation, string businessUnitAddress);
    }
}
