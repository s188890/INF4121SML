using System;

class Hangman
{
    static void Main()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        besenica game = new besenica();
        Write("Welcome to “Hangman” game. Please try to guess my secret word.");
        string command = null;
        Game(command, scoreBoard, game);
        
    }
    //This is the game running
    static void Game(string command, ScoreBoard scoreBoard, besenica game)
    {
        do
        {
            Console.WriteLine();
            game.PrintCurrentProgress();

            if (game.isOver())
            {
                GameOver(command, scoreBoard, game);
            }
            else
            {
                Console.Write("Enter your guess: ");
                command = Console.ReadLine();
                command.ToLower();
                if (command.Length == 1)
                {
                    Playing(command, game);
                }
                else
                    ExecuteCommand(command, scoreBoard, game);
            }
        } while (command != "exit");
    }
    //Checks wether a letter is revealed or not
    static void Playing(string command, besenica game)
    {
        int occuranses = game.NumberOccuranceOfLetter(command[0]);
        if (occuranses == 0)
            Write("Sorry! There are no unrevealed letters “{0}”.", command[0]);
        else
            Write("Good job! You revealed {0} letter(s).", occuranses);
    }
    //This method will run if the game is done and the player has guessed the word with or withouth help
    static void GameOver(string command, ScoreBoard scoreBoard, besenica game)
    {
        if (game.HelpUsed)
            Write("You won with {0} mistake(s) but you have cheated." +
                " You are not allowed to enter into the scoreboard.", game.Mistakes);
        else
        {
            if (scoreBoard.GetWorstTopScore() <= game.Mistakes)
            {
                Write("You won with {0} mistake(s) but you score did not enter in the scoreboard", game.Mistakes);
            }
            else
            {
                Console.Write("Please enter your name for the top scoreboard: ");
                string name = Console.ReadLine();
                scoreBoard.AddNewScore(name, game.Mistakes);
                scoreBoard.Print();
            }
        }
        game.ReSet();
    }
    //gets the message the console should write
    static void Write(string message)
    {
        Console.WriteLine(message);
    }
    static void Write(string message, int occurance)
    {
        Console.WriteLine(message, occurance);
    }
    static void Write(string message, char letter)
    {
        Console.WriteLine(message, letter);
    }
    //Diffrent commands that the user can enter to get diffrent results
    static void ExecuteCommand(string command, ScoreBoard scoreBoard, besenica game)
    {
        switch (command)
        {
            //Prints the scoreboard to the user
            case "top":
                    scoreBoard.Print();
                break;
            //Gives the user the next letter of the word
            case "help":
                { 
                    char revealedLetter = game.RevealALetter();
                    Write("OK, I reveal for you the next letter '{0}'.", revealedLetter);
                }
                break;
            //Restarts the game
            case "restart":
                { 
                    scoreBoard.ReSet();
                    Write("\nWelcome to “Hangman” game. Please try to guess my secret word.");
                    game.ReSet();
                }
                break;
            //Exits the game
            case "exit":
                {
                    Write("Good bye!");
                    return;
                }
            //This message will show if an incorrect guess or command is enterd
            default:
                    Write("Incorrect guess or command!");
                break;
        }
    }
}
///<summary>
///This class has a number of methods assosiated with the console messages and the game:
///- A number of console.write-methods
///- Evaluates the game(helpUsed/new high score/etc.)
///- Main method
///There is also comments above every method that gives a brief description of the specific method
///</summary>