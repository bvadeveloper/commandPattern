using System.Collections.Generic;
using System.Linq;
using CommandOrchestrator.Interfaces;

namespace CommandOrchestrator
{
    /// <summary>
    ///     Command scope
    /// </summary>
    public class CommandScope : ICommand
    {
        /// <summary>
        ///     List of commands in the scope
        /// </summary>
        private IList<ICommand> _commands;

        /// <summary>
        ///     Executed commands in the scope
        /// </summary>
        private Stack<ICommand> _executedCommands;

        /// <summary>
        ///     Run scope of commands
        /// </summary>
        /// <param name="context"></param>
        public void Execute(ICommandContext context)
        {
            _executedCommands.Clear();

            foreach (var command in _commands)
            {
                _executedCommands.Push(command);
                command.Execute(context);
            }
        }

        /// <summary>
        ///     Rollback commands
        /// </summary>
        /// <param name="context"></param>
        public void Rollback(ICommandContext context)
        {
            while (_executedCommands.Any()) _executedCommands.Pop().Rollback(context);
        }

        public void Dispose()
        {
            _commands = null;
            _executedCommands.Clear();
            _executedCommands = null;
        }

        /// <summary>
        ///     Add command to scope
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public CommandScope Add(ICommand command)
        {
            _commands.Add(command);

            return this;
        }

        /// <summary>
        ///     Initialize command scope
        /// </summary>
        /// <returns></returns>
        public CommandScope Init()
        {
            _commands = new List<ICommand>();
            _executedCommands = new Stack<ICommand>();

            return this;
        }

        /// <summary>
        ///     Execute command scope on runner
        /// </summary>
        /// <param name="commandRunner"></param>
        public void Run(ICommandRunner commandRunner)
        {
            commandRunner?.Run(this);
        }
    }
}