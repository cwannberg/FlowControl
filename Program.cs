
using Abstractions;
using FlowControl.UI;
using Helpers;

namespace FlowControl;

internal class Program
{
    private static IUI _ui = new ConsoleUI();
    static void Main(string[] args)
    {
        bool continueMenu = true;
        do
        {
            _ui.Print("**************************************************************");
            _ui.Print("* Välkommen                                                  *");
            _ui.Print("* För att navigera i programmet anger du en siffra:          *");
            _ui.Print("* 1 - Biomeny                                                *");
            _ui.Print("* 2 - Repetera en text                                       *");
            _ui.Print("* 3 - Dela upp en text                                       *");
            _ui.Print("* 0 - Stänga ner programmet                                  *");
            _ui.Print("**************************************************************");

            //Metodanrop som felhanterar indata från användaren och returnerar användarens menyval, indatat måste vara ett heltal.
            uint userInput = InputHelper.VerifySafeUintInput(" ", _ui);

            switch (userInput)
            {
                case 0: 
                    continueMenu = false;
                    _ui.Print("Stänger ner");
                    break;
                case 1: 
                    TicketHandler.TicketMenu();
                    break;
                case 2:
                    FunWithWords.LoopTenTimes(_ui);
                    break;
                case 3:
                    FunWithWords.SplitUserInput(_ui);
                    break;
                default:
                    _ui.Print("Felaktig input");
                    break;
            }
        } while (continueMenu); 
    }
}
