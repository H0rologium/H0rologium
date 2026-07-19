namespace BackupTool
{
    public class ToolController
    {
        #region fields

        private BackupToolWindow? _view;
        private ToolModel? _model;
        private BackupToolLogger _logger;
        public BackupToolWindow? View { get { return _view; } set { _view = value; } }
        public ToolModel? Model { get { return _model; } set { _model = value; } }

        #endregion

        public ToolController(BackupToolLogger logg)
        {
            _logger = logg;
        }


        public void UpdateBackupList(List<Dictionary<string,string>> locations)
        {
            _logger.LogMessage(BackupToolLogger.LogLevel.INFO, $"Will try to populate the view with {locations.Count} locations");
            foreach (Dictionary<string,string> loc in locations)
            {
                View.AddNewBackupLocation();
            }
        }
    }
}
