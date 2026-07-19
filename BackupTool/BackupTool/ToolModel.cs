using System.Reflection;

namespace BackupTool
{
    public class ToolModel
    {
        #region Fields
        private readonly BackupToolLogger _logger;
        private BackupConfig? _config;
        private readonly string currentDIR;
        private ToolController? _controller;
        public BackupToolLogger Logger { get { return _logger; } }
        public BackupConfig? Config { get { return _config; } set { _config = value; } }
        public ToolController? Controller { get { return _controller; } set { _controller = value; } }
        #endregion
        public ToolModel(BackupToolLogger logClass, string location)
        {
            currentDIR = location;
            _logger = logClass;
        }


        public void LoadBackupData()
        {
            Logger.LogMessage(BackupToolLogger.LogLevel.INFO, $"Starting to load backup data from last recognized location: {currentDIR}");
            LoadBackupUserData(!File.Exists(Path.Combine(currentDIR, "backupuserdata.xml")));
        }

        #region Private Methods
        private void LoadBackupUserData(bool makeNew)
        {
            string path = $"{System.Reflection.Assembly.GetExecutingAssembly().Location}/backupconfig.xml";
            if (makeNew)
            {
                Logger.LogMessage(BackupToolLogger.LogLevel.INFO, "No user data found. Creating a new base file.");
                //I dont see any major updates to the structure of the XML happening anytime soon, however if there are changes, we will want to revisit this line to ensure existing
                //config files are updated with new XML.
                Config = new BackupConfig(BackupToolFileSystem.MakeConfig(),_logger);
            }
            else
            {
                Config = new BackupConfig(BackupToolFileSystem.LoadConfig(path),_logger);
            }
            Controller.UpdateBackupList(Config.BackupLocations);
        }
        #endregion
    }
}
