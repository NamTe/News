using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Model {
    public class BookMarkModel {
        public bool IsLoadData = false;
        public ObservableCollection<NewsItem> bookMarkList;
        public BookMarkModel() {

        }

        public void LoadData() {
            try {
                String SavedList;
                if (IsolatedStorageSettings.ApplicationSettings.TryGetValue(Helper.ListSaveKey, out SavedList)) {
                    bookMarkList = JsonConvert.DeserializeObject<ObservableCollection<NewsItem>>(SavedList);
                }
                else {
                    bookMarkList = new ObservableCollection<NewsItem>();
                }
                IsLoadData = true;
            }
            catch {

            }

        }
    }
}
