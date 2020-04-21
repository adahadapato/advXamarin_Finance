using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Xml.Serialization;

namespace Finance.Model
{
    [XmlRoot(ElementName = "enclosure")]
    public class Enclosure
    {
        [XmlElement(ElementName = "url")]
        public string Url { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "link")]
        public string ItemLink { get; set; }

        [XmlElement(ElementName = "category")]
        public ObservableCollection<string> Category { get; set; }

        [XmlElement(ElementName = "pubDate")]
        private string pubDate;
        public string PubDate
        {
            get { return PubDate; }
            set
            {
                pubDate = value;
                PublishedDate = DateTime.ParseExact(pubDate, "ddd, dd MMM yyyy HH:mm:ss GMT", CultureInfo.InstalledUICulture);
            }
        }

        public DateTime PublishedDate { get; set; }

        [XmlElement(ElementName = "enclosure")]
        public Enclosure Enclosure { get; set; }

        [XmlElement(ElementName = "creator", Namespace ="http://purl.org/dc/element/1.1/")]
        public string Creator { get; set; }
    }

    [XmlRoot(ElementName = "channel")]
    public class Channel
    {
        [XmlElement(ElementName = "lastBuildDate")]
        public string lastBuildDate { get; set; }

        [XmlElement(ElementName = "item")]
        public ObservableCollection<Item> items { get; set; }
    }

    [XmlRoot(ElementName ="rss")]
    public class Posts
    {
        [XmlElement(ElementName ="channel")]
        public Channel Channel { get; set; }
    }
}
