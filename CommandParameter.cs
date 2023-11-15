namespace DLLInject
{
    public class CommandParameter
    {
        public string Name { get; }
        public string Description { get; }

        public CommandParameter(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
