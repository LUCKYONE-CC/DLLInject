namespace DLLInject
{
    public class CommandProcessor
    {
        private Dictionary<string, Command> commands = new Dictionary<string, Command>();

        public void AddCommand(Command command)
        {
            commands[command.Name] = command;
        }

        public void ProcessCommand(string input, string parameterPrefix = "-")
        {
            string[] commandParts = input.Split(' ');
            string commandName = commandParts[0];

            // Extrahiere Parameter und Werte
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            for (int i = 1; i < commandParts.Length; i++)
            {
                if (commandParts[i].StartsWith(parameterPrefix))
                {
                    string parameterName = commandParts[i].Substring(parameterPrefix.Length);

                    // Überprüfe, ob der Parameterwert in Anführungszeichen steht
                    string parameterValue = (i + 1 < commandParts.Length && !commandParts[i + 1].StartsWith(parameterPrefix))
                        ? commandParts[i + 1]
                        : null;

                    parameters[parameterName] = parameterValue;
                    i++;
                }
            }

            ProcessCommand(commandName, parameters);
        }

        public void ProcessCommand(string commandName, Dictionary<string, string> parameters)
        {
            if (commands.ContainsKey(commandName))
            {
                commands[commandName].ExecuteAction(parameters);
            }
            else if (commandName == "help")
            {
                ConsoleExtension.WriteLine("Available commands:", ConsoleColor.Blue);
                foreach (var command in commands.Values)
                {
                    ConsoleExtension.WriteLine($"\t{command.Name} - {command.Description}", ConsoleColor.Green);
                    foreach (var parameter in command.Parameters)
                    {
                        ConsoleExtension.WriteLine($"\t\t-{parameter.Name}: {parameter.Description}", ConsoleColor.DarkYellow);
                    }
                }
            }
            else
            {
                Console.WriteLine("Ungültiger Befehl. Geben Sie 'help' für die Befehlsliste ein.");
            }
        }
    }
}