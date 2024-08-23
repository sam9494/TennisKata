// See https://aka.ms/new-console-template for more information

using TennisKata;

Main();
return;

static void Main()
{
    var tennis = new Tennis("Sam", "Tom");
    tennis.PlayerOneScore();
    tennis.PlayerTwoScore();
    tennis.PlayerTwoScore();
    tennis.PlayerTwoScore();

    var score = tennis.Score();
    Console.WriteLine();
    Console.WriteLine(score);
}