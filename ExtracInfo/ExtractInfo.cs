using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExtractInfo
{
    class ExtractInfo
    {

        static void Main(string[]args)
        {
            var txt = @"TIM S.A.    02.421.421/0001-11
ENDEREÇO DE COBRANÇA/COMERCIAL";
            Console.WriteLine(GetCNPJ(txt));
        }


        private const string regex = "[0-9]{2}[.][0-9]{4}[.]+[0-9]{3}[.][0-4]{4}";
        public static List<string> GetParagraph(string text)
        {

            var matchCollection = Regex.Matches(text, "[^\r\n]+((\r|\n|\r\n)[^\r\n]+)*");
            var collection = new List<string>();
            foreach (var it in matchCollection)
            {
                collection.Add(it.ToString());
            }
            return collection;
        }

        public static string GetInfoByArguments(string paragraph, string arg1, string arg2)
            => Regex.Match(paragraph, $@"(?<={arg1}\s*).*?(?=\s*{arg2})").ToString();

        public static string GetContractNumber(string paragraph, string pattern = regex)
            => Regex.Match(paragraph, pattern).ToString();

        public static string GetCNPJ(string paragraph)
            => Regex.Match(paragraph, @"(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})").ToString();
    }
}