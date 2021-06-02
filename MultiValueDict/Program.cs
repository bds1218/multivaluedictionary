using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiValueDict
{
    public class Program
    {
        private static MultiValueDictionary _dictionary;
        private static Dictionary<string, ICommand> _commandDictionary;

        private static bool _quit;

        public static void Main(string[] args)
        {
            _dictionary = new MultiValueDictionary();

            _commandDictionary = new Dictionary<string, ICommand>()
            {
                { "keys", new KeysCommand() },
                { "members", new MembersCommand() },
                { "add", new AddCommand() },
                { "remove", new RemoveCommand() },
                { "removeall", new RemoveAllCommand() },
                { "clear", new ClearCommand() },
                { "keyexists", new KeyExistsCommand() },
                { "valueexists", new ValueExistsCommand() },
                { "allmembers", new AllMembersCommand() },
                { "items", new ItemsCommand() },
                { "quit", new QuitCommand() }
            };

            Console.WriteLine("Commands:");
            foreach (string key in _commandDictionary.Keys)
            {
                Console.WriteLine(key);
            }

            // exit via the "quit" command
            while (true)
            {
                ReadKeys();
            }
        }

        private static void ReadKeys()
        {
            string input = Console.ReadLine();
            string[] commandString = input.Split(' ');

            if (commandString.Length == 0)
            {
                Console.WriteLine("Error reading input");
                return;
            }

            if (_commandDictionary.TryGetValue(commandString[0].ToLower(), out ICommand command))
            {
                try
                {
                    command.Execute(_dictionary, commandString.Skip(1).ToArray());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected exception: {ex}");
                }
            }
            else
            {
                Console.WriteLine("Command not found");
            }
        }
    }
}
