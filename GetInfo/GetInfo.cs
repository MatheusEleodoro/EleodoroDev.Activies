using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using System.Activities.Presentation;
using System.Windows;
using InfoExtrator;


namespace GetInfo
{
    [ActivityDesignerOptions(AllowDrillIn = false)]
    [Category("EleodoroDev.Text.Gets")]
    [DisplayName("Get Info")]
    [Description("EN - Extract information the desired information from texts\nPT - Extraia informações as informações desejadas de textos")]
    [Designer(typeof(GetInfoDesigner))]
    public class GetInfo : NativeActivity
    {
        #region Declaração de Variaveis
        public List<string> innerText = new List<string>();
        [Browsable(false)]
        public OutArgument<string> To { get; set; }

        [Browsable(false)]
        public InArgument<string> inputExpressionOne { get; set; }

        [Browsable(false)]
        public InArgument<string> inputExpressionTwo { get; set; }

        [Browsable(false)]
        public InArgument<int> inputParagraph { get; set; }
        #endregion

        #region Metodos

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
        }
        protected override void Execute(NativeActivityContext context)
        {
           
            try
            {
                innerText = (List<string>)context.Properties.Find("TEXTO");
            }
            catch { throw new Exception("Activity must be associated with \"Get Info scope \"\nAtividade precisa estar associado do \"Get Info scope\" "); }

            var argumento1 = inputExpressionOne.Get(context);
            var argumento2 = inputExpressionTwo.Get(context);
            var paragrapth = inputParagraph.Get(context);

            if (paragrapth < innerText.Count)
                To.Set(context, ExtractInfo.GetInfoByArguments(innerText[paragrapth], argumento1, argumento2));
            else
                throw new Exception("Paragraph not exist\nParagrafo invalido");

        }
        #endregion

    }
}
