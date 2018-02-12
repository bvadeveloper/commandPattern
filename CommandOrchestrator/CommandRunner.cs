using System;
using CommandOrchestrator.Interfaces;

namespace CommandOrchestrator
{
    public class CommandRunner : ICommandRunner
    {
        private readonly ICommandContext _context;

        public CommandRunner(ICommandContext commandContext = null)
        {
            _context = commandContext ?? new CommandContext();
        }

        public void Run(ICommand command)
        {
            if (command == null) return;

            try
            {
                command.Execute(_context);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(Environment.NewLine);

                command.Rollback(_context);
            }
        }
    }
}