using System;
using System.IO;
using System.Text;

namespace Logger
{
    public class Log : ILog
    {
        private Log()
        {

        }

        private static readonly Lazy<Log> instance = new Lazy<Log>(() => new Log());

        public static Log GetInstance
        {
            get
            {
                return instance.Value;
            }
        }

        public void LogException(string message)
        {
            string fileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToShortDateString());
            string logFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("-------------------------------------------------------");
            stringBuilder.AppendLine(DateTime.Now.ToString());
            stringBuilder.AppendLine(message);

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.Write(stringBuilder.ToString());
                writer.Flush();
            }
        }
    }
}
