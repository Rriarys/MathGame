namespace MathGame;

public static class DifficultySelector
{
    public static int SelectDifficulty(string optionName)
    {   
        MinorExtensions.TypeWrite(GetDifficultyPrompt(optionName));

        int userInput = ReadUserInput();

        int? difficulty = ValidateDifficulty(userInput);
        
        return difficulty ?? Random.Shared.Next(1, 4); // If the user input is valid (between 1 and 3), return the corresponding difficulty level; otherwise, generate and return a random difficulty level between 1 and 3
    }

    public static string GetDifficultyPrompt(string optionName) =>
        $"You chose {optionName}, please select difficulty:\n" +
        "(1 - Easy, 2 - Medium, 3 - Hard, any other key - Random difficulty)\n\n" +
        "Enter difficulty (1-3): ";

    public static int ReadUserInput() =>
        int.TryParse(Console.ReadLine(), out var result) ? result : 0;

    public static int? ValidateDifficulty(int userInput) =>
        userInput is >= 1 and <= 3 ? userInput : null;
}
