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

namespace ExtractContratoNumber
{
    [ActivityDesignerOptions(AllowDrillIn = false)]
    [Category("EleodoroDev.Text.Gets")]
    [DisplayName("Get Contract Number")]
    [Description("EN- Extract Contract numbers from desired texts\nPT- Extraia Nº de contrato's de textos desejado")]
    public class GetContractNumber : NativeActivity
    {

        [Category("Output")]
        public OutArgument<string> To { get; set; }
        [Description("EN- Use the \"Show Paragraphs\" activity to show the text paragraphs\nPT- Use a atividade \"Show Paragraphs\" para mostrar os paragrafos do texto ")]
        [Category("Regex")]
        public InArgument<string> regexExpression { get; set; }
        [Category("Input")]
        public InArgument<int> paragraph { get; set; }

        public List<string> innerText = new List<string>();

 
        protected override void Execute(NativeActivityContext context)
        {
            try
            {
                innerText = (List<string>)context.Properties.Find("TEXTO");
            }
            catch { throw new Exception("Activity must be associated with \"Get Info scope \"\nAtividade precisa estar associado do \"Get Info scope\" "); }

            var _paragraph = 0;

            if (paragraph.Get(context) < innerText.Count)
                 _paragraph = paragraph.Get(context);
            else
                throw new Exception("Paragraph not exist\nParagrafo invalido");

            if (String.IsNullOrEmpty(regexExpression.Get(context)))
                To.Set(context, ExtractInfo.GetContractNumber(innerText[_paragraph]));
            else
                To.Set(context, ExtractInfo.GetContractNumber(innerText[_paragraph], regexExpression.Get(context)));



        }
    }
}
