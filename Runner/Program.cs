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
            var commandScope = new CommandScope(new List<ICommand>
            {
                new AddShipCommand("Black Cuttlefish"),

                new AddTeamCommand("John Silver"),
                new AddTeamCommand("Capitan Smollet"),
                new AddTeamCommand("Doctor Livcy"),
                new AddTeamCommand("Billi Bonc"),
                new AddTeamCommand("Jim"),

                new AddRegattaCommand(Guid.NewGuid().ToString()),
                
                new FailureCommand()
            });
            
            // init context if you need
            var commandContext = new CommandContext{Context = new Dictionary<string, object>
            {
                ["team"] = new List<string>(),
            }};

            using (var commandRunner = new CommandRunner(commandScope, commandContext))
            {
                commandRunner.Run();
            }

            Console.ReadKey();
        }
    }
}