using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Model {
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute("rss", Namespace = "", IsNullable = false)]
    public partial class VnExpressModel {

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

        private string descriptionField;

        private string pubDateField;

        private string generatorField;

        private string linkField;

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
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
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
        public string generator {
            get {
                return this.generatorField;
            }
            set {
                this.generatorField = value;
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
    public partial class rssChannelItem {

        private string titleField;

        private string descriptionField;

        private string pubDateField;

        private string linkField;

        private string guidField;

        private byte commentsField;

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
        public string pubDate {
            get {
                return this.pubDateField;
            }
            set {
                this.pubDateField = value;
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
        public string guid {
            get {
                return this.guidField;
            }
            set {
                this.guidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://purl.org/rss/1.0/modules/slash/")]
        public byte comments {
            get {
                return this.commentsField;
            }
            set {
                this.commentsField = value;
            }
        }
    }


}
