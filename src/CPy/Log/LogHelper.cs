using log4net;
using log4net.Core;

[assembly: log4net.Config.XmlConfigurator(Watch = true)] 
namespace CPy.Log
{
    public class LogHelper
    {
        private static readonly ILog _log = LogManager.GetLogger("log4net");
        public static void Info(string message)
        {
            _log.Info(message);
        }

        public static void Error(string message)
        {
            _log.Error(message);
        }


        //public static void Debug(string message)
        //{
        //    _log.Debug(message);
        //}

        //public static void Fatal(string message)
        //{
        //    _log.Fatal(message);
        //}

        //public static void Warn(string message)
        //{
        //    _log.Warn(message);
        //}
    }
}