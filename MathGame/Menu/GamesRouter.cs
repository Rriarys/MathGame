namespace MathGame;

public static class GamesRouter
{
    public static void Run(int playerMenuChoice, int difficulty)    
    {            
        while (true)
        {    
            OperationsTasks operationTask = new OperationsTasks(); // Create an instance of OperationsTasks to call the game methods

            switch (playerMenuChoice)
            {   
                // +
                case 1:
                    {
                        TextDisplayMethods.PrintSeparator();
                        var (score, time) = operationTask.StartSubtractionGame(difficulty);
                        break;
                    }
                // -
                case 2:
                    {
                        TextDisplayMethods.PrintSeparator();
                        var (score, time) = operationTask.StartSubtractionGame(difficulty);
                        break;
                    } 
                // *
                case 3:
                    {
                        TextDisplayMethods.PrintSeparator(); 
                        var (score, time) = operationTask.StartMultiplicationGame(difficulty);
                        break;
                    } 
                // /
                case 4:
                    {
                        TextDisplayMethods.PrintSeparator(); 
                        var (score, time) = operationTask.StartDivisionGame(difficulty);
                        break;
                    }
                // Random operation
                case 5:
                    {
                        TextDisplayMethods.PrintSeparator(); 
                        var (score, time) = operationTask.StartRandomOperationsGame(difficulty);
                        break;     
                    }
            }
        }
    }
}