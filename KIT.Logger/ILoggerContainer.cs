using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT.Logger
{
    /// <summary>
    ///     Logging interface.
    ///     Application references single interface container.
    /// </summary>
    public interface ILoggerContainer
    {
        /// <summary>
        ///     Get session
        /// </summary>
        /// <returns></returns>
        public Guid GetSession();

        /// <summary>
        ///     Override session
        /// </summary>
        /// <param name="newGuid"></param>
        public void OverrideSession(Guid newGuid);

        /// <summary>
        ///     Write simple data
        /// </summary>
        /// <param name="data"></param>
        public void Write(string data, LogEventLevel logLevel);

        /// <summary>
        ///     Write complex event
        /// </summary>
        /// <typeparam name="T">main object</typeparam>
        /// <param name="action">function name, where logging happened</param>
        /// <param name="object">data</param>
        /// <param name="extraData">additional data</param>
        public void Write<T>(string action, T @object, LogEventLevel logLevel, params string[] extraData);
    }
}
