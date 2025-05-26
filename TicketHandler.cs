using Abstractions;
using FlowControl.UI;
using Helpers;

namespace FlowControl
{
    internal static class TicketHandler
    {
        private static IUI _ui = new ConsoleUI();
        public static void Menu()
        {
            bool continueMenu = true;
            do
            {
                _ui.Print("**************************************************************");
                _ui.Print("* 1 - Se biljettpriser                                       *");
                _ui.Print("* 2 - Köpa biljetter                                         *");
                _ui.Print("* 0 - Gå tillbaka till biomenyn                              *");
                _ui.Print("**************************************************************");

                string userInput = _ui.GetInput();

                switch (userInput)
                {
                    case "0":
                        continueMenu = false;
                        _ui.Print("Stänger ner");
                        break;
                    case "1":
                        CheckAge(false);
                        break;
                    case "2":
                        BuyTickets();
                        break;
                    default:
                        _ui.Print("Felaktig input");
                        break;
                }
            } while (continueMenu);
        }

        private static void CheckAge(bool buyTicket)
        {
            bool continueMenu = true;
            do
            {
                _ui.Print("Ange ålder på personen som ska nyttja biljetten: ");
                if (int.TryParse(_ui.GetInput(), out int age))
                {
                    if (age < 5 || age > 100)
                    {
                        _ui.Print("Biljetten är gratis");
                        if (buyTicket)
                            break;
                    }
                    else if (age >= 5 && age < 20)
                    {
                        _ui.Print($"Ungdomspris {TicketHelper.YouthPrice}:-");
                        if (buyTicket)
                            break;
                    }
                    else
                    {
                        if (age > 64 && age <= 100)
                        {
                            _ui.Print($"Pensionärspris: {TicketHelper.SeniorPrice}:-");
                            if (buyTicket)
                                break;
                        }
                        else
                        {
                            _ui.Print($"Standardpris: {TicketHelper.StandardPrice}:-");
                            if (buyTicket)
                                break;
                        }
                    }
                }
                else
                {
                    _ui.Print("Felaktig input, vänligen ange en siffra");
                }
            }
            while (continueMenu);
        }

        private static void BuyTickets()
        {
            _ui.Print("Ange antal biljetter:");
            if (uint.TryParse(_ui.GetInput(), out uint numberOfTickets)) 
                if (numberOfTickets == 1)
                    CheckAge(true);
                else
                {
                    _ui.Print("Ange hur många i sällskapet som är yngre än 5 eller äldre än 100"); 
                    uint numberOfFreeTickets = uint.Parse(_ui.GetInput()); 
                    _ui.Print("Ange hur många i sällskapet som är under 20 år"); 
                    uint numberOfYouthTickets = uint.Parse(_ui.GetInput());
                    _ui.Print("Ange hur många i sällskapet som är över 64 år");
                    uint numberOfSeniorTickets = uint.Parse(_ui.GetInput());

                    numberOfTickets = numberOfTickets - numberOfFreeTickets; 

                    int sum = calculateTicketPrice(numberOfTickets, numberOfSeniorTickets, numberOfYouthTickets);

                    _ui.Print($"Biljetterna kostar: {sum}:-");
                }
            else
            {
                _ui.Print("Felaktig input, vänligen ange en siffra");
            }
        }

        private static int calculateTicketPrice(uint numberOfTickets, uint numberOfSeniorTickets, uint numberOfYouthTickets)
        {
            uint numberOfStandardTickets = numberOfTickets - numberOfSeniorTickets - numberOfYouthTickets;
            uint sum = (uint)(TicketHelper.StandardPrice * numberOfStandardTickets +
                              TicketHelper.SeniorPrice * numberOfSeniorTickets +
                              TicketHelper.YouthPrice * numberOfYouthTickets);
            return (int)sum;
        }
    }
}