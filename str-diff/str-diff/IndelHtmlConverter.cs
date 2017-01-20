using System;
using System.Net;
using System.Text;

namespace str_diff
{
    public class IndelHtmlConverter
    {
        public string Convert(InDel indel)
        {
            StringBuilder result = new StringBuilder();
            foreach (Edit e in indel.Edits())
                result.Append(MakeElement(e));
            return result.ToString();
        }

        private string MakeElement(Edit e)
        {
            string cssClass = ClassFor(e);
            string innerHtml = WebUtility.HtmlEncode(e.Text());
            string format = "<span class=\"{0}\">{1}</span>";
            string element = string.Format(format, cssClass, innerHtml);
            return element;
        }

        private string ClassFor(Edit e)
        {
            switch (e.Operation())
            {
                case "=": return "same";
                case "-": return "delete";
                case "+": return "insert";
            }
            throw new Exception("Do not recocnise indel operation " + e.Operation());
        }
    }
}
