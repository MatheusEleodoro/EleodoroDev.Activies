/* @author Matheus Eleodoro <matheuseleodoro@gmail.com>
 * Portifolio/Instagram @eleodoro.dev
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Activities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Activities.Statements;
using System.DirectoryServices.AccountManagement;
using InfoExtrator;
using System.Drawing;

namespace InfoFromTextScope
{

    [Category("EleodoroDev.Text.Gets")]
    [DisplayName("Get Info Scope")]
    [Description("EN - Group your activities with this activity\nPT - Agrupe suas atividades com essa atividade")]
    [Designer(typeof(ScopeDesigner))]
    [ToolboxBitmap(typeof(InfoFromTextScope), "Resources.Bitmaps.ic_scope.bmp")]
    public class InfoFromTextScope : NativeActivity
    {
        #region Declaração de Variaveis
        
        private Sequence innerSequence = new Sequence();
        [Browsable(false)]
        public InArgument<string> argument { get; set; }
       
        public List<string> TEXTO = new List<string>();

        public Activity Body { get; set; }

        [Browsable(false)]
        public Collection<Variable> Variables { get => innerSequence.Variables; }

        public static InfoFromTextScope instance;
        #endregion


        #region Metodos
   

        public Collection<Activity> Activities { get => innerSequence.Activities; }
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            metadata.AddImplementationChild(innerSequence);
            base.CacheMetadata(metadata);
        }
        protected override void Execute(NativeActivityContext context)
        {
            var a = argument.Get(context);
            TEXTO = ExtractInfo.GetParagraph(a);
            context.Properties.Add("TEXTO", TEXTO);

            context.ScheduleActivity(innerSequence);
        }
        #endregion
    }
}
