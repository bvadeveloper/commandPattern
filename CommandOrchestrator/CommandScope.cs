using System.Collections.Generic;
using System.Linq;
using CommandOrchestrator.Interfaces;

namespace CommandOrchestrator
{
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
            while (_executedCommands.Any()) _executedCommands.Pop().Rollback(context);
        }

        public void Dispose()
        {
            _commands = null;
            _executedCommands.Clear();
            _executedCommands = null;
        }

        public CommandScope Add(ICommand command)
        {
            _commands.Add(command);

            return this;
        }

        public CommandScope Init()
        {
            _commands = new List<ICommand>();
            _executedCommands = new Stack<ICommand>();

            return this;
        }

        public void Run(ICommandRunner commandRunner)
        {
            commandRunner.Run(this);
        }
    }
}