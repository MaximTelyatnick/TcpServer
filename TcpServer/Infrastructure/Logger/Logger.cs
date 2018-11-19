using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVM_WMS.SERVER.Infrastructure.Logger
{
    public static class Logger
    {
        private static ILog log = log4net.LogManager.GetLogger("LOGGER");

        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            if (ConfigClass.Instance.GlobalLocalSettings.LogFilePath.Length > 0)
            {
                if (!Directory.Exists(ConfigClass.Instance.GlobalLocalSettings.LogFilePath + "\\Logs"))
                    Directory.CreateDirectory(ConfigClass.Instance.GlobalLocalSettings.LogFilePath + "\\Logs");

                log4net.GlobalContext.Properties["LogFileName"] = ConfigClass.Instance.GlobalLocalSettings.LogFilePath;

                XmlConfigurator.Configure();
            }
            else
            {
                log4net.GlobalContext.Properties["LogFileName"] = Directory.GetCurrentDirectory();

                XmlConfigurator.Configure();
            }
        }

        public static void LogControl(int daysAmount)
        {
            if (ConfigClass.Instance.GlobalLocalSettings.LogFilePath.Length > 0)
            {
                if (!Directory.Exists(ConfigClass.Instance.GlobalLocalSettings.LogFilePath + "\\Logs"))
                    return;

                string[] allLogDirectories = Directory.GetDirectories(ConfigClass.Instance.GlobalLocalSettings.LogFilePath + "\\Logs");
                foreach (string currentDirectory in allLogDirectories)
                {
                    DirectoryInfo currentDirectoryInfo = new DirectoryInfo(currentDirectory);
                    if (currentDirectoryInfo.CreationTime < DateTime.Now.AddDays((-1) * daysAmount))
                        Directory.Delete(currentDirectory, true);
                }
            }
        }

    }
}
