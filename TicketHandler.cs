using Abstractions;
using FlowControl.UI;
using Helpers;

namespace FlowControl;

internal static class TicketHandler
{
    private static IUI _ui = new ConsoleUI();
    public static void TicketMenu()
    {
        bool continueLoop = true;
        do
        {
            _ui.Print("**************************************************************");
            _ui.Print("*     Biomeny                                                *");
            _ui.Print("* 1 - Se biljettpriser efter ålder                           *");
            _ui.Print("* 2 - Se biljettpriser i lista                               *");
            _ui.Print("* 3 - Köpa biljetter                                         *");
            _ui.Print("* 0 - Gå tillbaka till menyn                                 *");
            _ui.Print("**************************************************************");

            //Metodanrop som felhanterar indata från användaren och returnerar användarens menyval, detta måste vara ett heltal
            uint userInput = InputHelper.VerifySafeUintInput(" ", _ui);

            switch (userInput)
            {
                case 0:
                    continueLoop = false;
                    _ui.Print("Går tillbaka till menyn");
                    break;
                case 1:
                    CheckAge();
                    break;
                case 2:
                    ShowTicketPrices();
                    break;
                case 3:
                    CalculateTicketPrice();
                    break;
                default:
                    _ui.Print("Felaktig input");
                    break;
            }
        } while (continueLoop);
    }

    //Metod som skriver ut priset på biljett beroende på ålder som användaren anger.
    private static void CheckAge()
    {
       bool continueMenu = true;      
        do
        {
            //Metodanrop som felhanterar användarens input, det måste vara ett heltal.
            uint userAge = InputHelper.VerifySafeUintInput("Ange ålder på personen som ska nyttja biljetten: ", _ui);

            if (userAge == 0)
            {
                break;
            }
            if (userAge < 5 && userAge > 0 || userAge > 100)
            {
                _ui.Print("Biljetten är gratis");
            }
            else if (userAge >= 5 && userAge < 20)
            {
                _ui.Print($"Ungdomspris {TicketHelper.YouthPrice}:-");
            }
            else if (userAge > 64 && userAge <= 100)
            {
                _ui.Print($"Pensionärspris: {TicketHelper.SeniorPrice}:-");
            }
            else
            {
                _ui.Print($"Standardpris: {TicketHelper.StandardPrice}:-");
            }               
        }
        while (continueMenu);
    }

    private static void ShowTicketPrices()
    {
        _ui.Print("**************************************************************");
        _ui.Print("* Biljettpriser:                                             *");
        _ui.Print("* Vuxen:                                               120:- *");
        _ui.Print("* Barn och ungdom:                                      80:- *");
        _ui.Print("* Pensionär:                                            90:- *");
        _ui.Print("* Besökare under fem år och över 100 år bjuds på gratis bio! *");
        _ui.Print("**************************************************************");
    }

    //Metod som räknar ut den totala kostnaden beroende på antal biljetter som köps.
    private static void CalculateTicketPrice()
    {
        uint standardTickets    = InputHelper.VerifySafeUintInput("Ange hur många i sällskapet som är mellan 20 år och 64 år", _ui);
        uint youthTickets       = InputHelper.VerifySafeUintInput("Ange hur många i sällskapet som är under 20 år", _ui);
        uint seniorTickets      = InputHelper.VerifySafeUintInput("Ange hur många i sällskapet som är över 64 år", _ui);
        uint freeTickets        = InputHelper.VerifySafeUintInput("Ange hur många i sällskapet som är yngre än 5 eller äldre än 100: ", _ui);

        uint tickets = freeTickets + standardTickets + seniorTickets + youthTickets;

        //Om användarens totala beställning inte innehåller några köpa biljetter avbryts köpet.
        if (tickets == 0)
        {
            _ui.Print("Köp avbrutet");
            TicketMenu();
        }

        uint sum = (TicketHelper.StandardPrice * standardTickets +
                    TicketHelper.SeniorPrice * seniorTickets +
                    TicketHelper.YouthPrice * youthTickets);

        //Är summan av de köpta biljetterna 0 betyder det att användaren angett ålder/åldrar som är under 5 år eller över 100 år och då kostar det ingenting
        if(sum == 0)
            _ui.Print("Biljetterna är gratis");
        else
            _ui.Print($"Antal biljetter: {tickets} \n" +
                      $"Kostnad: {sum}");
    }
}