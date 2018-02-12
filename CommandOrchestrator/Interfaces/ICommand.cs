using System;

namespace CommandOrchestrator.Interfaces
{
    /// <summary>
    ///     Base command interface
    /// </summary>
    public interface ICommand : IDisposable
    {
        void Execute(ICommandContext context);

        void Rollback(ICommandContext context);
    }
}