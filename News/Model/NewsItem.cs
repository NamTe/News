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

        public override string ToString() {
            return String.Format("Title: {0}\nLink: {1}\nDescription: {2}\n\n\n", title.Trim(), link.Trim(), description.Trim());
        }
    }
}
