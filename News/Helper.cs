using News.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace News {
    public static class Helper {
        public const string VnExpressIndex = "http://vnexpress.net/rss/tin-moi-nhat.rss";
        public const string VnExpressCurrent = "http://vnexpress.net/rss/thoi-su.rss";
        public const string VnExpressWorld = "http://vnexpress.net/rss/the-gioi.rss";
        public const string Index24h = "http://www.24h.com.vn/upload/rss/tintuctrongngay.rss";
        public const string Soccer24h = "http://www.24h.com.vn/upload/rss/bongda.rss";
        public const string ListSaveKey = "adlkfjalkdjfj3249fsdfjalksdf09q3u490";
        public static void SaveList(ObservableCollection<NewsItem> list) {
            ObservableCollection<NewsItem> bookMarkList = null;
            try {
                String SavedList;
                if (IsolatedStorageSettings.ApplicationSettings.TryGetValue(Helper.ListSaveKey, out SavedList)) {
                    bookMarkList = JsonConvert.DeserializeObject<ObservableCollection<NewsItem>>(SavedList);
                }
                else {
                    bookMarkList = new ObservableCollection<NewsItem>();
                }
            }
            catch {

            }
            foreach (var item in bookMarkList) {
                if (!list.Contains(item))
                    list.Add(item);
            }
            var SaveList = JsonConvert.SerializeObject(list);
            IsolatedStorageSettings.ApplicationSettings[Helper.ListSaveKey] = SaveList;
            IsolatedStorageSettings.ApplicationSettings.Save();
        }

        public static void DeleteItem(ObservableCollection<NewsItem> list) {
            var SaveList = JsonConvert.SerializeObject(list);
            IsolatedStorageSettings.ApplicationSettings[Helper.ListSaveKey] = SaveList;
            IsolatedStorageSettings.ApplicationSettings.Save();
        }
    }

}

