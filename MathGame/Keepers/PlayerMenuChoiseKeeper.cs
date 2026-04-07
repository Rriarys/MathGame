namespace MathGame;

public static class PlayerMenuChoiseKeeper
{
    public static int GetPlayerMenuChoice()
    {
        while (true)
        {
            MinorExtensions.TypeWrite(GetNameAskPrompt());
            
            int? input = ReadUserInput();

            if (input is >= 0 and <= 9 and not (6 or 7))
            {
                return input.Value;
            }

            MinorExtensions.TypeWriteLine("\nInvalid choice. Please try again.");
        }
    }

    public static string GetNameAskPrompt() =>
        "\nEnter your choice: ";
    public static int? ReadUserInput() => 
      int.TryParse(Console.ReadLine(), out var result) ? result : null;
}
