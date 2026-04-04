namespace MathGame;

// This class is only for storing minor extension methods that may be used across the project, to make the code cleaner and more organized. It can be expanded in the future as needed.
public static class MinorExtensions
{

    // Method to cut a string to a specified maximum length
    public static string Cut(this string value, int maxLength)
    {
        return value.Length <= maxLength 
            ? value 
            : value.Substring(0, maxLength);
    }
    
    // Method to select difficulty level for the games
    public static int SelectDifficulty(string optionName)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Magenta;
        TypeWriteLine($"You chose {optionName}, please select difficulty:");
        TypeWriteLine("(1 - Easy, 2 - Medium, 3 - Hard, any other key - Random difficulty)");
        Console.ForegroundColor = ConsoleColor.White;
        TypeWrite("\nEnter difficulty (1-3): ");
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            string? input = Console.ReadLine()?.Trim();
            Console.WriteLine();

            if (int.TryParse(input, out int diff) && diff >= 1 && diff <= 3) // Check if the input is a valid integer between 1 and 3, representing the difficulty levels
                return diff;
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                TypeWriteLine("Random difficulty selected.\n");
                Console.ResetColor();
                return new Random().Next(1, 4); // Return a random difficulty level between 1 and 3 if the input is invalid, ensuring that the game can proceed with a randomly selected difficulty level
            }
        }
    }


    // CUSTOM TYPEWRITING METHODS
    // Custom methods for typewriting effect
    public static void TypeWrite(string text, int delay = 15)
    {   
        Console.CursorVisible = false;
    foreach (char c in text)
        {
            if (c == '\n')
            {
                int remainingSpace = Console.WindowWidth - Console.CursorLeft;
                if (remainingSpace > 0)
                {
                    Console.Write(new string(' ', remainingSpace));
                }
                Console.Write(c);
            }
            else
            {
                Console.Write(c);
            }
            Thread.Sleep(delay);
        }
        Console.CursorVisible = true;
    }

    // Method to typewrite a line of text with a newline at the end
    public static void TypeWriteLine(string text, int delay = 15)
    {
        TypeWrite(text, delay);

        int remainingSpace = Console.WindowWidth - Console.CursorLeft;
        if (remainingSpace > 0)
            {
                Console.Write(new string(' ', remainingSpace));
            }

        Console.WriteLine();
    }

    // ANIMATION METHODS
    // Spinner animation method to show a loading effect
    public static void StoryShowLoadingAnimation()
    {   
        Console.CursorVisible = false;
        Console.Write(new string(' ', Console.WindowWidth)); 
        Console.SetCursorPosition(0, Console.CursorTop);
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < 40; i++)
        {
            Console.Write($"\rLoading story of games... {spinner[i % spinner.Length]}");
            Thread.Sleep(120);
        }
        TypeWriteLine("\rDone!".PadRight(30));
        Console.CursorVisible = true;
    }

    public static void PlayerNameChangingLoadingAnimation()
    {   
        Console.CursorVisible = false;
        Console.Write(new string(' ', Console.WindowWidth)); 
        Console.SetCursorPosition(0, Console.CursorTop);
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < 40; i++)
        {   
            Console.Write($"\rChanging player session... {spinner[i % spinner.Length]}");
            Thread.Sleep(100);
        }
        TypeWriteLine("\rDone!".PadRight(30));
        Console.CursorVisible = true;
    }
    // ANIMATION METHODS END


    // Method to wrap text with padding to a given width. Needed forthe info message to ensure it placed inder the big welcome message and doesn't exceed the console width.
    public static string[] WrapText(string text, int maxWidth)
    {
        var words = text.Split(' '); // Split the text into words based on spaces
        var lines = new List<string>();
        string currentLine = "";

        foreach (var word in words) // Iterate through each word in the text
        {
            if ((currentLine + word).Length > maxWidth)
            {
                lines.Add(currentLine.TrimEnd());
                currentLine = "";
            }

            currentLine += word + " ";
        }

        if (!string.IsNullOrWhiteSpace(currentLine))
            lines.Add(currentLine.TrimEnd());

        return lines.ToArray();
    }
}
