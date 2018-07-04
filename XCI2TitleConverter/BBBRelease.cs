using System.Xml;

namespace XCI2TitleConverter
{
    class BBBRelease
    {
        public string id { get; set; }
        public string name { get; set; }
        public string publisher { get; set; }
        public string region { get; set; }
        public string languages { get; set; }
        public string group { get; set; }
        public string imagesize { get; set; }
        public string serial { get; set; }
        public string titleid { get; set; }
        public string imgcrc { get; set; }
        public string filename { get; set; }
        public string releasename { get; set; }
        public string trimmedsize { get; set; }
        public string firmware { get; set; }
        public string type { get; set; }
        public string card { get; set; }

        public BBBRelease(XmlNode release)
        {
            id = release["id"].InnerText;
            name = release["name"].InnerText;
            publisher = release["publisher"].InnerText;
            region = release["region"].InnerText;
            languages = release["languages"].InnerText;
            group = release["group"].InnerText;
            imagesize = release["imagesize"].InnerText;
            serial = release["serial"].InnerText;
            titleid = release["titleid"].InnerText;
            imgcrc = release["imgcrc"].InnerText;
            filename = release["filename"].InnerText;
            releasename = release["releasename"].InnerText;
            trimmedsize = release["trimmedsize"].InnerText;
            firmware = release["firmware"].InnerText;
            type = release["type"].InnerText;
            card = release["card"].InnerText;
        }
    }
}
