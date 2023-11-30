using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Lwgh
{
    public class Settings
    {
        private static Dictionary<string, string>? settingsDict;

        public static string GetUserHome()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        public static string GetSettingsXmlPath()
        {
            return $"{GetUserHome()}/Lwgh.xml";
        }

        public static void InitSettingsDict()
        {
            settingsDict = new();
        }

        public static void WriteSettings()
        {
            // make sure settings dict is not null
            if (settingsDict == null)
            {
                InitSettingsDict();
            }

            XmlDocument doc = new();
            doc.AppendChild(doc.CreateProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\""));
            XmlElement root = doc.CreateElement("Settings");
            doc.AppendChild(root);

            foreach (var k in settingsDict)
            {
                string settingName = k.Key;
                string settingValue = k.Value;

                XmlElement elem = doc.CreateElement("Setting");
                elem.SetAttribute("Name", settingName);
                elem.SetAttribute("Value", settingValue);
                root.AppendChild(elem);
            }

            doc.Save(GetSettingsXmlPath());
        }

        public static void ReadSettings()
        {
            // make sure that settings array is not null
            if (settingsDict == null)
            {
                InitSettingsDict();
            }

            XmlDocument doc = new();

            try
            {
                doc.Load(GetSettingsXmlPath());
            }
            catch (FileNotFoundException exc)
            {
                // config wasn't found; just empty it
                InitSettingsDict();
                return;
            }

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string name = node.Attributes["Name"].InnerXml;
                string val = node.Attributes["Value"].InnerXml;
                settingsDict[name] = val;
            }
        }

        public static string GetSetting(string name)
        {
            if (settingsDict == null)
            {
                InitSettingsDict();
            }

            return settingsDict[name];
        }

        public static void SetSetting(string name, string val)
        {
            if (settingsDict == null)
            {
                InitSettingsDict();
            }

            settingsDict[name] = val;
        }

        private Settings()
        {
        }
    }
}
