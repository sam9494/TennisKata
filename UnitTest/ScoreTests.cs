using Xunit;
using FluentAssertions;
using TennisKata;

namespace UnitTest;

public class ScoreTests
{
    private Player _player1;
    private Player _player2;
    private Scorer _scorer;


    public ScoreTests()
    {
        _player1 = new Player("Heng");
        _player2 = new Player("Arthur");
        _scorer = new Scorer();
    }

    [Fact]
    public void PlayerAddScoreOnce()
    {
        GivenPlayersZeroScore();
        WhenPlayerScoring(_player1, 1);
        ThenPlayerScoreShouldBe(_player1, 1);
    }

    private void ThenPlayerScoreShouldBe(Player player, int expectedScore)
    {
        player.Score.Should().Be(expectedScore);
    }

    private void WhenPlayerScoring(Player scoringPlayer, int scoreIncrement)
    {
        var opponentPlayer = scoringPlayer.Equals(_player1) ? _player2 : _player1;

        for (var i = 0; i < scoreIncrement; i++)
        {
            _scorer.AddPlayerScore(scoringPlayer, opponentPlayer);
        }
    }

    private void GivenPlayersZeroScore()
    {
        _player1.Score = 0;
        _player2.Score = 0;
    }
}