using System;

namespace Sncf.Logging
{
    /// <summary>
    /// Logging factory that uses log4net as the backing implementation.
    /// </summary>
    public class LogFactory : ILogFactory
    {
        const string rootLogger = "root";

        public ILog GetLogger()
        {
            try
            {
                var st = new System.Diagnostics.StackTrace(1);
                var type = st.GetFrame(0).GetMethod().DeclaringType;
                return GetLogger(type);
            }
            catch (Exception)
            {
                return log4net.LogManager.GetLogger(rootLogger) as ILog;
            }
        }

        public ILog GetLogger(Type type)
        {
            return log4net.LogManager.GetLogger(type) as ILog;
        }
    }
}
