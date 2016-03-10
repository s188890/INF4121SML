using System;

class ScoreBoard
{
    public const int NUMBER_OF_SCORES = 5;
    private string[] scoreNames = new string[NUMBER_OF_SCORES];
    private int[] mistackes = new int[NUMBER_OF_SCORES];
    private bool isEmpty;

    public ScoreBoard()
    {
        for (int i = 0; i < scoreNames.Length; i++)
        {
            scoreNames[i] = null;
            mistackes[i] = int.MaxValue;
        }
        isEmpty = true;
    }
    //Shows the scoreboard
    public void Print()
    {
        if (isEmpty)
        {
            Console.WriteLine("Scoreboard is empty!");
        }
        else
        {
            Console.WriteLine("Scoreboard:");
            int i = 0;
            while (scoreNames[i] != null)
            {
                Console.WriteLine("{0}. {1} ---> {2} mistacke(s)!", i + 1, scoreNames[i], mistackes[i]);
                    i++;
                    if (i >= scoreNames.Length)
                    {
                        break;
                    }
            }
        }
    }
    //Adds a new player to the highscore
    public void AddNewScore(string nickname, int mistakes)
    {
        int indexToPutNewScore = FindIndexWhereToPutNewScore(mistakes);
        if (indexToPutNewScore == scoreNames.Length)
        {
            return;
        }
        else
        {
            MoveScoresDownByOnePosition(indexToPutNewScore);
            scoreNames[indexToPutNewScore] = nickname;
            mistackes[indexToPutNewScore] = mistakes;
            isEmpty = false;
        }
    }
    //Finds where to put the player with a new highscore
    private int FindIndexWhereToPutNewScore(int mistakes)
    {
        for (int i = 0; i < mistackes.Length; i++)
        {
            if (mistakes < mistackes[i])
            {
                    return i;
            }
        }
        return scoreNames.Length;
    }
    //Moves a player one position down
    private void MoveScoresDownByOnePosition(int startPosition)
    {
        for (int i = scoreNames.Length - 1; i > startPosition; i--)
        {
                scoreNames[i] = scoreNames[i - 1];
                mistackes[i] = mistackes[i - 1];
        }
    }
    //Gets the player who is at the bottom of the highscore
    public int GetWorstTopScore()
    {
        int worstTopScore = int.MaxValue;
        if (scoreNames[scoreNames.Length - 1] != null) worstTopScore = mistackes[scoreNames.Length - 1];
        return worstTopScore;
    }

    //Sets the highscore to be empty
    public void ReSet()
    {
        for (int i = 0; i < scoreNames.Length; i++)
        {
            scoreNames[i] = null;
                mistackes[i] = 0;
        }
        isEmpty = true;
    }
}
///<summary>
///This class keeps track of the scoreboard
///- Adds new players to the scoreboard
///- Moves players down on the scoreboard if there is a new player with a better score
///- Resets the scoreboard
///- Gets worst score on the scoreboard
///- Prints the scoreboard
///</summary>