namespace TennisKata;

public class Scorer
{
    public void AddPlayerScore(Player scoringPlayer, Player opponentPlayer)
    {
        scoringPlayer.Score++;
    }
}