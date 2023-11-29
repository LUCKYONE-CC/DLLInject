using System.Diagnostics;
using CommandCenter;
using CommandCenter.Extensions;

namespace DLLInject
{
    public class Program
    {
        static void Main()
        {
            try
            {
                var commandProcessor = new CommandHandler();

                commandProcessor.AddCommand(new CommandBuilder("exit")
                    .SetDescription("Exit the application")
                    .SetAction(parameters =>
                    {
                        Environment.Exit(0);
                    })
                    .Build());

                commandProcessor.AddCommand(new CommandBuilder("getallprocesses")
                    .SetDescription("Display a list of all processes")
                    .SetAction(parameters =>
                    {
                        Console.WriteLine("List of all processes:");
                        Process.GetProcesses().ToList().ForEach(p => Console.WriteLine($"Process Name: {p.ProcessName} | PID: {p.Id}"));
                    })
                    .Build());

                commandProcessor.AddCommand(new CommandBuilder("inject")
                    .SetDescription("Inject a DLL into a process")
                    .WithParameter("pid", "Process ID")
                    .WithParameter("dllpath", "Path to the DLL")
                    .SetAction(parameters =>
                    {
                        string pid = parameters.GetParameterValue("pid");
                        string dllPath = parameters.GetParameterValue("dllpath");

                        if (pid != null && dllPath != null)
                        {
                            Injector.Inject(pid, dllPath);
                        }
                        else
                        {
                            Console.WriteLine("Missing parameters for the 'inject' command. Use -pid and -dllPath.");
                        }
                    })
                    .Build());

                Console.WriteLine("Enter a command (type 'help' for a list of commands): \n", ConsoleColor.Blue);

                while (true)
                {
                    ConsoleExtension.Write(">", ConsoleColor.DarkGreen);
                    string input = Console.ReadLine().ToLower();
                    commandProcessor.ProcessCommand(input);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
