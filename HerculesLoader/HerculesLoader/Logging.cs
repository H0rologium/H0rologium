namespace HerculesLoader
{
    public class Logging
    {
        private int storedMessages = 0;
        private string[] msgHistory = new string[50];
        public void LogInfo(string msg)
        {
            string msgOut = $"[INFO] {msg}";
            Console.WriteLine(msgOut);
            WriteToMsgHistory(msgOut);
        }

        public void LogWarning(string msg)
        {
            string msgOut = $"[WARNING] {msg}";
            Console.WriteLine(msgOut);
            WriteToMsgHistory(msgOut);
        }

        public void LogError(string msg)
        {
            string msgOut = $"[ERROR] {msg}";
            Console.WriteLine(msgOut);
            WriteToMsgHistory(msgOut);
        }

        private void WriteToMsgHistory(string newMsg)
        {
            if (msgHistory[storedMessages] == String.Empty)
            {
                msgHistory[storedMessages] = newMsg;
                storedMessages++;
            }
            if (storedMessages >= msgHistory.Length)
            {
                msgHistory[0] = String.Empty;
                for (int i = 1; i < msgHistory.Length; i++)
                {
                    msgHistory[i-1] = (i == (msgHistory.Length-1)?String.Empty:msgHistory[i]);
                }
            }
        }
    }
}
