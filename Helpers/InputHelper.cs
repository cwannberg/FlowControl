using Abstractions;
namespace Helpers;

public static class InputHelper
{

    //Metod som tar emot indata från användaren och verifierar att värdet av detta är ett heltal.
    public static uint VerifySafeUintInput(string message, IUI ui)
    {
        bool continueLoop = true;
        ui.Print(message);
        uint parsedUint = 0;

        string userInput = ui.GetInput();
        do
        {
            if (uint.TryParse(userInput, out parsedUint))
            {
                continueLoop = false;
                return parsedUint;
            }
            else if (string.IsNullOrEmpty(userInput))
            {
                ui.Print("Felaktig input");
                continueLoop = false;
            }
            else
            {
                ui.Print("Felaktig input");
                break;
            }
        } while (continueLoop);

        return parsedUint;
    }

    //Metod som tar emot indata från användaren och verifierar att värdet av detta är en giltig string
    public static string VerifySafeStringInput(string message, IUI ui)
    {
        ui.Print(message);

        string userInput = ui.GetInput();
            if (string.IsNullOrEmpty(userInput))
            {
                ui.Print("Felaktig input");
            }
            else
            {
                return userInput;
            }

        return userInput;
    }
}
