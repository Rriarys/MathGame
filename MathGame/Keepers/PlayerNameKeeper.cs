namespace MathGame;

public static class PlayerNameKeeper
{
    public static string playerName { get; set; } = "Player";

    public static string GetPlayerName() 
    {
        MinorExtensions.TypeWrite(GetNameAskPrompt());

        playerName = ReadUserInput();
        
        GetPlayerGreating(playerName);

        return playerName;
    }
    public static string GetNameAskPrompt() =>
        "\nPlease enter your name: ";

    public static string ReadUserInput() => 
         Console.ReadLine()?.Trim() ?? "Player"; // If the user doesn't enter a name, default to "Player"

    public static void GetPlayerGreating(string playerName) =>
        MinorExtensions.TypeWriteLine($"\nHello, {playerName}! Let's play the Math Game!");

}
