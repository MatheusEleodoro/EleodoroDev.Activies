using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.Activities.Presentation;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Activities.DynamicUpdate;
using System.Activities.Hosting;
using System.DirectoryServices.AccountManagement;

namespace InfoFromText
{
    [ActivityDesignerOptions(AllowDrillIn = false)]
    [Category("EleodoroDev.Text.Gets")]
    [DisplayName("Multiple Infos")]
    [Description("EN - Extract information the desired information from texts\nPT - Extraia informações as informações desejadas de textos")]
    [Designer(typeof(InfoFromTextDesign))]
    public class InfoFromText : NativeActivity
    {
        [Browsable(false)]
        public InArgument<string> input { get; set; }
        //[Browsable(false)]
        public Dictionary<string, InArgument<string>> Inputs = new Dictionary<string, InArgument<string>>();
        //public ObservableCollection<InArgument<string>> Inputs = new ObservableCollection<InArgument<string>>();
        //public InArgument<string>[] inputs = new InArgument<string>[1000];
        public static InfoFromText instance;
        public InfoFromText()
        {
            instance = this;
        }
        protected override void Execute(NativeActivityContext context)
        {
            MessageBox.Show(Inputs["0"].Get(context));

        }
    }


}