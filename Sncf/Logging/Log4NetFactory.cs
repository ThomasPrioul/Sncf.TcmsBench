﻿using log4net;
using System;
using System.Diagnostics;
using log4net.Core;
using log4net.Repository.Hierarchy;
using System.Runtime.CompilerServices;

namespace Sncf.Logging
{
    /// <summary>
    /// Logging factory that uses log4net as the backing implementation.
    /// </summary>
    public class Log4NetFactory : ILogFactory
    {
        const string rootLogger = "root";

        public ILog GetLogger()
        {
#if WINDOWS_UWP
            throw new PlatformNotSupportedException();
#else
            try
            {
                var st = new StackTrace(1);
                var type = st.GetFrame(0).GetMethod().DeclaringType;
                return GetLogger(type);
            }
            catch (Exception)
            {
                return new Logger(LogManager.GetLogger(rootLogger));
            }
#endif
        }

        public ILog GetLogger(Type type)
        {
            log4net.ILog log = LogManager.GetLogger(type);
            var repos = LogManager.GetAllRepositories();
            return new Logger(log);
        }

        public class Logger : ILog
        {
            readonly log4net.ILog logger;

            public bool IsDebugEnabled => logger.IsDebugEnabled;
            public bool IsInfoEnabled => logger.IsInfoEnabled;
            public bool IsWarnEnabled => logger.IsWarnEnabled;
            public bool IsErrorEnabled => logger.IsErrorEnabled;
            public bool IsFatalEnabled => logger.IsFatalEnabled;

            ILogger ILoggerWrapper.Logger => logger.Logger;

            public Logger(log4net.ILog logger)
            {
                this.logger = logger;
            }

            public void Debug(object message) => logger.Debug(message);
            public void Debug(object message, Exception exception) => logger.Debug(message, exception);
            public void DebugFormat(string format, params object[] args) => logger.DebugFormat(format, args);
            public void DebugFormat(string format, object arg0) => logger.DebugFormat(format, arg0);
            public void DebugFormat(string format, object arg0, object arg1) => logger.DebugFormat(format, arg0, arg1);
            public void DebugFormat(string format, object arg0, object arg1, object arg2) => logger.DebugFormat(format, arg0, arg1, arg2);
            public void DebugFormat(IFormatProvider provider, string format, params object[] args) => logger.DebugFormat(provider, format, args);

            public void Error(object message) => logger.Error(message);
            public void Error(object message, Exception exception) => logger.Error(message, exception);
            public void ErrorFormat(string format, params object[] args) => logger.ErrorFormat(format, args);
            public void ErrorFormat(string format, object arg0) => logger.ErrorFormat(format, arg0);
            public void ErrorFormat(string format, object arg0, object arg1) => logger.ErrorFormat(format, arg0, arg1);
            public void ErrorFormat(string format, object arg0, object arg1, object arg2) => logger.ErrorFormat(format, arg0, arg1, arg2);
            public void ErrorFormat(IFormatProvider provider, string format, params object[] args) => logger.ErrorFormat(provider, format, args);

            public void Fatal(object message) => logger.Fatal(message);
            public void Fatal(object message, Exception exception) => logger.Fatal(message, exception);
            public void FatalFormat(string format, params object[] args) => logger.FatalFormat(format, args);
            public void FatalFormat(string format, object arg0) => logger.FatalFormat(format, arg0);
            public void FatalFormat(string format, object arg0, object arg1) => logger.FatalFormat(format, arg0, arg1);
            public void FatalFormat(string format, object arg0, object arg1, object arg2) => logger.FatalFormat(format, arg0, arg1, arg2);
            public void FatalFormat(IFormatProvider provider, string format, params object[] args) => logger.FatalFormat(provider, format, args);

            public void Info(object message) => logger.Info(message);
            public void Info(object message, Exception exception) => logger.Info(message, exception);
            public void InfoFormat(string format, params object[] args) => logger.InfoFormat(format, args);
            public void InfoFormat(string format, object arg0) => logger.InfoFormat(format, arg0);
            public void InfoFormat(string format, object arg0, object arg1) => logger.InfoFormat(format, arg0, arg1);
            public void InfoFormat(string format, object arg0, object arg1, object arg2) => logger.InfoFormat(format, arg0, arg1, arg2);
            public void InfoFormat(IFormatProvider provider, string format, params object[] args) => logger.InfoFormat(provider, format, args);

            public void Warn(object message) => logger.Warn(message);
            public void Warn(object message, Exception exception) => logger.Warn(message, exception);
            public void WarnFormat(string format, params object[] args) => logger.WarnFormat(format, args);
            public void WarnFormat(string format, object arg0) => logger.WarnFormat(format, arg0);
            public void WarnFormat(string format, object arg0, object arg1) => logger.WarnFormat(format, arg0, arg1);
            public void WarnFormat(string format, object arg0, object arg1, object arg2) => logger.WarnFormat(format, arg0, arg1, arg2);
            public void WarnFormat(IFormatProvider provider, string format, params object[] args) => logger.WarnFormat(provider, format, args);
        }
    }
}
