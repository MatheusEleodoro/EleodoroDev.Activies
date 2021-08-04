using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using InfoFromText;
using System.Activities.Presentation;

namespace InfoFromText
{
    class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            AttributeTableBuilder atb = new AttributeTableBuilder();
            atb.AddCustomAttributes(typeof(InfoFromText), new DesignerAttribute(typeof(InfoFromTextDesign)), new ActivityDesignerOptionsAttribute { AllowDrillIn = false });
            MetadataStore.AddAttributeTable(atb.CreateTable());
        }
    }
}