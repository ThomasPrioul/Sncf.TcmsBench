using System;

namespace Sncf.Logging
{
    /// <summary>
    /// Logging layer interface.
    /// </summary>
    public interface ILogFactory
    {
        /// <summary>
        /// Gets a logger which name is of the caller's full type name.
        /// </summary>
        /// <returns>A logger instance that implements <see cref="ILog"/>.</returns>
        ILog GetLogger();

        /// <summary>
        /// Gets a logger which name is of the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">Type to use for the logger name.</param>
        /// <returns>A logger instance that implements <see cref="ILog"/>.</returns>
        ILog GetLogger(Type type);
    }
}
