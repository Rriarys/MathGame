using MathGame;

const string welcomeText = @"
 __  __       _   _        ____                      
|  \/  | __ _| |_| |__    / ___| __ _ _ __ ___   ___ 
| |\/| |/ _` | __| '_ \  | |  _ / _` | '_ ` _ \ / _ \
| |  | | (_| | |_| | | | | |_| | (_| | | | | | |  __/
|_|  |_|\__,_|\__|_| |_|  \____|\__,_|_| |_| |_|\___|
=====================================================
";

const string infoText = "Welcome to the Math Game! This is a fun and interactive game designed to help you practice and improve your math skills.";

const string signatureText = "Made by Rriarys";

const string menuText = @"
1. Addition
2. Subtraction
3. Multiplication
4. Division
5. Random operations
8. Change player session
9. Story of games
0. Exit";

// Custom methods for typewriting effect
void TypeWrite(string text, int delay = 15)
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
void TypeWriteLine(string text, int delay = 15)
{
    TypeWrite(text, delay);
    Console.WriteLine();
}

// Spinner animation method to show a loading effect
void StoryShowLoadingAnimation()
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

void PlayerNameChangingLoadingAnimation()
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
string[] WrapText(string text, int maxWidth)
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

// =============================== MAIN PROGRAM ===============================
while (true)
{   
    // =============================== WELCOME MESSAGE ===============================
    var welcomeLines = welcomeText // Split the welcome text into lines, remove empty lines, and convert to an array for processing
        .Split('\n')
        .Where(l => !string.IsNullOrWhiteSpace(l))
        .ToArray();

    Console.ForegroundColor = ConsoleColor.Cyan;

    int maxLength = welcomeLines.Max(l => l.Length); // Calculate the maximum length of the lines in the welcome text to help with centering the text in the console window
    foreach (var line in welcomeLines)
    {
        int pad = (Console.WindowWidth - maxLength) / 2; // Calculate the left padding to center the text in the console window based on the maximum line length
        Console.WriteLine(line.PadLeft(pad + line.Length)); // Pad the line with spaces on the left to center it in the console window and print it to the console
    }
    Console.ResetColor();
    Console.WriteLine();

    // =============================== INFORMATION MESSAGE ===============================
    var wrappedInfo = WrapText(infoText.Trim(), maxLength - 5); // Wrap the information text to fit within the console window, using the maximum line length from the welcome text minus some padding for better readability
    Console.ForegroundColor = ConsoleColor.DarkCyan;

    foreach (var line in wrappedInfo)
    {
        int pad = (maxLength - line.Length) / 2;
        int totalPad = (Console.WindowWidth - maxLength) / 2 + pad;
        TypeWriteLine(new string(' ', totalPad) + line); // Pad the line with spaces on the left to center it in the console window and print it with a typewriting effect
    }
    Console.ResetColor();
    Console.WriteLine();

    // =============================== AUTHOR SIGNATURE ===============================
    int signaturePad = (Console.WindowWidth - signatureText.Length) / 2;
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    TypeWriteLine(new string(' ', signaturePad) + signatureText);
    Console.ResetColor();

    Console.WriteLine();

    // =============================== SEPARATOR ===============================
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine(new string('=', Console.WindowWidth));
    Console.ResetColor();

    // =============================== GOTO ===============================
    ChangePlayer:; // Label for changing player, used with goto statement

    TypeWrite("\nPlease enter your name: ");
    string playerName = Console.ReadLine() ?? "Player"; // If the user doesn't enter a name, default to "Player"

    Console.ForegroundColor = ConsoleColor.Magenta;
    TypeWriteLine($"\nHello, {playerName}! Let's play the Math Game!\n");
    Console.ResetColor();

    // =============================== GAME INSTANCE ===============================
    OperationsTasks operationTask = new OperationsTasks(); // Create an instance of OperationsTasks to call the game methods
    
    while (true)
    {   
        // =============================== SEPARATOR ===============================
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(new string('=', Console.WindowWidth));
        Console.ResetColor();

        // =============================== MENU DISPLAY ===============================
        Console.ForegroundColor = ConsoleColor.Magenta;
        TypeWriteLine("\nChoose operation for challenge by entering the corresponding number:\n");
        Console.ResetColor();

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

        // =============================== CHOICE OPERATION ===============================
        TypeWrite("\n\nEnter your choice: ");
        string? playerChoice = Console.ReadLine();
        Console.WriteLine();

        switch (playerChoice)
        {
            case "1": 
                // =============================== SEPARATOR ===============================
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(new string('=', Console.WindowWidth));
                Console.ResetColor();

                operationTask.StartAdditionGame(); break;
            case "2": 
                // =============================== SEPARATOR ===============================
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(new string('=', Console.WindowWidth));
                Console.ResetColor();

                operationTask.StartSubtractionGame(); break;
            case "3": 
                // =============================== SEPARATOR ===============================
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(new string('=', Console.WindowWidth));
                Console.ResetColor();
                
                operationTask.StartMultiplicationGame(); break;
            case "4": 
                // =============================== SEPARATOR ===============================
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(new string('=', Console.WindowWidth));
                Console.ResetColor();

                operationTask.StartDivisionGame(); break;
            case "5": 
                // =============================== SEPARATOR ===============================
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(new string('=', Console.WindowWidth));
                Console.ResetColor();

                operationTask.StartRandomOperationsGame(); break;
            case "8":
                // =============================== SEPARATOR ===============================
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(new string('=', Console.WindowWidth));
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                PlayerNameChangingLoadingAnimation();
                Console.ResetColor();
                goto ChangePlayer; // Use goto to break out of the inner loop and prompt for a new player name
            case "9":
                // =============================== SEPARATOR ===============================
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(new string('=', Console.WindowWidth));
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                StoryShowLoadingAnimation();
                Console.ResetColor();
                break;
            case "0":
                Console.ForegroundColor = ConsoleColor.Magenta;
                TypeWriteLine($"Thank you, {playerName}, for playing the Math Game! Goodbye!");
                Console.ResetColor();
                return; // Exit the program
            default:
                Console.ForegroundColor = ConsoleColor.Yellow;
                TypeWriteLine("Invalid choice. Please enter a valid number.");
                Console.ResetColor();
                continue; // Prompt the user again if the input is invalid
        }
    }
}