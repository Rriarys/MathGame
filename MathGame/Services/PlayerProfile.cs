namespace MathGame;

public static class PlayerProfile
{
    public static string playerName { get; set; } = "Player";

    public static string GetPlayerName() 
    {
        ConsoleExtensions.TypeWrite(GetNameAskPrompt());

        playerName = ReadUserInput();
        
        GetPlayerGreating(playerName);

        return playerName;
    }
    public static string GetNameAskPrompt()
    {   
        Console.ForegroundColor = ConsoleColor.White;
        return "Please enter your name: ";
    }

    public static string ReadUserInput() => 
         Console.ReadLine()?.Trim() ?? "Guest"; // If the user doesn't enter a name, default to "Guest"

    public static void GetPlayerGreating(string playerName)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        ConsoleExtensions.TypeWriteLine($"\nHello, {playerName}! Let's play the Math Game!");
    }


}
