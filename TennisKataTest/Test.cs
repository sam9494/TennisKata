using FluentAssertions;
using TennisKata;

namespace TennisKataTest;

public class Test
{
    private readonly Tennis _tennis;

    public Test()
    {
        _tennis = new Tennis("Sam", "Bryant");
    }

    [Fact]
    public void LoveAll()
    {
        var actual = _tennis.Score();
        actual.Should().Be("Love All");
    }

    [Fact]
    public void FifteenLove()
    {
        GivenPlayerOneScore(1);
        var actual = _tennis.Score();
        actual.Should().Be("Fifteen Love");
    }

    [Fact]
    public void ThirtyLove()
    {
        GivenPlayerOneScore(2);
        var actual = _tennis.Score();
        actual.Should().Be("Thirty Love");
    }

    [Fact]
    public void FortyLove()
    {
        GivenPlayerOneScore(3);
        var actual = _tennis.Score();
        actual.Should().Be("Forty Love");
    }

    [Fact]
    public void LoveFifteen()
    {
        GivenPlayerTwoScore(1);
        var actual = _tennis.Score();
        actual.Should().Be("Love Fifteen");
    }

    [Fact]
    public void LoveThirty()
    {
        GivenPlayerTwoScore(2);
        var actual = _tennis.Score();
        actual.Should().Be("Love Thirty");
    }

    [Fact]
    public void LoveForty()
    {
        GivenPlayerTwoScore(3);
        var actual = _tennis.Score();
        actual.Should().Be("Love Forty");
    }

    [Fact]
    public void FifteenThirty()
    {
        GivenPlayerOneScore(1);
        GivenPlayerTwoScore(2);
        var actual = _tennis.Score();
        actual.Should().Be("Fifteen Thirty");
    }

    [Fact]
    public void FifteenAll()
    {
        GivenPlayerOneScore(1);
        GivenPlayerTwoScore(1);
        var actual = _tennis.Score();
        actual.Should().Be("Fifteen All");
    }

    [Fact]
    public void ThirtyAll()
    {
        GivenPlayerOneScore(2);
        GivenPlayerTwoScore(2);
        var actual = _tennis.Score();
        actual.Should().Be("Thirty All");
    }

    [Fact]
    public void Deuce()
    {
        GivenPlayerOneScore(3);
        GivenPlayerTwoScore(3);
        var actual = _tennis.Score();
        actual.Should().Be("Deuce");
    }

    [Fact]
    public void Player1Adv()
    {
        GivenPlayerOneScore(4);
        GivenPlayerTwoScore(3);
        var actual = _tennis.Score();
        actual.Should().Be("Sam Adv");
    }

    [Fact]
    public void Player2Adv()
    {
        GivenPlayerOneScore(3);
        GivenPlayerTwoScore(4);
        var actual = _tennis.Score();
        actual.Should().Be("Bryant Adv");
    }

    [Fact]
    public void PlayerOneWin()
    {
        GivenPlayerOneScore(5);
        GivenPlayerTwoScore(3);
        var actual = _tennis.Score();
        actual.Should().Be("Sam Win");
    }

    [Fact]
    public void PlayerTwoWin()
    {
        GivenPlayerOneScore(3);
        GivenPlayerTwoScore(5);
        var actual = _tennis.Score();
        actual.Should().Be("Bryant Win");
    }


    private void GivenPlayerTwoScore(int times)
    {
        for (var i = 0; i < times; i++)
        {
            _tennis.PlayerTwoScore();
        }
    }


    private void GivenPlayerOneScore(int times)
    {
        for (var i = 0; i < times; i++)
        {
            _tennis.PlayerOneScore();
        }
    }
}