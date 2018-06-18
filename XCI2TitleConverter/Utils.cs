using System;
using System.Reflection;

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
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            return String.Format("{0} {1}.{2}.{3}-{4}", name, version.Major, version.Minor, version.Build, version.Revision);
        }

        public static string getAssemblyTitle()
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }
    }
}
