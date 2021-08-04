using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace InfoExtrator
{
    public class ExtractInfo
    {
        private const string regexContrato = "[0-9]{2}[.][0-9]{4}[.]+[0-9]{3}[.][0-4]{4}";
        private const string regexCNPJ = @"^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})$";
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

        public static string ShowParagraph(List<String>paragraph)
        {
            string result = "";

            foreach(var it in paragraph)
            {
                var index = paragraph.IndexOf(it);
                result += $"{index}º paragraph = ({it})\n\n";
            }
            return result;
        }

        public static string GetInfoByArguments(string paragraph, string arg1, string arg2)
            => Regex.Match(paragraph, $@"(?<={arg1}\s*).*?(?=\s*{arg2})").ToString();

        public static string GetContractNumber(string paragraph, string pattern = regexContrato)
            => Regex.Match(paragraph, pattern).ToString();

        public static string GetCNPJ(string paragraph)
            => Regex.Match(paragraph, @"(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})").ToString();

        public static string GetCPF(string paragraph)
            => Regex.Match(paragraph, @"(\d{3}.\d{3}.\d{3}-\d{2})").ToString();

        
    }
}