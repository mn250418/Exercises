using Retalix.Contract.Schemas.Schema.ARTS.PosLog_V6.Objects;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using Retalix.StoreServices.Model.Selling;
using Retalix.StoreServices.Model.Selling.RetailTransaction.RetailTransactionLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Retalix.Jumbo.BusinessComponents.TransactionLog
{
    [RegisterAddition]
    public class RetailTransactionTimeVisitor : IRetailTransactionLogDocumentCreationVisitor
    {
        public void Visit(IRetailTransaction retailTransaction, IRetailTransactionLogDocumentWriter writer)
        {

            var artsTransaction = (TransactionDomainSpecific)writer.ObjectContent;

            XmlElement transactionDurationElement =
            ToXmlElement(new XElement("TotalTransactionTime", (retailTransaction.EndTime - retailTransaction.StartTime).ToString(@"hh\:mm\:ss"), new XAttribute("format", "hh:mm:ss")));
            artsTransaction.Any = new List<XmlElement> { transactionDurationElement };
            writer.UpdateArtsTransaction(artsTransaction);
        }

        private static XmlElement ToXmlElement(XElement el)
        {
            var doc = new XmlDocument();
            doc.Load(el.CreateReader());
            return doc.DocumentElement;
        }

    }
}
