using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
namespace SerhatBilenIBB_TestApp_API.Models.ibb
{
    [XmlRoot(ElementName = "title", Namespace = "http://www.w3.org/2005/Atom")]
    public class Title
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
    public class Link
    {
        [XmlAttribute(AttributeName = "rel")]
        public string Rel { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }

    [XmlRoot(ElementName = "author", Namespace = "http://www.w3.org/2005/Atom")]
    public class Author
    {
        [XmlElement(ElementName = "name", Namespace = "http://www.w3.org/2005/Atom")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "category", Namespace = "http://www.w3.org/2005/Atom")]
    public class Category
    {
        [XmlAttribute(AttributeName = "term")]
        public string Term { get; set; }
        [XmlAttribute(AttributeName = "scheme")]
        public string Scheme { get; set; }
    }

    [XmlRoot(ElementName = "_id", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public class _id
    {
        [XmlAttribute(AttributeName = "type", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "PARK_NAME", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public class PARK_NAME
    {
        [XmlAttribute(AttributeName = "type", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "LOCATION_NAME", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public class LOCATION_NAME
    {
        [XmlAttribute(AttributeName = "type", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "PARK_TYPE_ID", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public class PARK_TYPE_ID
    {
        [XmlAttribute(AttributeName = "type", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "PARK_TYPE_DESC", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public class PARK_TYPE_DESC
    {
        [XmlAttribute(AttributeName = "type", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "CAPACITY_OF_PARK", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public class CAPACITY_OF_PARK
    {
        [XmlAttribute(AttributeName = "type", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "WORKING_TIME", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public class WORKING_TIME
    {
        [XmlAttribute(AttributeName = "type", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "COUNTY_NAME", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public class COUNTY_NAME
    {
        [XmlAttribute(AttributeName = "type", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "LONGITUDE", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public class LONGITUDE
    {
        [XmlAttribute(AttributeName = "type", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "LATITUDE", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public class LATITUDE
    {
        [XmlAttribute(AttributeName = "type", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "properties", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public class Properties
    {
        [XmlElement(ElementName = "_id", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public int _id { get; set; }
        [XmlElement(ElementName = "PARK_NAME", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public string PARK_NAME { get; set; }
        [XmlElement(ElementName = "LOCATION_NAME", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public string LOCATION_NAME { get; set; }
        [XmlElement(ElementName = "PARK_TYPE_ID", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public string PARK_TYPE_ID { get; set; }
        [XmlElement(ElementName = "PARK_TYPE_DESC", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public string PARK_TYPE_DESC { get; set; }
        [XmlElement(ElementName = "CAPACITY_OF_PARK", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public int? CAPACITY_OF_PARK { get; set; }
        [XmlElement(ElementName = "WORKING_TIME", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public string WORKING_TIME { get; set; }
        [XmlElement(ElementName = "COUNTY_NAME", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public string COUNTY_NAME { get; set; }
        [XmlElement(ElementName = "LONGITUDE", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public double? LONGITUDE { get; set; }
        [XmlElement(ElementName = "LATITUDE", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public double? LATITUDE { get; set; }
    }

    [XmlRoot(ElementName = "content", Namespace = "http://www.w3.org/2005/Atom")]
    public class Content
    {
        [XmlElement(ElementName = "properties", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public Properties Properties { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "entry", Namespace = "http://www.w3.org/2005/Atom")]
    public class Entry
    {
        [XmlElement(ElementName = "id", Namespace = "http://www.w3.org/2005/Atom")]
        public string Id { get; set; }
        [XmlElement(ElementName = "title", Namespace = "http://www.w3.org/2005/Atom")]
        public string Title { get; set; }
        [XmlElement(ElementName = "updated", Namespace = "http://www.w3.org/2005/Atom")]
        public DateTime Updated { get; set; }
        [XmlElement(ElementName = "author", Namespace = "http://www.w3.org/2005/Atom")]
        public Author Author { get; set; }
        [XmlElement(ElementName = "category", Namespace = "http://www.w3.org/2005/Atom")]
        public Category Category { get; set; }
        [XmlElement(ElementName = "content", Namespace = "http://www.w3.org/2005/Atom")]
        public Content Content { get; set; }
    }

    [XmlRoot(ElementName = "feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class Feed
    {
        [XmlElement(ElementName = "title", Namespace = "http://www.w3.org/2005/Atom")]
        public Title Title { get; set; }
        [XmlElement(ElementName = "id", Namespace = "http://www.w3.org/2005/Atom")]
        public string Id { get; set; }
        [XmlElement(ElementName = "updated", Namespace = "http://www.w3.org/2005/Atom")]
        public string Updated { get; set; }
        [XmlElement(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
        public List<Link> Link { get; set; }
        [XmlElement(ElementName = "entry", Namespace = "http://www.w3.org/2005/Atom")]
        public List<Entry> Entry { get; set; }
        [XmlAttribute(AttributeName = "base", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Base { get; set; }
        [XmlAttribute(AttributeName = "d", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string D { get; set; }
        [XmlAttribute(AttributeName = "m", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string M { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}