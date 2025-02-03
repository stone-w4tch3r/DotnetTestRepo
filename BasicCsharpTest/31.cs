// using System;
// using System.Collections.Generic;
//
// // Define interfaces for different functionalities
// public interface ITextPrinter
// {
//     void Print(string text, ConsoleColor color);
// }
//
// public interface IUserInputHandler
// {
//     string GetInput();
// }
//
// public interface ICommandExecutor
// {
//     void ExecuteCommand(string input);
// }
//
// // Implement the TextPrinter class to handle printing with colors
//
// public class TextPrinter : ITextPrinter
// {
//     private readonly Dictionary<string, ConsoleColor> _colorMap;
//
//     public TextPrinter()
//     {
//         _colorMap = new Dictionary<string, ConsoleColor>
//         {
//             { "red", ConsoleColor.Red },
//             { "green", ConsoleColor.Green },
//             { "blue", ConsoleColor.Blue },
//             // Add more colors as needed
//         };
//     }
//
//     public void Print(string text, ConsoleColor color)
//     {
//         Console.ForegroundColor = color;
//         Console.WriteLine(text);
//         Console.ResetColor();
//     }
// }
//
//
// // Implement the UserInputHandler class to handle user input
// public class UserInputHandler : IUserInputHandler
// {
//     public string GetInput()
//     {
//         return Console.ReadLine();
//     }
// }
//
// // Implement the CommandExecutor class to execute commands based on user input
// public class CommandExecutor : ICommandExecutor
// {
//     private readonly ITextPrinter _textPrinter;
//     private readonly Dictionary<string, Action> _commandMap;
//
//     public CommandExecutor(ITextPrinter textPrinter)
//     {        _textPrinter = textPrinter;
//         _commandMap = new Dictionary<string, Action>
//         {
//             { "help", () => DisplayHelp() },
//             { "exit", () => Environment.Exit(0) },
//             // Add more commands as needed
//         };
//     }
//
//     public void ExecuteCommand(string input)
//     {
//         if (_commandMap.ContainsKey(input))
//         {
//             _commandMap[input]();
//         }
//         else
//         {
//             _textPrinter.Print("Unknown command.", ConsoleColor.Red);
//         }
//     }
//
//     private void DisplayHelp()
//     {
//         _textPrinter.Print("Available commands:", ConsoleColor.Green);
//         _textPrinter.Print("- help: Display this message", ConsoleColor.White);
//         _textPrinter.Print("- exit: Exit the program", ConsoleColor.White);
//         // Add more commands as needed
//     }
// }
//
// // Program entry point
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         ITextPrinter textPrinter = new TextPrinter();
//         IUserInputHandler userInputHandler = new UserInputHandler();
//         ICommandExecutor commandExecutor = new CommandExecutor(textPrinter);
//
//         textPrinter.Print("Welcome to the Nanowar Interactive Console!", ConsoleColor.Blue);
//         textPrinter.Print("Type 'help' for available commands.", ConsoleColor.White);
//
//         while (true)
//         {
//             string input = userInputHandler.GetInput();
//             commandExecutor.ExecuteCommand(input);
//         }
//     }
// }