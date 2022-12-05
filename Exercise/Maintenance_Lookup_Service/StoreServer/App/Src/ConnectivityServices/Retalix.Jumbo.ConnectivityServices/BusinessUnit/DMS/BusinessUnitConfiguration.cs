using ProtoBuf;
using Retalix.Jumbo.Model.BusinessUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.ConnectivityServices.BusinessUnit.DMS
{
    [Serializable]
    [ProtoContract]
    public class BusinessUnitConfiguration : IBusinessUnitConfiguration
    {
        [ProtoMember(1)]
        public int BusinessUnitId { get; set; }

        [ProtoMember(2)]
        public string BusinessUnitName { get; set; }

        [ProtoMember(3)]
        public string BusinessUnitLocation { get; set; }

        [ProtoMember(4)]
        public string BusinessUnitAddress { get; set; }

        [ProtoMember(5)]
        public string EntityName
        {
            get { return "BusinessUnitConfiguration"; }
            set { }
        }
    }
}
