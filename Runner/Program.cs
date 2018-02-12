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
            // context initialization if necessary
            var context = new CommandContext
            {
                Context = new Dictionary<string, object>
                {
                    ["team"] = new List<string>()
                }
            };

            var runner = new CommandRunner(context);

            // init command/transaction scope
            using (var scope = new CommandScope())
            {
                scope.Init()
                    .Add(new AddShipCommand("Black Cuttlefish"))
                    .Add(new AddTeamCommand("John Silver"))
                    .Add(new AddTeamCommand("Capitan Smollet"))
                    .Add(new AddTeamCommand("Doctor Livcy"))
                    .Add(new AddTeamCommand("Billi Bonc"))
                    .Add(new AddTeamCommand("Jim"))
                    .Add(new AddRegattaCommand(Guid.NewGuid().ToString()))
                    .Add(new FailureCommand())
                    .Run(runner);
            }
        }
    }
}