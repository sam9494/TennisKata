
using TennisKata;
// using Xunit;

namespace Test;

public class ScoreTest
{
    
    // 同分
    [Theory]
    // Arrange 初始化
    // 同分
    [InlineData(0, 0, "Love All")]
    [InlineData(1, 1, "Fifteen All")]
    [InlineData(2, 2, "Thirty All")]
    [InlineData(3, 3, "Deuce")]
    [InlineData(4, 4, "Deuce")]
    // 不同分 Adv
    [InlineData(4, 3, "Sam1 Adv")]
    [InlineData(3, 4, "Sam2 Adv")]
    [InlineData(5, 4, "Sam1 Adv")]
    [InlineData(4, 5, "Sam2 Adv")]
    // 不同分 Win
    [InlineData(5, 3, "Sam1 Win")]
    [InlineData(3, 5, "Sam2 Win")]
    [InlineData(6, 4, "Sam1 Win")]
    [InlineData(4, 6, "Sam2 Win")]
    // 不同分
    [InlineData(1, 0, "Fifteen Love")]
    [InlineData(2, 0, "Thirty Love")]
    [InlineData(3, 0, "Forty Love")]
    [InlineData(0, 1, "Love Fifteen")]
    [InlineData(0, 2, "Love Thirty")]
    [InlineData(0, 3, "Love Forty")]

    public void Score_SameScores(int playerOneScore, int playerTwoScore, string expectedScoreDescription)
    {
        // Act 執行方法、行為、操作並取得結果
        var tennis = new Tennis("Sam1", "Sam2");
        
        for (int i = 0; i < playerOneScore; i++)
        {
            tennis.PlayerOneScore();
        }

        for (int i = 0; i < playerTwoScore; i++)
        {
            tennis.PlayerTwoScore();
        }

        var result = tennis.Score();

        // Assert 驗證
        Assert.Equal(expectedScoreDescription, result);
    }
}
    