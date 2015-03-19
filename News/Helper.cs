using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News {
    public class Helper {
        public const string VnExpressIndex = "http://vnexpress.net/rss/tin-moi-nhat.rss";
        public const string VnExpressCurrent = "http://vnexpress.net/rss/thoi-su.rss";


        public static string DecodeHtml(string htmltext) {
            if (htmltext == null) {
                return null;
            }

            htmltext = htmltext.Replace("<p>", "").Replace("</p>", "\r\n\r\n");

            string decoded = String.Empty;
            if (htmltext.IndexOf('<') > -1 || htmltext.IndexOf('>') > -1 || htmltext.IndexOf('&') > -1) {
                try {
                    HtmlDocument document = new HtmlDocument();

                    var decode = document.CreateElement("div");
                    htmltext = htmltext.Replace(".<", ". <").Replace("?<", "? <").Replace("!<", "! <").Replace("&#039;", "'");
                    decode.InnerHtml = htmltext;

                    var allElements = decode.Descendants().ToArray();
                    for (int n = allElements.Length - 1; n >= 0; n--) {
                        if (allElements[n].NodeType == HtmlNodeType.Comment || allElements[n].Name.EqualNoCase("style") || allElements[n].Name.EqualNoCase("script")) {
                            allElements[n].Remove();
                        }
                    }
                    decoded = WebUtility.HtmlDecode(decode.InnerText);
                }
                catch { }
            }
            else {
                decoded = htmltext;
            }
            return decoded;
        }
    }
}
