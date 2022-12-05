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
    public partial class BusinessUnitConfigurationLookupResponse : Retalix.Contracts.Interfaces.IHeaderResponse
    {
        
        private RetalixCommonHeaderType headerField;
        
        private BusinessUnitConfigurationType[] businessUnitConfigurationsField;
        
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
        
        [System.Xml.Serialization.XmlElementAttribute("BusinessUnitConfigurations")]
        public BusinessUnitConfigurationType[] BusinessUnitConfigurations
        {
            get
            {
                return this.businessUnitConfigurationsField;
            }
            set
            {
                this.businessUnitConfigurationsField = value;
            }
        }
    }
}
