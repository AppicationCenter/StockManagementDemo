using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CMSSystems.StockManagementDemo.Common.Helpers
{
    public static class LogManager
    {

        private static readonly string logConfigFile = @"log4net.config";
        private static readonly log4net.ILog log = GetLogger(typeof(LogManager));

        #region Public Methods

        public static ILog GetLogger(Type type)
        {
            return log4net.LogManager.GetLogger(type);
        }

        public static void LogDebug(object message)
        {
            SetLog4NetConfiguration();
            log.Debug(message);
        }

        public static void LogInformation(object message)
        {
            SetLog4NetConfiguration();
            log.Info(message);
        }

        public static void LogError(object message)
        {
            SetLog4NetConfiguration();
            log.Error(message);
        }
        #endregion

        private static void SetLog4NetConfiguration()
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(logConfigFile));

            var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
        }
    }
}
