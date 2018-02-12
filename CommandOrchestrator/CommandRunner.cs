using System;

namespace CommandOrchestrator
{
    public class CommandRunner
    {
        private readonly ICommand _command;
        private readonly ICommandContext _context;

        public CommandRunner(ICommand command, ICommandContext commandContext = null)
        {
            _command = command;
            _context = commandContext ?? new CommandContext();
        }

        public void Run()
        {
            try
            {
                _command.Execute(_context);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(Environment.NewLine);

                _command.Rollback(_context);
            }
        }
    }
}