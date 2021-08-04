using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using GetInfo;
using System.Activities.Presentation;

namespace GetInfo
{
    class DesignerMetadata :IRegisterMetadata
    {
        public void Register()
        {
            AttributeTableBuilder atb = new AttributeTableBuilder();
            atb.AddCustomAttributes(typeof(GetInfo), new DesignerAttribute(typeof(GetInfo)), new ActivityDesignerOptionsAttribute { AllowDrillIn = false });
            MetadataStore.AddAttributeTable(atb.CreateTable());
        }
    }
}