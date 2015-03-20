using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Model.News24h {

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute("rss",Namespace = "", IsNullable = false)]
    public partial class Model24h {

        private rssChannel channelField;

        private decimal versionField;

        /// <remarks/>
        public rssChannel channel {
            get {
                return this.channelField;
            }
            set {
                this.channelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rssChannel {

        private string titleField;

        private string linkField;

        private string descriptionField;

        private rssChannelImage imageField;

        private string languageField;

        private string copyrightField;

        private byte ttlField;

        private string generatorField;

        private rssChannelItem[] itemField;

        /// <remarks/>
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string link {
            get {
                return this.linkField;
            }
            set {
                this.linkField = value;
            }
        }

        /// <remarks/>
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public rssChannelImage image {
            get {
                return this.imageField;
            }
            set {
                this.imageField = value;
            }
        }

        /// <remarks/>
        public string language {
            get {
                return this.languageField;
            }
            set {
                this.languageField = value;
            }
        }

        /// <remarks/>
        public string copyright {
            get {
                return this.copyrightField;
            }
            set {
                this.copyrightField = value;
            }
        }

        /// <remarks/>
        public byte ttl {
            get {
                return this.ttlField;
            }
            set {
                this.ttlField = value;
            }
        }

        /// <remarks/>
        public string generator {
            get {
                return this.generatorField;
            }
            set {
                this.generatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("item")]
        public rssChannelItem[] item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rssChannelImage {

        private string urlField;

        private string titleField;

        private string linkField;

        /// <remarks/>
        public string url {
            get {
                return this.urlField;
            }
            set {
                this.urlField = value;
            }
        }

        /// <remarks/>
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string link {
            get {
                return this.linkField;
            }
            set {
                this.linkField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rssChannelItem {

        private string titleField;

        private string descriptionField;

        private string linkField;

        private string pubDateField;

        private string summaryImgField;

        /// <remarks/>
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string link {
            get {
                return this.linkField;
            }
            set {
                this.linkField = value;
            }
        }

        /// <remarks/>
        public string pubDate {
            get {
                return this.pubDateField;
            }
            set {
                this.pubDateField = value;
            }
        }

        /// <remarks/>
        public string summaryImg {
            get {
                return this.summaryImgField;
            }
            set {
                this.summaryImgField = value;
            }
        }
    }


}
