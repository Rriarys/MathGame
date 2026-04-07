namespace MathGame;

public static class PlayerMenuChoiseKeeper
{
    public static string? GetPlayerMenuChoice()
    {
        MinorExtensions.TypeWrite(GetNameAskPrompt());

        return ReadUserInput();
    }

    public static string GetNameAskPrompt() =>
        "\nEnter your choice: ";
    public static string? ReadUserInput() => 
         Console.ReadLine()?.Trim();
}
