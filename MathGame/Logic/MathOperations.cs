namespace MathGame;

public static class MathOperations
{
    // Returns the maximum numeric value for the game based on chosen difficulty
    public static int GetDifficultyLimit(int difficulty, int easy, int medium, int hard) =>
        difficulty switch
        {
            1 => easy,
            2 => medium,
            3 => hard,
            _ => medium // Default fallback to medium difficulty
        };

    // Standard arithmetic tasks returning a tuple with operands, symbol, and result
    public static (int num1, int num2, string op, int res) CreateAddition(int a, int b) => 
        (a, b, "+", a + b);
    public static (int num1, int num2, string op, int res) CreateSubtraction(int a, int b) => 
        (a, b, "-", a - b);
    public static (int num1, int num2, string op, int res) CreateMultiplication(int a, int b) => 
        (a, b, "*", a * b);
    public static (int num1, int num2, string op, int res) CreateDivision(int dividend, int divisor) =>
        (dividend, divisor, "/", dividend / divisor);
}