﻿/* @author Matheus Eleodoro <matheuseleodoro@gmail.com>
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

namespace ExtractCNPJ
{
    [ActivityDesignerOptions(AllowDrillIn = false)]
    [Category("EleodoroDev.Text.Gets")]
    [DisplayName("Get CNPJ")]
    [Description("EN- Extract CNPJ's from desired texts\nPT- Extraia CNPJ's de textos desejado")]
    public class GetCNPJ : NativeActivity
    {
        [Category("Output")]
        public OutArgument<string> To { get; set; }
        [Description("EN- Use the \"Show Paragraphs\" activity to show the text paragraphs\nPT- Use a atividade \"Show Paragraphs\" para mostrar os paragrafos do texto ")]
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

            if (paragraph.Get(context) < innerText.Count)
                To.Set(context, ExtractInfo.GetCNPJ(innerText[paragraph.Get(context)]));
            else
                throw new Exception("Paragraph not exist\nParagrafo invalido");

        }
    }
}
