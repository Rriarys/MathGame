namespace MathGame.Menu;

public static class ProcessRouter
{
    public static void Run(int playerMenuChoice)
    {
        switch (playerMenuChoice)
        {
            case 8:
                TextDisplayMethods.PrintSeparator();
                MinorExtensions.PlayerNameChangingLoadingAnimation();
                PlayerNameKeeper.GetPlayerName();
                break; 

            case 9:
                TextDisplayMethods.PrintSeparator();
                MinorExtensions.StoryShowLoadingAnimation();

                    if (!GamesHistory.History.Any())
                    {   
                        Console.WriteLine("\nNo games played yet.");
                    }

                    TextDisplayMethods.PrintSmallSeparator();

                    MinorExtensions.TypeWriteLine("\nGames History:\n\n");
                    Console.WriteLine($"{"Player",-15} | {"Game",-15} | {"Diff",-5} | {"Score",-5} | {"Time(s)",-10}");
                    Console.WriteLine(new string('-', 60));

                    foreach (var game in GamesHistory.History)
                    {
                        Console.WriteLine($"{game.name.Cut(15),-15} | {game.game.Cut(15),-15} | {((Difficulty)game.diff).ToString(),-5} | {game.score,-5} | {game.time,-10:F2}");
                    }
                    
                    break;

            case 0:
                MinorExtensions.TypeWriteLine($"\nThank you, {PlayerNameKeeper.playerName}, for playing the Math Game! Goodbye!");
                Thread.Sleep(300);
                Environment.Exit(0); // Exit the program
                break;
        }
    } 
}
