namespace Retalix.Jumbo.Contracts.Generated.BusinessUnit
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "14.100.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://retalix.com/R10/services")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://retalix.com/R10/services", IsNullable=true)]
    public partial class BusinessUnitConfigurationType
    {
        
        private int businessUnitIdField;
        
        private string businessUnitNameField;
        
        private string businessUnitLocationField;
        
        private string businessUnitAddressField;
        
        private bool BusinessUnitIdFieldSpecified;
        
        public int BusinessUnitId
        {
            get
            {
                return this.businessUnitIdField;
            }
            set
            {
                this.businessUnitIdField = value;
                this.BusinessUnitIdSpecified = true;
            }
        }
        
        public string BusinessUnitName
        {
            get
            {
                return this.businessUnitNameField;
            }
            set
            {
                this.businessUnitNameField = value;
            }
        }
        
        public string BusinessUnitLocation
        {
            get
            {
                return this.businessUnitLocationField;
            }
            set
            {
                this.businessUnitLocationField = value;
            }
        }
        
        public string BusinessUnitAddress
        {
            get
            {
                return this.businessUnitAddressField;
            }
            set
            {
                this.businessUnitAddressField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual bool BusinessUnitIdSpecified
        {
            get
            {
                return this.BusinessUnitIdFieldSpecified;
            }
            set
            {
                this.BusinessUnitIdFieldSpecified = value;
            }
        }
    }
}
