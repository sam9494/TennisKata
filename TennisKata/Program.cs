// See https://aka.ms/new-console-template for more information

using TennisKata;

Main();
return;

static void Main()
{
    var arthur = new Player("Arthur");  
    var heng = new Player("Heng");
    var scorer = new Scorer();
    var tennisGame = new TennisGame(arthur, heng,scorer);

    var score = tennisGame.Score();
    Console.WriteLine(score);
}