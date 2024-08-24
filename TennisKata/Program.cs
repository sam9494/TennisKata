// See https://aka.ms/new-console-template for more information

using TennisKata;

Main();
return;

static void Main()
{
    var tennisGame = new Tennis("Arthur", "Heng");

    var score = tennisGame.Score();
    Console.WriteLine(score);
}