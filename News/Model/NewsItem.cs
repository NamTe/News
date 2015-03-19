using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Model {
    public class NewsItem {
        public String image { set; get; }
        public String title { set; get; }
        public String link { get; set; }
        public String description { get; set; }
    }
}
