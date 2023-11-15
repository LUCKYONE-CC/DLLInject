namespace DLLInject
{
    public class CommandBuilder
    {
        private Command command;

        public CommandBuilder(string name)
        {
            command = new Command(name, "", null);
        }

        public CommandBuilder SetDescription(string description)
        {
            command.SetDescription(description);
            return this;
        }

        public CommandBuilder SetAction(Action<Dictionary<string, string>> action)
        {
            command.SetAction(action);
            return this;
        }

        public CommandBuilder WithParameter(string name, string description)
        {
            command.AddParameter(name, description);
            return this;
        }

        public Command Build()
        {
            return command;
        }
    }
}