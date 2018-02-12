using System.Collections.Generic;
using CommandOrchestrator.Interfaces;

namespace CommandOrchestrator
{
    /// <summary>
    ///     Context storage
    /// </summary>
    public class CommandContext : ICommandContext
    {
        /// <summary>
        ///     Ctor
        /// </summary>
        public CommandContext()
        {
            // init common fields for context, if necessary
            Context = new Dictionary<string, object>();
        }

        /// <summary>
        ///     Simple context storage
        /// </summary>
        public Dictionary<string, object> Context { get; set; }

        public void Dispose()
        {
            Context.Clear();
            Context = null;
        }
    }
}