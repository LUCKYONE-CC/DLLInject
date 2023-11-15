namespace DLLInject
{
    public class Command
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Action<Dictionary<string, string>> Action { get; private set; }
        public List<CommandParameter> Parameters { get; }

        public Command(string name, string description, Action<Dictionary<string, string>> action)
        {
            Name = name;
            Description = description;
            Action = action;
            Parameters = new List<CommandParameter>();
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetAction(Action<Dictionary<string, string>> action)
        {
            Action = action;
        }

        public void AddParameter(string name, string description)
        {
            Parameters.Add(new CommandParameter(name, description));
        }

        public void ExecuteAction(Dictionary<string, string> parameters)
        {
            Action?.Invoke(parameters);
        }
    }
}
