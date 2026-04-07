using MathGame.Menu;

namespace MathGame;

public static class GameEngine
{
    public static void Run()
    {
        string playerName = PlayerNameKeeper.GetPlayerName(); // Get the player's name 

        MenuTyper.Print(); // Print the menu
        int playerMenuChoice = PlayerMenuChoiseKeeper.GetPlayerMenuChoice();

        int difficulty;
        if (playerMenuChoice is >=1 and <= 5)
        {
            difficulty = DifficultySelector.SelectDifficulty(GamesNamesList.Games[playerMenuChoice]);
            GamesRouter.Run(playerMenuChoice, difficulty);
        }
        else if (playerMenuChoice == 8)
        {
            TextDisplayMethods.PrintSeparator();

            MinorExtensions.PlayerNameChangingLoadingAnimation();

            playerName = PlayerNameKeeper.GetPlayerName();
        }
        else if (playerMenuChoice == 9)
        {
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

            MenuTyper.Print();
        }
        else
        {
            MinorExtensions.TypeWriteLine($"\nThank you, {playerName}, for playing the Math Game! Goodbye!");
            Thread.Sleep(200);
            Environment.Exit(0); // Exit the program
        }

    }
}
