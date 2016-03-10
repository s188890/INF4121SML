using System;
using System.IO;

class besenica
{
    // Declaration of private variables for this class
    private string wordToGuess;
    private char[] guessedLetters;
    private int mistakes;
    private bool helpUsed;
    private string[] words = { "computer", "programmer", "software", "debugger", "compiler", "developer", "algorithm", "array", "method", "variable" };
    private Random randomGenerator = new Random();
    public besenica()
    {
        ReSet();
    }
    //Generates random word from the string array 'words'. The char array is created and statistics reset.
    public void ReSet()
    {
        this.wordToGuess = selectRandomWord();
        guessedLetters = new char[wordToGuess.Length];
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            guessedLetters[i] = '_';
        }
        mistakes = 0;
        helpUsed = false;
    }

    //get-methods for mistakes and helpUsed
    public int Mistakes
    {
        get { return mistakes; }
    }
    public bool HelpUsed
    {
        get { return helpUsed; }
    }
    //Reveals the first character that hasn't been guessed 
    public char RevealALetter()
    {
        char toReturn = char.MinValue;
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            if (guessedLetters[i] == '_')
            {
                guessedLetters[i] = wordToGuess[i];
                toReturn = wordToGuess[i];
                helpUsed = true;
                break;
            }
        }
        return toReturn;
    }
    //Checks if the guessed letter is contained once or multiple times in the word. If not, adds a mistake.
    public int NumberOccuranceOfLetter(char letter)
    {
        int count = 0;
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            if (wordToGuess[i] == letter)
            {
                guessedLetters[i] = letter;
                count++;
            }
        }
        if (count == 0)
            mistakes++;
        return count;
    }
    //Prints a '_' for each letter of the word.
    public void PrintCurrentProgress()
    {
        Console.Write("The secret word is: ");
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            Console.Write("{0} ", guessedLetters[i]);
        }
        Console.WriteLine();
    }
    //Checks if the word is guessed or has unrevealed characters.
    public bool isOver()
    {
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            if (guessedLetters[i] == '_')
                return false;
        }
        return true;
    }
    //Generates a random word from the string array 'words'.
    private string selectRandomWord()
    {
        using (var stream = new MemoryStream())
        {
            int choice = randomGenerator.Next(words.Length);
            return words[choice];
        }
    }
}
/// <summary>
/// This class has a number of methods assosiated with the game and gameplay. This includes:
/// - Generate random word from string array
/// - Check if a letter is contained in a word
/// - Reveals a letter if the players wishes to do so
/// - Check if the game is finished
/// - Resets game
/// There is also comments above every method that gives a brief description of the specific method
/// </summary>