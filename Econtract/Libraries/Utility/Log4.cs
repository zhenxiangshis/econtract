using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace Utility
{
    public class Log4
    {
        // Fields
        private static ILog log;

        // Methods
        public Log4()
        {
            log = LogManager.GetLogger("Application");
        }

        public Log4(string logname)
        {
            log = LogManager.GetLogger(logname);
        }

        public void Debug(string message)
        {
            try
            {
                log.Debug(message);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Logger.Debug() failed on logging '{0}'.", message), e);
            }
        }

        public void Debug(string message, Exception exception)
        {
            try
            {
                log.Debug(message, exception);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Logger.Debug() failed on logging '{0}'.", message + "::" + exception.Message), e);
            }
        }

        public void Error(string message)
        {
            try
            {
                log.Error(message);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Logger.Error() failed on logging '{0}'.", message), e);
            }
        }

        public void Error(string message, Exception e)
        {
            try
            {
                log.Error(message, e);
            }
            catch (Exception err)
            {
                throw new ApplicationException(string.Format("Logger.Error() failed on logging '{0}'.", message), err);
            }
        }

        public void Fatal(string message)
        {
            try
            {
                log.Fatal(message);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Logger.Fatal() failed on logging '{0}'.", message), e);
            }
        }

        public void Fatal(string message, Exception exception)
        {
            try
            {
                log.Fatal(message, exception);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Logger.Fatal() failed on logging '{0}'.", message + "::" + exception.Message), e);
            }
        }

        public void Info(string message)
        {
            try
            {
                log.Info(message);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Logger.Info() failed on logging '{0}'.", message), e);
            }
        }

        public void Info(string message, Exception exception)
        {
            try
            {
                log.Info(message, exception);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Logger.Info() failed on logging '{0}'.", message + "::" + exception.Message), e);
            }
        }

        public void Warning(string message)
        {
            try
            {
                log.Warn(message);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Logger.Warn() failed on logging '{0}'.", message), e);
            }
        }

        public void Warning(string message, Exception exception)
        {
            try
            {
                log.Warn(message, exception);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Logger.Warn() failed on logging '{0}'.", message + "::" + exception.Message), e);
            }
        }


    }
}
