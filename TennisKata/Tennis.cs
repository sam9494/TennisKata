namespace TennisKata;

public class Tennis
{
    private readonly string _playerOneName;
    private int _playerOneScore;
    private int _playerTwoScore;
    private readonly string _playerTwoName;

    private readonly Dictionary<int, string> _scoreLookup = new Dictionary<int, string>()
    {
        { 0, "Love" },
        { 1, "Fifteen" },
        { 2, "Thirty" },
        { 3, "Forty" },
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
        return IsSameScore() ? IsDeuce() ? Deuce() : SameScore() :
            IsGamePoint() ? IsAdv() ? AdvState() : Win() : ScoreLookup();
    }

    private string ScoreLookup()
    {
        return $"{_scoreLookup[_playerOneScore]} {_scoreLookup[_playerTwoScore]}";
    }

    private string Win()
    {
        return $"{AdvPlayer()} Win";
    }

    private string AdvState()
    {
        return $"{AdvPlayer()} Adv";
    }

    private string AdvPlayer()
    {
        var advPlayer = _playerOneScore > _playerTwoScore ? _playerOneName : _playerTwoName;
        return advPlayer;
    }

    private bool IsAdv()
    {
        return Math.Abs(_playerOneScore - _playerTwoScore) == 1;
    }

    private bool IsGamePoint()
    {
        return _playerOneScore > 3 || _playerTwoScore > 3;
    }

    private string SameScore()
    {
        return $"{_scoreLookup[_playerOneScore]} All";
    }

    private static string Deuce()
    {
        return "Deuce";
    }

    private bool IsDeuce()
    {
        return _playerTwoScore >= 3;
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