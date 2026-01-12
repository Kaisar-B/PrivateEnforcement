using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;

namespace KIT.Logger
{
    /// <summary>
    ///     Specific implementation of logging interface/
    ///     Current Serilog, allows easy future swap of implementations.
    ///     Change DI registration for ILogger implementation
    /// </summary>
    public class SerilogContainer : ILoggerContainer
    {
        private Serilog.ILogger _serilogLogger;
        private Guid _session;

        public SerilogContainer(ILogger serilogLogger)
        {
            _serilogLogger = serilogLogger;
            _session = Guid.NewGuid();
        }


        /// <summary>
        ///     Guid of session
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Guid GetSession()
        {
            return _session;
        }

        /// <summary>
        ///     Override session
        /// </summary>
        /// <param name="newGuid"></param>
        public void OverrideSession(Guid newGuid)
        {
            _session = Guid.NewGuid();
        }

        /// <summary>
        ///     Write log
        /// </summary>
        /// <param name="data"></param>
        /// <param name="logLevel"></param>
        public void Write(string data, LogEventLevel logLevel)
        {
            _serilogLogger.Write(logLevel, data);
        }

        /// <summary>
        ///     Write complex log
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="object"></param>
        /// <param name="logLevel"></param>
        /// <param name="extraData"></param>
        public void Write<T>(string action, T @object, LogEventLevel logLevel, params string[] extraData)
        {
            _serilogLogger.Write(logLevel, "{Session} {Action} {@Data} {Extra}", GetSession(), action, @object, extraData);
        }
    }
}
