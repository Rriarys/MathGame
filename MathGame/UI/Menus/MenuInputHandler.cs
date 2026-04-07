namespace MathGame;

public static class MenuInputHandler
{
    public static int GetChoice()
    {
        while (true)
        {   
            Console.ForegroundColor = ConsoleColor.White;
            ConsoleExtensions.TypeWrite("\nEnter your choice: ");
            
            if (int.TryParse(Console.ReadLine(), out int input))
            {
                if (input is >= 0 and <= 9 and not (6 or 7))
                {
                    return input;
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            ConsoleExtensions.TypeWriteLine("\nInvalid choice. Please try again.");
        }
    }
}
