using System;
using System.Collections.Generic;
using System.Threading;
using CommandOrchestrator.Interfaces;

namespace CommandOrchestrator.Commands
{
    public class AddTeamCommand : ICommand
    {
        private readonly string _name;

        public AddTeamCommand(string name)
        {
            _name = name;
        }

        public void Execute(ICommandContext commandContext)
        {
            // payload 

            Console.WriteLine($"{typeof(AddTeamCommand)} run");

            var teamList = commandContext.Context["team"] as List<string>;
            teamList?.Add(_name);

            Thread.Sleep(1000);
        }

        public void Rollback(ICommandContext commandContext)
        {
            Console.WriteLine($"{typeof(AddTeamCommand)} rollback");
            Thread.Sleep(1000);
        }

        public void Dispose()
        {
        }
    }
}