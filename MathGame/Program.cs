using MathGame;

// Save the original console colors to restore them later
var (originalBg, originalFg) = (Console.BackgroundColor, Console.ForegroundColor);
// Initialize the console with a black background and white foreground for better look and readability of the game interface
Console.BackgroundColor = ConsoleColor.Black;
// Clear the console to apply the new background color and provide a clean slate for the game interface
Console.Clear();

try
{
    // Text messages to be displayed (Game logo, information text, and author signature), only once at the beginning)
    DisplayVisuals.AppWelcomePreamble(TextConstants.logoText, TextConstants.infoText, TextConstants.signatureText);
    DisplayVisuals.PrintSeparator(); // Print a separator line to visually separate different sections of the console output
    GameEngine.Run(); // Start the game
}   
finally
{
    // Restore the original colors
    Console.BackgroundColor = originalBg;
    Console.ForegroundColor = originalFg;
    Console.Clear();
}