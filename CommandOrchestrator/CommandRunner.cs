using System;

namespace CommandOrchestrator
{
    public class CommandRunner : IDisposable
    {
        private readonly ICommand _command;
        private readonly ICommandContext _context;

        public CommandRunner(ICommand command, ICommandContext context)
        {
            _command = command;
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
            _command.Dispose();
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