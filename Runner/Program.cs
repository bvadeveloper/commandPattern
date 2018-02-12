using System;
using System.Collections.Generic;
using CommandOrchestrator;
using CommandOrchestrator.Commands;

namespace Runner
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // init command/transaction scope
            var commandScope = new CommandScope()
                .Init()
                .Add(new AddShipCommand("Black Cuttlefish"))
                .Add(new AddTeamCommand("John Silver"))
                .Add(new AddTeamCommand("Capitan Smollet"))
                .Add(new AddTeamCommand("Doctor Livcy"))
                .Add(new AddTeamCommand("Billi Bonc"))
                .Add(new AddTeamCommand("Jim"))
                .Add(new AddRegattaCommand(Guid.NewGuid().ToString()))
                .Add(new FailureCommand());

            // context initialization if necessary
            var commandContext = new CommandContext
            {
                Context = new Dictionary<string, object>
                {
                    ["team"] = new List<string>()
                }
            };

            using (var commandRunner = new CommandRunner(commandScope, commandContext))
            {
                commandRunner.Run();
            }

            Console.ReadKey();
        }
    }
}