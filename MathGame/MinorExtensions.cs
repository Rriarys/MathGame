namespace MathGame;

// This class is only for storing minor extension methods that may be used across the project, to make the code cleaner and more organized. It can be expanded in the future as needed.
public static class MinorExtensions
{
    // CUSTOM TYPEWRITING METHODS
    // Custom methods for typewriting effect
    public static void TypeWrite(string text, int delay = 15)
    {   
        foreach (char c in text)
        {
            Console.CursorVisible = false;
            Console.Write(c);
            Thread.Sleep(delay);
            Console.CursorVisible = true;
        }
    }

    // Method to typewrite a line of text with a newline at the end
    public static void TypeWriteLine(string text, int delay = 15)
    {
        TypeWrite(text, delay);
        Console.WriteLine();
    }

    // ANIMATION METHODS
    // Spinner animation method to show a loading effect
    public static void StoryShowLoadingAnimation()
    {   
        Console.WriteLine();
        Console.CursorVisible = false;
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < 40; i++)
        {
            Console.Write($"\rLoading story of games... {spinner[i % spinner.Length]}");
            Thread.Sleep(150);
        }
        TypeWriteLine("\rDone!".PadRight(30));
        Console.CursorVisible = true;
    }

    public static void PlayerNameChangingLoadingAnimation()
    {   
        Console.WriteLine();
        Console.CursorVisible = false;
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < 40; i++)
        {   
            Console.Write($"\rChanging player session... {spinner[i % spinner.Length]}");
            Thread.Sleep(100);
        }
        TypeWriteLine("\rDone!".PadRight(30));
        Console.CursorVisible = true;
    }


    // Method to wrap text to a given width
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
