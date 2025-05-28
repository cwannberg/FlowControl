using Abstractions;
using Helpers;

namespace FlowControl;

public static class FunWithWords
{
    //Metod som loopar igenom användarens input och skriver ut det tio gånger.
    public static void LoopTenTimes(IUI ui)
    {
        //Metodanrop som felhanterar indata från användaren och returnerar användarens menyval, indatat måste vara en sträng.
        string input = InputHelper.VerifySafeStringInput("Skriv något och jag repeterar det tio gånger", ui);

        for (int i = 0; i < 10; i++)
        {
            Console.Write($"{i} {input} ");
        }
        ui.Print("\n");
    }

    //Metod som tar emot ett input från användaren, kontrollerar att minst tre ord är angivna och plockar sedan ut det tredje ordet i meningen.
    public static void SplitUserInput(IUI ui)
    {
        bool continueLoop = true;
        do
        {
            //Metodanrop som felhanterar indata från användaren och returnerar användarens menyval, indatat måste vara en sträng.
            string input = InputHelper.VerifySafeStringInput("Skriv en mening med minst tre ord", ui);

            //Delar upp användarens input i en lista så att vi kan plocka ut det tredje ordet.
            string[] wordsFromInput = input.Split(" ");

            if (wordsFromInput.Length < 3)
            {
                ui.Print("Felaktig input");
                SplitUserInput(ui);
            }
            else
            {
                ui.Print(wordsFromInput[2]);
                continueLoop = false;
            }

        } while (continueLoop);
    }
}
