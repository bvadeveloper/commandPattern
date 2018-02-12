using System;
using System.Collections.Generic;
using System.Threading;
using CommandOrchestrator.Interfaces;

namespace CommandOrchestrator.Commands
{
    public class FailureCommand : ICommand
    {
        public void Execute(ICommandContext commandContext)
        {
            // payload 

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Ship: {commandContext.Context["ship"]}");

            foreach (var teamMember in (List<string>) commandContext.Context["team"])
                Console.WriteLine($"Member: {teamMember}");

            Console.WriteLine($"Regatta ID {commandContext.Context["regattaId"]}");
            Console.WriteLine(Environment.NewLine);

            // throw exception
            throw new Exception("Something went wrong...");
        }

        public void Rollback(ICommandContext context)
        {
            Thread.Sleep(1000);
        }

        public void Dispose()
        {
        }
    }
}