using System;
using System.Threading;

namespace CommandOrchestrator.Commands
{
    public class AddRegattaCommand : ICommand
    {
        private readonly string _regattaId;

        public AddRegattaCommand(string regattaId)
        {
            _regattaId = regattaId;
        }

        public void Execute(ICommandContext commandContext)
        {
            // payload 
            
            Console.WriteLine($"{typeof(AddRegattaCommand)} run");

            commandContext.Context["regattaId"] = _regattaId;
            Thread.Sleep(3000);
        }

        public void Rollback(ICommandContext commandContext)
        {
            Console.WriteLine($"{typeof(AddRegattaCommand)} rollback");
            Thread.Sleep(1000);
        }

        public void Dispose()
        {
        }
    }
} 