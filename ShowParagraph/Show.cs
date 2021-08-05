/* @author Matheus Eleodoro <matheuseleodoro@gmail.com>
 * Portifolio/Instagram @eleodoro.dev
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using InfoExtrator;
using System.Activities.Presentation;

namespace ShowParagraph
{
    [ActivityDesignerOptions(AllowDrillIn = false)]
    [Category("EleodoroDev.Text.Gets")]
    [DisplayName("Show Paragraphs")]
    [Description("EN- Get the paragraphs and numbers of your text\nPT- Obtenha quais são os paragrafos e números do seus texto")]
   
    public class Show : NativeActivity
    {
        [Category("Output")]
        public OutArgument<string> To { get; set; }
        public List<string> innerText = new List<string>();

        protected override void Execute(NativeActivityContext context)
        {
            try
            {
                innerText = (List<string>)context.Properties.Find("TEXTO");
            }
            catch { throw new Exception("Activity must be associated with \"Get Info scope \"\nAtividade precisa estar associado do \"Get Info scope\" "); }
            To.Set(context, ExtractInfo.ShowParagraph(innerText));
        }
    }
}
