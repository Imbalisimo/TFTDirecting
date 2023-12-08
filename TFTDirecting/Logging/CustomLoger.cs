using System.Text;

namespace TFTDirecting.Logging
{
    public class CustomLogger : ILogger
    {
        private readonly string _name;
        private readonly CustomFileLoggerConfiguration _config;
        private LogLevel _logLevel;

        public CustomLogger(string name, CustomFileLoggerConfiguration config)
        {
            _name = name;
            _config = config;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _config.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
            _logLevel = logLevel;
            FileLog($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:fff")} - {logLevel.ToString()} - {_name} - {formatter(state, exception)}");
        }

        private async void FileLog(string strLog)
        {
            //var sb = new StringBuilder(strLog);
            //sb.AppendLine();
            //var targetstr = sb.ToString();
            //string fileName = DateTime.Now.ToString("yyyy-MM-dd") + "_" + _logLevel.ToString() + "23.txt";
            //string filePath = _config.LogPath + "\\" + fileName;
            //File.AppendAllText(filePath, strLog);
            //await File.AppendAllTextAsync(filePath, targetstr);
        }
    }

    public class CustomFileLoggerConfiguration
    {
        public LogLevel LogLevel { get; set; }
        public string LogPath { get; set; }
    }


    public class CustomFileLoggerProvider : ILoggerProvider
    {

        private readonly CustomFileLoggerConfiguration _config;

        public CustomFileLoggerProvider(CustomFileLoggerConfiguration config)
        {
            this._config = config;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new CustomLogger(categoryName, _config);
        }

        public void Dispose()
        {

        }
    }
}
