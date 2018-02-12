using System.Collections.Generic;
using System.Linq;

namespace CommandOrchestrator
{
    public class CommandScope : ICommand
    {
        /// <summary>
        /// List of commands in the scope
        /// </summary>
        private IEnumerable<ICommand> _commands;

        /// <summary>
        /// Executed commands in the scope
        /// </summary>
        private Stack<ICommand> _executedCommands;

        public CommandScope(IEnumerable<ICommand> comannds)
        {
            _commands = comannds;
            _executedCommands = new Stack<ICommand>();
        }

        public void Execute(ICommandContext context)
        {
            _executedCommands.Clear();

            foreach (var command in _commands)
            {
                _executedCommands.Push(command);
                command.Execute(context);
            }
        }

        public void Rollback(ICommandContext context)
        {
            while (_executedCommands.Any())
            {
                _executedCommands.Pop().Rollback(context);
            }
        }

        public void Dispose()
        {
            _commands = null;
            _executedCommands.Clear();
            _executedCommands = null;
        }
    }
}