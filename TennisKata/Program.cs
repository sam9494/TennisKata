// See https://aka.ms/new-console-template for more information

using TennisKata;

Main();
return;

static void Main()
{
    var arthur = new Player("Arthur");  
    var heng = new Player("Heng");  
    var tennis = new Tennis(arthur, heng);

    var score = tennis.Score();
    Console.WriteLine(score);
}