using System.Collections.Generic;
using CommandOrchestrator.Interfaces;

namespace CommandOrchestrator
{
    /// <summary>
    ///     Context storage
    /// </summary>
    public class CommandContext : ICommandContext
    {
        public CommandContext()
        {
            // init common fields for context, if necessary
            Context = new Dictionary<string, object>();
        }

        public Dictionary<string, object> Context { get; set; }

        public void Dispose()
        {
            Context.Clear();
            Context = null;
        }
    }
}