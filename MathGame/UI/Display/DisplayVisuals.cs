namespace MathGame;

// TEXT DISPLAY METHODS
public static class DisplayVisuals
{
    // =============================== SEPARATOR ===============================
    public static void PrintSeparator()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(new string('=', Console.WindowWidth));
        Console.WriteLine();
    }

    // =============================== SMALL SEPARATOR ===============================
    public static void PrintSmallSeparator()
    {   
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(new string('-', Console.WindowWidth));
        Console.WriteLine();
    }

    // =============================== APP WELCOME PREAMBLE ===============================
    public static void AppWelcomePreamble(string logoText, string infoText, string signatureText)
    {
        Console.Clear();
        PrintWelcomeMessage(logoText);
        PrintInformationMessage(infoText);
        PrintAuthorSignature(signatureText);
    }

    // =============================== WELCOME MESSAGE ===============================
    public static void PrintWelcomeMessage(string welcomeText)
    {   
        var welcomeLines = welcomeText // Split the welcome text into lines, remove empty lines, and convert to an array for processing
            .Split('\n')
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .ToArray();

        int maxLength = welcomeLines.Max(l => l.Length); // Calculate the maximum length of the lines in the welcome text to help with centering the text in the console window
        foreach (var line in welcomeLines)
        {
            int pad = (Console.WindowWidth - maxLength) / 2; // Calculate the left padding to center the text in the console window based on the maximum line length
            Console.WriteLine(line.PadLeft(pad + line.Length)); // Pad the line with spaces on the left to center it in the console window and print it to the console
        }
        Console.WriteLine();
    }

    // =============================== INFORMATION MESSAGE ===============================
    public static void PrintInformationMessage(string infoText)
    {
        int maxLength = TextConstants.logoText.Split('\n').Max(l => l.Length);
        var wrappedInfo = ConsoleExtensions.WrapText(infoText.Trim(), maxLength - 5); // Wrap the information text to fit within the console window, using the maximum line length from the welcome text minus some padding for better readability

        foreach (var line in wrappedInfo)
        {
            int pad = (maxLength - line.Length) / 2;
            int totalPad = (Console.WindowWidth - maxLength) / 2 + pad;
            ConsoleExtensions.TypeWriteLine(new string(' ', totalPad) + line); // Pad the line with spaces on the left to center it in the console window and print it with a typewriting effect
        }
        Console.WriteLine();  
    }

    // =============================== AUTHOR SIGNATURE ===============================
    public static void PrintAuthorSignature(string signatureText)
    {
        int signaturePad = (Console.WindowWidth - signatureText.Length) / 2;
        ConsoleExtensions.TypeWriteLine(new string(' ', signaturePad) + signatureText);
    }
}
