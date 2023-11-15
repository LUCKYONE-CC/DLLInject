using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DLLInject
{
    public class Program
    {
        static void Main()
        {
            try
            {
                CommandProcessor commandProcessor = new CommandProcessor();

                commandProcessor.AddCommand(new CommandBuilder("exit")
                    .SetDescription("Anwendung beenden")
                    .SetAction(parameters =>
                    {
                        Environment.Exit(0);
                    })
                    .Build());

                commandProcessor.AddCommand(new CommandBuilder("getallprocesses")
                    .SetDescription("Liste aller Prozesse anzeigen")
                    .SetAction(parameters =>
                    {
                        Console.WriteLine("Liste aller Prozesse:");
                        Process.GetProcesses().ToList().ForEach(p => Console.WriteLine($"Process Name: {p.ProcessName} | PID: {p.Id}"));
                    })
                    .Build());

                commandProcessor.AddCommand(new CommandBuilder("inject")
                    .SetDescription("DLL in einen Prozess injizieren")
                    .WithParameter("pid", "Prozess-ID")
                    .WithParameter("dllpath", "Pfad zur DLL")
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
                            Console.WriteLine("Fehlende Parameter für den Befehl 'inject'. Verwenden Sie -pid und -dllPath.");
                        }
                    })
                    .Build());

                Console.WriteLine("Geben Sie einen Befehl ein (help für Befehlsliste): \n", ConsoleColor.Blue);

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