namespace TennisKata;

public class Scorer
{
    public void AddPlayerScore(Player scoringPlayer, Player opponentPlayer)
    {
        var isLeadMoreThenOne = Math.Abs(scoringPlayer.Score - opponentPlayer.Score) > 1;
        var isAnyPlayerScoreHigherThenThree = scoringPlayer.Score > 3 || opponentPlayer.Score > 3;
        
        if (isLeadMoreThenOne && isAnyPlayerScoreHigherThenThree)
        {
            var leadPlayer = scoringPlayer.Score > opponentPlayer.Score  ? scoringPlayer : opponentPlayer;
            Console.WriteLine($"Player score did not increase; {leadPlayer.Name} has won.");
            return;
        }
        
        scoringPlayer.Score++;
    }
}