using System.Reflection;
using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config",Watch = true)]
namespace ClassLibrary1
{
    public class LogHelper
    {
       public static readonly ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void LogError(string message)
        {
            Log.Error(message);
        }
    }
}