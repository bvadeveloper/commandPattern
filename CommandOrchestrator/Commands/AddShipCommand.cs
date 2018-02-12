using System;
using System.Threading;
using CommandOrchestrator.Interfaces;

namespace CommandOrchestrator.Commands
{
    public class AddShipCommand : ICommand
    {
        private readonly string _shipName;

        public AddShipCommand(string ship)
        {
            _shipName = ship;
        }

        public void Execute(ICommandContext commandContext)
        {
            // payload 

            Console.WriteLine($"{typeof(AddShipCommand)} run");

            commandContext.Context["ship"] = _shipName;
            Thread.Sleep(2000);
        }

        public void Rollback(ICommandContext commandContext)
        {
            Console.WriteLine($"{typeof(AddShipCommand)} rollback");
            Thread.Sleep(1000);
        }

        public void Dispose()
        {
        }
    }
}