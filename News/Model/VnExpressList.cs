using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace News.Model {
    public class VnExpressList : ObservableCollection<NewsItem> {
        public bool IsDataLoad = false;

        public VnExpressList() {

        }

        public bool LoadData(String url) {
            try {
                this.Clear();
                WebClient wc = new WebClient();
                wc.DownloadStringCompleted += wc_DownloadStringCompleted;
                wc.DownloadStringAsync(new Uri(url));
                IsDataLoad = true;
            }
            catch (Exception exc) {
                return false;
            }
            return true;
        }

        private void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e) {
            try {
                String rssContent = e.Result.ToString();
                var xmlSerilizer = new XmlSerializer(typeof(VnExpressModel));
                var rssDataBase = new VnExpressModel();
                using (var strReader = new StringReader(rssContent)) {
                    using (var xmlReader = XmlReader.Create(strReader)) {
                        rssDataBase = (VnExpressModel)xmlSerilizer.Deserialize(xmlReader);
                    }
                }
                if (rssDataBase != null) {
                    foreach (var item in rssDataBase.channel.item) {
                        this.Add(new NewsItem() {
                            image = getImage(item.description),
                            title = item.title,
                            link = item.link,
                            description = (item.description),
                        });
                    }
                }
            }
            catch (Exception exc) {

            }
            
        }

        private String getImage(String str) {
            var result = "";

            var match = Regex.Match(str, "<img.*?src=\"(.*?)\".*?>", RegexOptions.IgnoreCase);
            if (match.Groups.Count > 0)
                result = match.Groups[1].Value;

            return result;
        }

        
    }
}
