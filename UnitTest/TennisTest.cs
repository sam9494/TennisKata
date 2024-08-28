using TennisKata;
using Xunit;

namespace TennisTest;

public class TennisTest()
{
    private readonly Tennis? _tennis = new ("Sam1", "Sam2");
    private string _actual = "";

    [Theory]
    [InlineData(5,3,"Sam1")]
    [InlineData(10,8,"Sam1")]
    [InlineData(3,5,"Sam2")]
    [InlineData(8,10,"Sam2")]
    public void GivenPlayerScoreLeadTwoAndExceedFour_WhenGetScoreName_ThenReturnPlayerNameWin(int scoreOne, 
                                                                                                int scoreTwo,
                                                                                                string expectedPlayer)
    {
        GivenPlayerOneScore(scoreOne);
        GivenPlayerTwoScore(scoreTwo);
        WhenGetScoreNameFromScoreMethod();
        ThenScoreNameShouldEqualExpect($"{expectedPlayer} Win");
    }
    
    [Theory]
    [InlineData(4,0,"Sam1")]
    [InlineData(4,1,"Sam1")]
    [InlineData(4,2,"Sam1")]
    [InlineData(0,4,"Sam2")]
    [InlineData(1,4,"Sam2")]
    [InlineData(2,4,"Sam2")]
    public void GivenPlayerScoreFourAndLeadTwoToFour_WhenGetScoreName_ThenReturnPlayerNameWin(int scoreOne, 
                                                                                                int scoreTwo,
                                                                                                string expectedPlayer)
    {
        GivenPlayerOneScore(scoreOne);
        GivenPlayerTwoScore(scoreTwo);
        WhenGetScoreNameFromScoreMethod();
        ThenScoreNameShouldEqualExpect($"{expectedPlayer} Win");
    }
    
    [Theory]
    [InlineData(4,3,"Sam1")]
    [InlineData(5,4,"Sam1")]
    [InlineData(10,9,"Sam1")]
    [InlineData(3,4,"Sam2")]
    [InlineData(4,5,"Sam2")]
    [InlineData(9,10,"Sam2")]
    public void GivenPlayerScoreLeadOneAndExceedThree_WhenGetScoreName_ThenReturnPlayerNameAdv(int scoreOne, 
        int scoreTwo,
        string expectedPlayer)
    {
        GivenPlayerOneScore(scoreOne);
        GivenPlayerTwoScore(scoreTwo);
        WhenGetScoreNameFromScoreMethod();
        ThenScoreNameShouldEqualExpect($"{expectedPlayer} Adv");
    }
    
    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(10)]
    public void GivenPlayersScoreExceedTwoAndEqual_WhenGetScoreName_ThenReturnDeuce(int score)
    {
        GivenPlayerOneScore(score);
        GivenPlayerTwoScore(score);
        WhenGetScoreNameFromScoreMethod();
        ThenScoreNameShouldEqualExpect("Deuce");
    }
    
    [Theory]
    [InlineData(0,"Love")]
    [InlineData(1,"Fifteen")]
    [InlineData(2,"Thirty")]
    public void GivenPlayersScoreZeroToTwoAndEqual_WhenGetScoreName_ThenReturnScoreNameAll(int score, 
        string expectedScoreName)
    {
        GivenPlayerOneScore(score);
        GivenPlayerTwoScore(score);
        WhenGetScoreNameFromScoreMethod();
        ThenScoreNameShouldEqualExpect($"{expectedScoreName} All");
    }
    
    [Theory]
    [InlineData(0,1,"Love","Fifteen")]
    [InlineData(0,2,"Love","Thirty")]
    [InlineData(0,3,"Love","Forty")]
    [InlineData(1,2,"Fifteen","Thirty")]
    [InlineData(1,3,"Fifteen","Forty")]
    [InlineData(2,3,"Thirty","Forty")]
    [InlineData(1,0,"Fifteen","Love")]
    [InlineData(2,0,"Thirty","Love")]
    [InlineData(3,0,"Forty","Love")]
    [InlineData(2,1,"Thirty","Fifteen")]
    [InlineData(3,1,"Forty","Fifteen")]
    [InlineData(3,2,"Forty","Thirty")]
    public void GivenPlayersScoreZeroToThreeAndDiff_WhenGetScoreName_ThenReturnScoreName(int playerOneScore,
                                                                                            int playerTwoScore,
                                                                                            string playerOneScoreName,
                                                                                            string playerTwoScoreName)
    {
        GivenPlayerOneScore(playerOneScore);
        GivenPlayerTwoScore(playerTwoScore);
        WhenGetScoreNameFromScoreMethod();
        ThenScoreNameShouldEqualExpect($"{playerOneScoreName} {playerTwoScoreName}");
    }
    

    private void ThenScoreNameShouldEqualExpect(string expectedScoreName)
    {
        Assert.Equal(expectedScoreName, _actual);
    }

    private void WhenGetScoreNameFromScoreMethod()
    {
        _actual = _tennis?.Score()??"Please Check Is Tennis Init";
    }

    private void GivenPlayerTwoScore(int opponentScore)
    {
        Enumerable.Range(0,opponentScore).ToList().ForEach(_=>_tennis?.PlayerTwoScore());
    }

    private void GivenPlayerOneScore(int playerOneScore)
    {
        Enumerable.Range(0,playerOneScore).ToList().ForEach(_=>_tennis?.PlayerOneScore());
    }
}