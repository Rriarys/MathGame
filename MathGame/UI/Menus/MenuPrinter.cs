namespace MathGame.Menu;

public class MenuPrinter
{
    public static void Print() =>
        DrawMenu(TextConstants.menuText); // PrintMenu(TextsHandler.menuText); // Print the menu with a typewriting effect  

    public static void DrawMenu(string menuText)
    {
        DisplayVisuals.PrintSeparator();
        Console.ForegroundColor = ConsoleColor.Cyan;
        ConsoleExtensions.TypeWriteLine("Choose operation for challenge by entering the corresponding number:\n");

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
    }
}
