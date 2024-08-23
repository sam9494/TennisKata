// See https://aka.ms/new-console-template for more information

using TennisKata;

Main();
return;

static void Main()
{
    var tennis = new Tennis("Sam1", "Sam2");
    tennis.PlayerTwoScore();
    tennis.PlayerTwoScore();
    tennis.PlayerOneScore();
    tennis.PlayerOneScore();
    tennis.PlayerOneScore();
    tennis.PlayerTwoScore();
    tennis.PlayerTwoScore();
    tennis.PlayerOneScore();
    tennis.PlayerOneScore();

    var score = tennis.Score();
    Console.WriteLine(score);
}