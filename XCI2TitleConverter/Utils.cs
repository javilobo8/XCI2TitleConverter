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

        // Thanks to @PRAGMA - https://github.com/imPRAGMA/LFSKit
        public static byte[] patchTitleId(byte[] source, byte[] titleBytes, int offset = 0)
        {
            //Get to the next 0x41 byte (A)
            while (source[offset] != 0x41)
            {
                offset++;
            }

            //Loop if the next HEX bytes arent: 43 49 30 (CI0)
            //These are seperate if's to accomodate offset so its exactly 1 index off from what it just tried, so it doesnt just match 0 on re-loop
            if (source[++offset] != 0x43)
            {
                return patchTitleId(source, titleBytes, offset);
            }
        
            if (source[++offset] != 0x49)
            {
                return patchTitleId(source, titleBytes, offset);
            }

            if (source[++offset] != 0x30)
            {
                return patchTitleId(source, titleBytes, offset);
            }

            //Check if the next 12 bytes are 0x00
            for (int i = 0; i < 12; i++)
            {
                ++offset;
                if (source[offset] != 0x00)
                {
                    return patchTitleId(source, titleBytes, (offset - (i + 1))); //reloop
                }
            }

            //We are now at the end of ASIC0............
            //Now just overwrite the next 8 indexes (current titleid) with the new titleid bytes
            for (int i = 1; i <= 8; i++)
            {
                source[(offset + i)] = titleBytes[i - 1];
            }

            //return the patched source
            return source;
        }
    }
}
