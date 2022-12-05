namespace Retalix.Jumbo.Contracts.Generated.BusinessUnit
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "14.100.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://retalix.com/R10/services")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://retalix.com/R10/services", IsNullable=false)]
    public partial class BusinessUnitConfigurationMaintenanceRequest : Retalix.Contracts.Interfaces.IHeaderRequest
    {
        
        private RetalixCommonHeaderType headerField;
        
        private BusinessUnitConfigurationType[] businessUnitConfigurationField;
        
        private ActionTypeCodes actionField;
        
        private bool ActionFieldSpecified;
        
        public RetalixCommonHeaderType Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("BusinessUnitConfiguration")]
        public BusinessUnitConfigurationType[] BusinessUnitConfiguration
        {
            get
            {
                return this.businessUnitConfigurationField;
            }
            set
            {
                this.businessUnitConfigurationField = value;
            }
        }
        
        public ActionTypeCodes Action
        {
            get
            {
                return this.actionField;
            }
            set
            {
                this.actionField = value;
                this.ActionSpecified = true;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual bool ActionSpecified
        {
            get
            {
                return this.ActionFieldSpecified;
            }
            set
            {
                this.ActionFieldSpecified = value;
            }
        }
    }
}
