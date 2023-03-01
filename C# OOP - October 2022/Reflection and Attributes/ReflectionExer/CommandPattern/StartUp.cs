using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    //Command Pattern - 0/100
    //Create a command pattern design using reflection.
    //
    //The input of commands will be received until the "Exit" command. Each command line will look as it follows: "{CommandName} {CommandArgs}".
    //CommandName will be as follows: "Hello" -> executing HelloCommand and so on.
    //
    //There are a few steps you can follow to employ the command pattern design:
    //  •	Create a Command interface ICommand, which contains a method Execute(string[] args). 
    //  •	Create Command objects:
    //      •	HelloCommand - the result from its execution should be: $"Hello, {args[0]}".
    //      •	ExitCommand - it should exit the program and return null.
    //  •	Create a Command Interpreter interface ICommandInterpreter, which contains a method Read(string args).
    //  •	Create a Command Interpreter class. Its purpose is to read commands, execute them and return the result from their execution.
    //  •	Create a class Engine, which contains a void Run() method. It should hold the following attributes:
    //      •	a private readonly ICommandInterpreter field named commandInterpreter;
    //      •	a public constructor which accepts an ICommandInterpreter object.
    //  The Run() method should accept input from the console and pass it to the proper class, as well as print the output from the commands.

    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
