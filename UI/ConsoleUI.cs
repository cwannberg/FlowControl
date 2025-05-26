using Abstractions;

namespace FlowControl.UI
{
    class ConsoleUI : IUI
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public string GetInput()
        {
            return Console.ReadLine() ?? string.Empty;
        }
    }
}
