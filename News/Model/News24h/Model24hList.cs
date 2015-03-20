using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace News.Model.News24h {
    public class Model24hList : ObservableCollection<NewsItem> {
        public bool IsDataLoad = false;

        public Model24hList() {

        }

        public bool LoadData(String url) {
            try {
                this.Clear();
                WebClient wc = new WebClient();
                wc.DownloadStringCompleted += wc_DownloadStringCompleted;
                wc.DownloadStringAsync(new Uri(url)); 
                IsDataLoad = true;
            }
            catch (Exception e) {
                return false;
            }
            return true;
        }

        private void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e) {
            try {
                String rssContent = e.Result.ToString();
                var xmlSerilizer = new XmlSerializer(typeof(Model24h));
                var rssDataBase = new Model24h();
                using (var strReader = new StringReader(rssContent)) {
                    using (var xmlReader = XmlReader.Create(strReader)) {
                        rssDataBase = (Model24h)xmlSerilizer.Deserialize(xmlReader);
                    }
                }
                if (rssDataBase != null) {
                    foreach (var item in rssDataBase.channel.item) {
                        Debug.WriteLine(item.title);
                        this.Add(new NewsItem() {
                            image = item.summaryImg,
                            title = item.title,
                            link = item.link,
                            description = item.description,
                        });
                        Debug.WriteLine(item.summaryImg);
                    }
                }
            }
            catch (Exception exc) {

            }

        }


    }
}
