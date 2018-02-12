using System;
using System.Collections.Generic;

namespace CommandOrchestrator
{
    /// <summary>
    /// Context storage implementation
    /// </summary>
    public class CommandContext : ICommandContext
    {
        public Dictionary<string, object> Context { get; set; }

        public CommandContext()
        {
            // init common fields for context, if necessary
            Context = new Dictionary<string, object>();
        }

        public void Dispose()
        {
            Context.Clear();
            Context = null;
        }
    }
}