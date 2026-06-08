namespace BackupTool
{
    public class ToolModel
    {
        #region Fields
        private BackupToolWindow _view;
        private readonly BackupToolLogger _logger;
        private readonly string currentDIR;
        public BackupToolWindow View { get { return _view; } set { _view = value; } }
        public BackupToolLogger Logger { get { return _logger; } }
        #endregion
        public ToolModel(BackupToolLogger logClass, string location)
        {
            currentDIR = location;
            _logger = logClass;
        }


        public void LoadBackupData()
        {
            Logger.LogMessage(BackupToolLogger.LogLevel.INFO, $"Starting to load backup data from last recognized location: {currentDIR}");
            LoadBackupUserData(File.Exists(Path.Combine(currentDIR, "backupuserdata.xml")));
        }

        #region Private Methods
        private void LoadBackupUserData(bool makeNew)
        {
            if (!makeNew)
            {
                Logger.LogMessage(BackupToolLogger.LogLevel.INFO, "No user data found. Creating a new base file.");

            }
            else
            {

            }
        }
        #endregion
    }
}
