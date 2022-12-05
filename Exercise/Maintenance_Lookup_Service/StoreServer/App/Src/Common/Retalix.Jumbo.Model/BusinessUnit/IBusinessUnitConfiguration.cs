using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Model.BusinessUnit
{
    public interface IBusinessUnitConfiguration : IMovable, INamedObject
    {
        /// <summary>
        /// Gets or sets the business unit identifier.
        /// </summary>
        /// <value>
        /// The business unit identifier.
        /// </value>
        int BusinessUnitId { get; set; }

        /// <summary>
        /// Gets or sets the business unit name.
        /// </summary>
        /// <value>
        /// Business unit name
        /// </value>
        string BusinessUnitName { get; set; }

        /// <summary>
        /// Gets or sets the unit location.
        /// </summary>
        /// <value>
        /// Business unit location.
        /// </value>
        string BusinessUnitLocation { get; set; }

        /// <summary>
        /// Gets or sets the unit address.
        /// </summary>
        /// <value>
        /// The entity parameter.
        /// </value>
        string BusinessUnitAddress { get; set; }

    }
}
