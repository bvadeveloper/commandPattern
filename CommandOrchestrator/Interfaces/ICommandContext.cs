using System;
using System.Collections.Generic;

namespace CommandOrchestrator.Interfaces
{
    /// <summary>
    ///     Context storage inteface
    /// </summary>
    public interface ICommandContext : IDisposable
    {
        Dictionary<string, object> Context { get; set; }
    }
}