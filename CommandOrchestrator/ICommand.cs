using System;

namespace CommandOrchestrator
{
    /// <summary>
    /// Base command interface
    /// </summary>
    public interface ICommand : IDisposable
    {
        void Execute(ICommandContext context);

        void Rollback(ICommandContext context);
    }
}