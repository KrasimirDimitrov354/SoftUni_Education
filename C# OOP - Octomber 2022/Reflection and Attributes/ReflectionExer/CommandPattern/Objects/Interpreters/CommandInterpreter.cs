using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public CommandInterpreter()
        {

        }

        public string Read(string args)
        {
            string[] commandArgs = args.Split();
            string commandName = commandArgs[0];

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Type commandClass = Type.GetType(currentAssembly
                .GetTypes()
                .Where(t => t.FullName.Contains(commandName))
                .FirstOrDefault()
                .FullName);

            var commandInstance = (ICommand)Activator.CreateInstance(commandClass);
            return commandInstance.Execute
                (commandArgs.Skip(1).ToArray());
        }
    }
}
