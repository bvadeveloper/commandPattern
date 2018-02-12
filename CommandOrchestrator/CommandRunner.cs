using System;
using CommandOrchestrator.Interfaces;

namespace CommandOrchestrator
{
    /// <summary>
    ///     Simple command runner
    /// </summary>
    public class CommandRunner : ICommandRunner
    {
        private readonly ICommandContext _context;

        /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="commandContext"></param>
        public CommandRunner(ICommandContext commandContext = null)
        {
            _context = commandContext ?? new CommandContext();
        }

        /// <summary>
        ///     Command runner
        /// </summary>
        /// <param name="command"></param>
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