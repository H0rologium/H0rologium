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
            XmlNodeList? locations = raw.SelectNodes(XPATH_BACKUPLOCATIONS);
            if (locations != null)
            {
                for (int i = 0; i < locations.Count; i++)
                {
                    Dictionary<string, string> entry = new Dictionary<string, string>();
                    entry.Add(KEY_BACKUPSOURCE, locations[i].SelectSingleNode(KEY_BACKUPSOURCE).Value);
                    entry.Add(KEY_BACKUPDESTINATION, locations[i].SelectSingleNode(KEY_BACKUPDESTINATION).Value);
                    entry.Add(KEY_INCLUDESUBFOLDERCONTENTS, locations[i].SelectSingleNode(KEY_INCLUDESUBFOLDERCONTENTS).Value);
                    entry.Add(KEY_EXTENSIONWHITELIST, locations[i].SelectSingleNode(KEY_EXTENSIONWHITELIST).Value);
                    entry.Add(KEY_EXTENSIONBLACKLIST, locations[i].SelectSingleNode(KEY_EXTENSIONBLACKLIST).Value);

                    BackupLocations.Append(entry);
                }
            }
            else
            {
                _logger.LogMessage(BackupToolLogger.LogLevel.WARNING, "Config was loaded without any backup locations set");
                BackupLocations = new List<Dictionary<string, string>>();
            }
        }
    }
}
