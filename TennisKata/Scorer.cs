namespace TennisKata;

public class Scorer
{
    public void AddPlayerScore(Player scoringPlayer, Player opponentPlayer)//簽章要不要放 opponentPlayer? 給了是告訴讀者加分邏輯會受到對手分數影響
    {
        var leadScore = Math.Abs(scoringPlayer.Score - opponentPlayer.Score);
        var highestScore = Math.Max(scoringPlayer.Score, opponentPlayer.Score);
        var isGameOver = leadScore > 1 && highestScore > 3;
        
        if (isGameOver)
        {
            var leadPlayer = scoringPlayer.Score > opponentPlayer.Score  ? scoringPlayer : opponentPlayer;
            Console.WriteLine($"Player score did not increase; {leadPlayer.Name} has won.");
            return;
        }
        
        scoringPlayer.Score++;
    }
}