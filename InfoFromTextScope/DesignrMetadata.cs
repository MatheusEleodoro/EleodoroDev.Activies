using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Activities.Presentation.Metadata;
using InfoFromTextScope;
namespace InfoFromTextScope
{
    class DesignrMetadata : IRegisterMetadata
    {
        public void Register()
        {
            AttributeTableBuilder attributeTableBuilder = new AttributeTableBuilder();
            attributeTableBuilder.AddCustomAttributes(typeof(InfoFromTextScope), new DesignerAttribute(typeof(ScopeDesigner)));
            MetadataStore.AddAttributeTable(attributeTableBuilder.CreateTable());
        }
    }
}
