namespace TennisKata;

public class Tennis
{
    private readonly string _playerOneName;
    private readonly string _playerTwoName;
    private int _playerOneScore;
    private int _playerTwoScore;

    private readonly Dictionary<int, string> _scoreDic = new()
    {
        {0, "Love"},
        {1, "Fifteen"},
        {2, "Thirty"},
        {3, "Forty"}
    };
    public Tennis(string playerOneName, string playerTwoName)
    {
        _playerOneName = playerOneName;
        _playerTwoName = playerTwoName;
        _playerOneScore = 0;
        _playerTwoScore = 0;
    }
    public string Score()
    {

        //1. 輸出必須為網球分數 例：1:0 => Fifteen Love 
        //2. 分數表達必須是文字例如Fifteen Forty 而非15：40 
        //3. 賽末點時 輸出為 Player Name Adv, 例：Sam Adv
        //4. 勝出時 輸出為 Player Name Win, 例：Sam Win

        //重構
      return IsSameScore()? IsDeuce() ? Deuce() : SameScore() : 
          IsGamePoint() ? IsWin() ? Win() : Adv() : NormalDisplayScore();
    }

    private string Adv()
    {
        return $"{GetLeadPlayer()} Adv";
    }

    private string Win()
    {
        return $"{GetLeadPlayer()} Win";
    }

    private bool IsWin()
    {
        return GetLeadScore() >= 2;
    }

    private string NormalDisplayScore()
    {
        return $"{_scoreDic[_playerOneScore]} {_scoreDic[_playerTwoScore]}";
    }

    private string SameScore()
    {
        return $"{_scoreDic[_playerOneScore]} All";
    }

    private static string Deuce()
    {
        return "Deuce";
    }

    private bool IsDeuce()
    {
        return _playerOneScore >= 3 && IsSameScore();
    }

    private string GetLeadPlayer()
    {
        return _playerOneScore > _playerTwoScore ? _playerOneName : _playerTwoName;
    }

    private bool IsGamePoint()
    {
        return _playerOneScore >= 4 || _playerTwoScore >= 4;
    }

    private int GetLeadScore()
    {
        return Math.Abs(_playerOneScore - _playerTwoScore);
    }

    private bool IsSameScore()
    {
        return _playerOneScore == _playerTwoScore;
    }

    public void PlayerOneScore()
    {
        _playerOneScore++;
    }
    
    public void PlayerTwoScore()
    {
        _playerTwoScore++; 
    }

}