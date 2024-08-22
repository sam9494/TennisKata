namespace TennisKata;

public class Tennis
{
    private readonly string _playerOneName;
    private int _playerOneScore;
    private int _playerTwoScore;
    private readonly string _playerTwoName;

    private static readonly Dictionary<int, string> ScoreNames = new Dictionary<int, string>
    {
        { 0, "Love" },
        { 1, "Fifteen" },
        { 2, "Thirty" },
        { 3, "Forty" }
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
        
        //判斷是否局末平分
        if (IsDeuce())
        {
            return "Deuce";
        }
        
        //判斷贏家
        if (IsWinConditionMet())
        {
            return GetLeadingPlayerName() + " Win";
        }

        //判斷賽末點
        if (IsAdvantageConditionMet())
        {
            return GetLeadingPlayerName() + " Adv";
        }

        //表達分數
        return GetScoreDescription();
    }
    
    //任一選手大於4分，且比對手高於兩分即可獲勝
    private bool IsWinConditionMet()
    {
        return (_playerOneScore >= 4 || _playerTwoScore >= 4) && Math.Abs(_playerOneScore - _playerTwoScore) >= 2;
    }
    
    //任一選手差一分就獲勝，且至少比對手高於一分即進入賽末點
    private bool IsAdvantageConditionMet()
    {
        return (_playerOneScore >= 3 || _playerTwoScore >= 3) && Math.Abs(_playerOneScore - _playerTwoScore) >= 1;
    }

    //兩位玩家局末平分
    private bool IsDeuce()
    {
        return _playerOneScore >= 3 && _playerOneScore == _playerTwoScore;
    }

    //判斷哪個玩家的分數較高
    private string GetLeadingPlayerName()
    {
        return _playerOneScore > _playerTwoScore ? _playerOneName : _playerTwoName;
    }

    //玩家進入賽末點之前的分數表現
    private string GetScoreDescription()
    {
        string playerOneScoreDescription = ScoreNames[_playerOneScore];
        string playerTwoScoreDescription = ScoreNames[_playerTwoScore];
        
        if (_playerOneScore == _playerTwoScore )
        {
            return playerOneScoreDescription + " ALL";
        }
        
        return playerOneScoreDescription +" "+ playerTwoScoreDescription;
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