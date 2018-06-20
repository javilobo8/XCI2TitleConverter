using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Xml;

namespace XCI2TitleConverter
{
    class Utils
    {
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public static string getWindowTitle()
        {
            string name = Assembly.GetExecutingAssembly().GetName().Name;
            return String.Format("{0} {1}", name, Properties.Settings.Default["version"]);
        }

        public static string getAssemblyTitle()
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }

        public static List<BBBRelease> getBBBReleases()
        {
            List<BBBRelease> releases = new List<BBBRelease>();

            try
            {
                string responseText = string.Empty;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Constants.BBB_RELEASES_URL);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    responseText = reader.ReadToEnd();
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(responseText);
                    foreach (XmlElement release in xml.DocumentElement.ChildNodes)
                        releases.Add(new BBBRelease(release));
                }
            } catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine(String.Format("Obtained {0} releases from BBB", releases.Count));
            return releases;
        }
    }
}
