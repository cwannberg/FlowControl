
using Abstractions;
using FlowControl.UI;
using Helpers;

namespace FlowControl
{
    internal class Program
    {
        private static IUI _ui = new ConsoleUI();
        static void Main(string[] args)
        {
            bool continueMenu = true;
            do
            {
                _ui.Print("**************************************************************");
                _ui.Print("* Välkommen till vår bio!                                    *");
                _ui.Print("* För att navigera i programmet anger du en siffra:          *");
                _ui.Print("* 1 - Köpa biljetter                                         *");
                _ui.Print("* 2 - Repetera en text                                       *");
                _ui.Print("* 3 - Dela upp en text                                       *");
                _ui.Print("* 0 - Stänga ner programmet                                  *");
                _ui.Print("**************************************************************");

                string userInput = _ui.GetInput();

                switch (userInput)
                {
                    case "0": 
                        continueMenu = false;
                        _ui.Print("Stänger ner");
                        break;
                    case "1": 
                        TicketHandler.Menu();
                        break;
                    case "2":
                        LoopTenTimes();
                        break;
                    case "3":
                        SplitUserInput();
                        break;
                    default:
                        _ui.Print("Felaktig input");
                        break;
                }
            } while (continueMenu); 
        }

        private static void LoopTenTimes()
        {
            _ui.Print("Skriv något och jag repeterar det tio gånger");
            string input = _ui.GetInput();

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i} {input} ");
            }
            _ui.Print("\n");
        }

        private static void SplitUserInput()
        {
            _ui.Print("Skriv en mening med minst tre ord");
            string input = _ui.GetInput();

            string[] wordsFromInput = input.Split(" ");

            if (wordsFromInput.Length < 3)
            {
                _ui.Print("Var snäll och skriv en mening med minst tre ord");
                SplitUserInput();
            }
            else
            {
                _ui.Print(wordsFromInput[2]);
            }
        }
    }
}
