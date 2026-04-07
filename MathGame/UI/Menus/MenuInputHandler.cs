namespace MathGame;

public static class MenuInputHandler
{
    public static int GetChoice()
    {
        while (true)
        {
            ConsoleExtensions.TypeWrite("\nEnter your choice: ");
            
            if (int.TryParse(Console.ReadLine(), out int input))
            {
                if (input is >= 0 and <= 9 and not (6 or 7))
                {
                    return input;
                }
            }

            ConsoleExtensions.TypeWriteLine("\nInvalid choice. Please try again.");
        }
    }
}
