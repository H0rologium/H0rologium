using System.Xml;

namespace BackupTool
{
    /// <summary>
    /// Handles the overall configuration of backups.
    /// </summary>
    public class BackupConfig
    {
        #region Dictionary Keys
        private const string KEY_BACKUPSOURCE = "BKUPSRC";
        private const string KEY_BACKUPDESTINATION = "BKUPDEST";
        private const string KEY_INCLUDESUBFOLDERCONTENTS = "INCLSUBFOLDERS";
        private const string KEY_EXTENSIONWHITELIST = "EXTWL";
        private const string KEY_EXTENSIONBLACKLIST = "EXTBL";

        private const string XPATH_BACKUPLOCATIONS = "/BackupConfig/BackupLocations";
        #endregion

        private bool deleteOnBackup;
        private List<Dictionary<string,string>> backupLocations;
        private BackupToolLogger _logger;

        public bool DeleteOnBackup { get { return deleteOnBackup; } set { deleteOnBackup = value; } }
        public List<Dictionary<string,string>> BackupLocations { get { return backupLocations; } set { backupLocations = value; } }
        public BackupConfig(XmlDocument raw, BackupToolLogger logg)
        {
            _logger = logg;
            //Select the root node holding the location children nodes
            XmlNode? locations = raw.SelectSingleNode(XPATH_BACKUPLOCATIONS);
            BackupLocations = new List<Dictionary<string, string>>();
            if (locations != null)
            {
                //For each location, add them as their own entries into a dictionary we use to populate instances of a UserControl
                for (int i = 0; i < locations.ChildNodes.Count; i++)
                {
                    Dictionary<string, string> entry = new Dictionary<string, string>();
                    entry.Add(KEY_BACKUPSOURCE, locations.ChildNodes[i].SelectSingleNode(KEY_BACKUPSOURCE).InnerText);
                    entry.Add(KEY_BACKUPDESTINATION, locations.ChildNodes[i].SelectSingleNode(KEY_BACKUPDESTINATION).InnerText);
                    entry.Add(KEY_INCLUDESUBFOLDERCONTENTS, locations.ChildNodes[i].SelectSingleNode(KEY_INCLUDESUBFOLDERCONTENTS).InnerText);
                    entry.Add(KEY_EXTENSIONWHITELIST, locations.ChildNodes[i].SelectSingleNode(KEY_EXTENSIONWHITELIST).InnerText);
                    entry.Add(KEY_EXTENSIONBLACKLIST, locations.ChildNodes[i].SelectSingleNode(KEY_EXTENSIONBLACKLIST).InnerText);

                    BackupLocations.Append(entry);
                }
            }
            else
            {
                _logger.LogMessage(BackupToolLogger.LogLevel.WARNING, "Config was loaded without any backup locations set");
            }
        }
    }
}
