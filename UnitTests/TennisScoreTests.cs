using TennisKata;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests;

public class TennisScoreTests
{
    private readonly Tennis _tennisScore;
    
    
    public TennisScoreTests()
    {
        _tennisScore = new Tennis("playerOneName", "playerTwoName");
    }

    [Fact]
    public void Score_0to0_LoveAll()
    {
        Assert.Equal("Love ALL", _tennisScore.Score());
    }
    
    [Fact]
    public void Score_2to1()
    {
        _tennisScore.PlayerOneScore();
        _tennisScore.PlayerTwoScore();
        _tennisScore.PlayerOneScore();
        Assert.Equal("Thirty Fifteen", _tennisScore.Score());
    }
    
    [Fact]
    public void Score_0to1()
    {
        _tennisScore.PlayerTwoScore();
        Assert.Equal("Love Fifteen", _tennisScore.Score());
    }
    
    [Fact]
    public void Score_1to3_isPlayerTwo_Adv()
    {
        _tennisScore.PlayerTwoScore();
        _tennisScore.PlayerTwoScore();
        _tennisScore.PlayerTwoScore();
        _tennisScore.PlayerOneScore();
        Assert.Equal("playerTwoName Adv", _tennisScore.Score());
    }
    
    [Fact]
    public void Score_4to3_isPlayerOne_Adv()
    {
        _tennisScore.PlayerOneScore();
        _tennisScore.PlayerOneScore();
        _tennisScore.PlayerOneScore();
        _tennisScore.PlayerOneScore();
        _tennisScore.PlayerTwoScore();
        _tennisScore.PlayerTwoScore();
        _tennisScore.PlayerTwoScore();
        Assert.Equal("playerOneName Adv", _tennisScore.Score());
    }
    
    [Fact]
    public void Score_3to3_isDeuce()
    {
        _tennisScore.PlayerOneScore();
        _tennisScore.PlayerOneScore();
        _tennisScore.PlayerOneScore();
        _tennisScore.PlayerTwoScore();
        _tennisScore.PlayerTwoScore();
        _tennisScore.PlayerTwoScore();
        Assert.Equal("Deuce", _tennisScore.Score());
    }
    
    [Fact]
    public void Score_2to4_isPlayerTwo_Win()
    {
        _tennisScore.PlayerOneScore();
        _tennisScore.PlayerOneScore();
        _tennisScore.PlayerTwoScore();
        _tennisScore.PlayerTwoScore();
        _tennisScore.PlayerTwoScore();
        _tennisScore.PlayerTwoScore();
        Assert.Equal("playerTwoName Win", _tennisScore.Score());
    }
    
    [Fact]
    public void Score_5to3_isPlayerOne_Win()
    {
        _tennisScore.PlayerOneScore();
        _tennisScore.PlayerOneScore();
        _tennisScore.PlayerOneScore();
        _tennisScore.PlayerOneScore();
        _tennisScore.PlayerOneScore();
        _tennisScore.PlayerTwoScore();
        _tennisScore.PlayerTwoScore();
        _tennisScore.PlayerTwoScore();
        Assert.Equal("playerOneName Win", _tennisScore.Score());
    }
    
    
}



