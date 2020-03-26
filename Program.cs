using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace Sample
{
    internal class Program
    {
        public static int Main(string[] args)
        {
            var rootCommand = new RootCommand();

            // This command shows null
            // We have arity but the argument name is wrong
            var firstCommand = new Command("first")
            {
                Handler = CommandHandler.Create<string>(Add)
            };
            var argument1 = new Argument("Wrong Name")
            {
                Arity = ArgumentArity.ExactlyOne
            };
            firstCommand.AddArgument(argument1);

            // This command simply doesn't work
            // The argument name is right but no arity
            var secondCommand = new Command("second")
            {
                Handler = CommandHandler.Create<string>(Add)
            };
            var argument2 = new Argument("argumentName");
            secondCommand.AddArgument(argument2);

            // This one works
            var thirdCommand = new Command("third")
            {
                Handler = CommandHandler.Create<string>(Add)
            };
            var argument3 = new Argument("argumentName")
            {
                Arity =  ArgumentArity.ExactlyOne
            };
            thirdCommand.AddArgument(argument3);

            rootCommand.Add(firstCommand);
            rootCommand.Add(secondCommand);
            rootCommand.Add(thirdCommand);
            return rootCommand.Invoke(args);
        }

        private static void Add(string argumentName)
        {
            Console.WriteLine(argumentName);
        }
    }
}