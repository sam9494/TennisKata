using Xunit;
using FluentAssertions;
using TennisKata;

namespace UnitTest;

public class ScoreTests
{
    private Player _scoringPlayer;
    private Player _opponentPlayer;
    private Scorer _scorer;


    public ScoreTests()
    {
        _scoringPlayer = new Player("Heng");
        _opponentPlayer = new Player("Arthur");
        _scorer = new Scorer();
    }

    [Fact]
    public void GivenPlayersScoreLessThanThree_WhenPlayerScores_ThenScoreShouldIncrease()
    {
        GivenPlayersScore(0,0);
        WhenPlayerScores(_scoringPlayer);
        ThenPlayerScoreShouldBe(_scoringPlayer, 1);
                
        GivenPlayersScore(3,0);
        WhenPlayerScores(_scoringPlayer);
        ThenPlayerScoreShouldBe(_scoringPlayer, 4);
        
        GivenPlayersScore(3,1);
        WhenPlayerScores(_scoringPlayer);
        ThenPlayerScoreShouldBe(_scoringPlayer, 4);
        
        GivenPlayersScore(3,2);
        WhenPlayerScores(_scoringPlayer);
        ThenPlayerScoreShouldBe(_scoringPlayer, 4);
        
        GivenPlayersScore(3,3);
        WhenPlayerScores(_scoringPlayer);
        ThenPlayerScoreShouldBe(_scoringPlayer, 4);
    }

    [Fact]
    public void GivenScoringPlayerScoreMoreThanThreeAndLeadLessThanTwo_WhenAddPlayerScore_ThenScoreShouldBeIncrease()
    {
        GivenPlayersScoreByLead(4,0);
        WhenPlayerScores(_scoringPlayer);
        ThenPlayerScoreShouldBe(_scoringPlayer, 5);
        
        GivenPlayersScoreByLead(4,1);
        WhenPlayerScores(_scoringPlayer);
        ThenPlayerScoreShouldBe(_scoringPlayer, 5);
        
        GivenPlayersScoreByLead(8,0);
        WhenPlayerScores(_scoringPlayer);
        ThenPlayerScoreShouldBe(_scoringPlayer, 9);
        
        GivenPlayersScoreByLead(8,1);
        WhenPlayerScores(_scoringPlayer);
        ThenPlayerScoreShouldBe(_scoringPlayer, 9);
    }

    [Fact]
    public void GivenScoringPlayerScoreMoreThanThreeAndLeadMoreThanTwo_WhenPlayerScores_ThenScoreShouldNotIncrease()
    {
        GivenPlayersScoreByLead(4,4);
        WhenPlayerScores(_scoringPlayer);
        ThenPlayerScoreShouldBe(_scoringPlayer, 4);
        
        GivenPlayersScoreByLead(4,2);
        WhenPlayerScores(_scoringPlayer);
        ThenPlayerScoreShouldBe(_scoringPlayer, 4);
        
        GivenPlayersScoreByLead(6,2);
        WhenPlayerScores(_scoringPlayer);
        ThenPlayerScoreShouldBe(_scoringPlayer, 6);
        
        GivenPlayersScoreByLead(9,2);
        WhenPlayerScores(_scoringPlayer);
        ThenPlayerScoreShouldBe(_scoringPlayer, 9);
    }
    
    private void GivenPlayersScoreByLead(int playerScore, int leadScore)
    {
        _scoringPlayer.Score = playerScore;
        _opponentPlayer.Score = playerScore - leadScore;
    }
    

    private void ThenPlayerScoreShouldBe(Player player, int expectedScore)
    {
        player.Score.Should().Be(expectedScore);
    }

    private void WhenPlayerScores(Player scoringPlayer)
    {
        var opponentPlayer = scoringPlayer.Equals(_scoringPlayer) ? _opponentPlayer : _scoringPlayer;
        _scorer.AddPlayerScore(scoringPlayer, opponentPlayer);
    }

    private void GivenPlayersScore(int scoringPlayerScore,int opponentPlayerScore)
    {
        _scoringPlayer.Score = scoringPlayerScore;
        _opponentPlayer.Score = opponentPlayerScore;
    }
}