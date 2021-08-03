using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using InfoFromTextScope;
using System.Activities.Presentation;

namespace InfoFromTextScope
{
    class DesignerMetadata :IRegisterMetadata
    {
        public static void RegisterALL()
        {
            AttributeTableBuilder builder = new AttributeTableBuilder();
            builder.AddCustomAttributes(typeof(InfoFromTextScope), new DesignerAttribute(typeof(InfoFromTextScopeDesign)), new ActivityDesignerOptionsAttribute { AllowDrillIn = false });
            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
        public void Register()
        {
            DesignerMetadata.RegisterALL();
        }
    }
}


