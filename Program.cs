using System.Collections.Concurrent;

namespace FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continueMenu = true;
            do
            {
                Console.WriteLine("Välkommen!");
                Console.WriteLine("För att navigera i programmet kommer du att ange siffror");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0": continueMenu = false;
                        Console.WriteLine("Stänger ner");
                        break;
                    default:
                        Console.WriteLine("Felaktig input");
                        break;

                }
            } while (continueMenu); 
        }
    }
}
