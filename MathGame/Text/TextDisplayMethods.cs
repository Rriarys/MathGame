namespace MathGame;

// TEXT DISPLAY METHODS
public static class TextDisplayMethods
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
        int maxLength = TextsHandler.logoText.Split('\n').Max(l => l.Length);
        var wrappedInfo = MinorExtensions.WrapText(infoText.Trim(), maxLength - 5); // Wrap the information text to fit within the console window, using the maximum line length from the welcome text minus some padding for better readability

        foreach (var line in wrappedInfo)
        {
            int pad = (maxLength - line.Length) / 2;
            int totalPad = (Console.WindowWidth - maxLength) / 2 + pad;
            MinorExtensions.TypeWriteLine(new string(' ', totalPad) + line); // Pad the line with spaces on the left to center it in the console window and print it with a typewriting effect
        }
        Console.WriteLine();  
    }

    // =============================== AUTHOR SIGNATURE ===============================
    public static void PrintAuthorSignature(string signatureText)
    {
        int signaturePad = (Console.WindowWidth - signatureText.Length) / 2;
        MinorExtensions.TypeWriteLine(new string(' ', signaturePad) + signatureText);
    }

    // =============================== MENU DISPLAY ===============================
    public static void PrintMenu(string menuText)
    {
        PrintSeparator();
        MinorExtensions.TypeWriteLine("Choose operation for challenge by entering the corresponding number:\n");

        // Split the menu text into lines, remove empty lines, and convert to an array for processing
        var menuLines = menuText
            .Split('\n')
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .ToArray();

        int maxLengthMenu = menuLines.Max(l => l.Length);

        // Calculate the total width of the menu box, including padding and borders
        int contentWidth = maxLengthMenu + 2;
        int totalWidth = contentWidth + 2;

        int leftPad = (Console.WindowWidth - totalWidth) / 2; // Calculate the left padding to center the menu box in the console window
        if (leftPad < 0) leftPad = 0;

        Console.ForegroundColor = ConsoleColor.Blue;

        // Top border of the menu box
        Console.WriteLine(new string(' ', leftPad) +
            "╔" + new string('═', contentWidth) + "╗");

        // Menu lines with padding and side borders
        foreach (var line in menuLines)
        {
            string padded = " " + line.PadRight(maxLengthMenu) + " ";

            Console.WriteLine(new string(' ', leftPad) +
                "║" + padded + "║");
        }

        // Bottom border of the menu box
        Console.WriteLine(new string(' ', leftPad) +
            "╚" + new string('═', contentWidth) + "╝");
        Console.ResetColor();
    }

}
