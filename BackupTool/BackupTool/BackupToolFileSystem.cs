using System.Xml;

namespace BackupTool
{
    public static class BackupToolFileSystem
    {
        #region Configuration
        /// <summary>
        /// When generating the base config, we expect the data to be very minimal, to get the program going.
        /// XmlDocument is fine for this use case.
        /// </summary>
        /// <returns>A new XmlDocument with the necessary node tree for config.</returns>
        public static XmlDocument MakeConfig()
        {
            XmlDocument doc = new XmlDocument();
            doc.CreateXmlDeclaration("1.0", "utf-8",null);
            XmlElement rtCfg = (XmlElement)doc.AppendChild(doc.CreateElement("BackupConfig"));
            rtCfg.AppendChild(doc.CreateElement("BackupLocations"));
            XmlElement delOnBackup = (XmlElement)rtCfg.AppendChild(doc.CreateElement("DeleteBeforeBackup"));
            delOnBackup.Value = false.ToString().ToLower();

            return doc;
        }

        /// <summary>
        /// Loads a config XML from the indicated path
        /// </summary>
        /// <param name="path">Path to the XML to load.</param>
        /// <returns>a loaded XmlDocument</returns>
        public static XmlDocument LoadConfig(string path)
        {
            XmlDocument doc = new XmlDocument();
            //TODO: Catch and handle errors when trying to load/parse
            doc.Load(XmlReader.Create(path));
            return doc;
        }

        #endregion
    }
}
