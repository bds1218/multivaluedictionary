using System;
using System.Collections;
using System.Linq;

namespace MultiValueDict
{
    public class KeysCommand : ICommand
    {
        public void Execute(IMultiValueDictionary dictionary, string[] args)
        {
            var results = dictionary.GetKeys().ToArray();
            if (results.Length == 0)
            {
                Console.WriteLine("No keys found.");
                return;
            }

            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {results[i]}");
            }
        }
    }

    public class MembersCommand : ICommand
    {
        public void Execute(IMultiValueDictionary dictionary, string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("ERROR: Missing key argument");
                return;
            }

            if (!dictionary.KeyExists(args[0]))
            {
                Console.WriteLine($"ERROR: Key {args[0]} does not exist.");
                return;
            }

            var results = dictionary.GetMembers(args[0]).ToArray();
            if (results.Length == 0)
            {
                Console.WriteLine($"No values found for key {args[0]}.");
                return;
            }

            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {results[i]}");
            }
        }
    }

    public class AddCommand : ICommand
    {
        public void Execute(IMultiValueDictionary dictionary, string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("ERROR: Invalid argument count. Supply 1 key and 1 value.");
                return;
            }

            if (dictionary.KeyExists(args[0]) && dictionary.ValueExists(args[0], args[1]))
            {
                Console.WriteLine($"ERROR: {args[1]} already exist for key {args[0]}.");
                return;
            }

            dictionary.AddValue(args[0], args[1]);
            Console.WriteLine($"Added value {args[1]} to key {args[0]}.");
        }
    }

    public class RemoveCommand : ICommand
    {
        public void Execute(IMultiValueDictionary dictionary, string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("ERROR: Invalid argument count. Supply 1 key and 1 value.");
                return;
            }

            if (!dictionary.KeyExists(args[0]))
            {
                Console.WriteLine($"ERROR: Key {args[0]} does not exist.");
                return;
            }

            if (!dictionary.ValueExists(args[0], args[1]))
            {
                Console.WriteLine($"ERROR: {args[1]} does not exist for key {args[0]}.");
                return;
            }

            dictionary.RemoveValue(args[0], args[1]);
            Console.WriteLine($"Removed value {args[1]} from key {args[0]}");
        }
    }

    public class RemoveAllCommand : ICommand
    {
        public void Execute(IMultiValueDictionary dictionary, string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("ERROR: Invalid argument count. Supply 1 key.");
                return;
            }

            if (!dictionary.KeyExists(args[0]))
            {
                Console.WriteLine($"ERROR: Key {args[0]} does not exist.");
                return;
            }

            dictionary.RemoveAll(args[0]);
            Console.WriteLine($"Removed key {args[0]}");
        }
    }

    public class ClearCommand : ICommand
    {
        public void Execute(IMultiValueDictionary dictionary, string[] args)
        {
            dictionary.ClearDictionary();
            Console.WriteLine("Cleared");
        }
    }

    public class KeyExistsCommand : ICommand
    {
        public void Execute(IMultiValueDictionary dictionary, string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("ERROR: Invalid argument count. Supply 1 key.");
                return;
            }

            Console.WriteLine(dictionary.KeyExists(args[0]));
        }
    }

    public class ValueExistsCommand : ICommand
    {
        public void Execute(IMultiValueDictionary dictionary, string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("ERROR: Invalid argument count. Supply 1 key and 1 value.");
                return;
            }

            Console.WriteLine(dictionary.ValueExists(args[0], args[1]));
        }
    }

    public class AllMembersCommand : ICommand
    {
        public void Execute(IMultiValueDictionary dictionary, string[] args)
        {
            var results = dictionary.GetAllMembers().ToArray();
            if (results.Length == 0)
            {
                Console.WriteLine($"No members found.");
                return;
            }

            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {results[i]}");
            }
        }
    }

    public class ItemsCommand : ICommand
    {
        public void Execute(IMultiValueDictionary dictionary, string[] args)
        {
            var results = dictionary.GetAllItems().ToArray();
            if (results.Length == 0)
            {
                Console.WriteLine($"No items found.");
                return;
            }

            int lineCount = 0;
            foreach (var result in results)
            {
                foreach (string line in result.Value)
                {
                    lineCount++;
                    Console.WriteLine($"{lineCount}) {result.Key}: {line}");
                }
            }
        }
    }

    public class QuitCommand : ICommand
    {
        public void Execute(IMultiValueDictionary dictionary, string[] args)
        {
            Environment.Exit(0);
        }
    }
}
