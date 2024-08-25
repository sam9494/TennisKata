using TennisKata.Helper;

namespace TennisKata;

public class Tennis
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;
    private int _leadScore;
    private int _highestScore;

    public Tennis(string playerOneName, string playerTwoName)
    {
        _playerOne = new Player(playerOneName);
        _playerTwo = new Player(playerTwoName);
        _leadScore = 0;
        _highestScore = 0;
    }

    public void PlayerOneScore()
    {
        var isGameOver = CheckGameOver();
        if (isGameOver) return;
        _playerOne.Score++;
        UpdateLeadAndHightestScore();
    }
    
    public void PlayerTwoScore()
    {
        var isGameOver = CheckGameOver();
        if(isGameOver) return;
        _playerTwo.Score++;
        UpdateLeadAndHightestScore();
    }

    private void UpdateLeadAndHightestScore()
    {
        _leadScore= Math.Abs(_playerOne.Score - _playerTwo.Score);
        _highestScore = Math.Max(_playerOne.Score, _playerTwo.Score);
    }

    private bool CheckGameOver()
    {
        var isGameOver = _leadScore >= 2 && _highestScore >= 4;
        if (isGameOver) Console.WriteLine("Game Over.");
        return isGameOver;
    }

    
    public string Score()
    {
        //1. 輸出必須為網球分數 例：1:0 => Fifteen Love 
        //2. 分數表達必須是文字例如Fifteen Forty 而非15：40 
        //3. 賽末點時 輸出為 Player Name Adv, 例：Sam Adv
        //4. 勝出時 輸出為 Player Name Win, 例：Sam Win
        return "Love All";
    }
}