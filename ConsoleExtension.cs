namespace DLLInject
{
    public static class ConsoleExtension
    {
        public static void WriteLine(string content, ConsoleColor color = ConsoleColor.White)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(content);
            Console.ForegroundColor = currentColor;
        }
        public static void Write(string content, ConsoleColor color = ConsoleColor.White)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(content);
            Console.ForegroundColor = currentColor;
        }
    }
}
