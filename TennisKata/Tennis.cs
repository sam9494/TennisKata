namespace TennisKata;

public class Tennis
{
    private readonly string _playerOneName;
    private int _playerOneScore;
    private int _playerTwoScore;
    private readonly string _playerTwoName;

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

        // 平分時
        if (_playerOneScore == _playerTwoScore)
        {
            switch (_playerOneScore)
            {
                case 0:
                    return "Love All";
                case 1:
                    return "Fifteen All";
                case 2:
                    return "Thirty All";
                default:
                    return "Deuce";
            };
        };
        // 進到deuce後
        if (_playerOneScore >= 4 || _playerTwoScore >= 4)
        {
            int scoreDifference = _playerOneScore - _playerTwoScore;
            if (scoreDifference == 1) { return $"{_playerOneName} Adv"; }
            if (scoreDifference == -1) { return $"{_playerTwoName} Adv"; }
            if (scoreDifference == 2) { return $"{_playerOneName} Win"; }
            if (scoreDifference == -2) { return $"{_playerTwoName} Win"; }
        }

        // 計分
        string score1 = GetScore(_playerOneScore,_playerOneName);
        string score2 = GetScore(_playerTwoScore, _playerTwoName);
        if (_playerOneScore == 4)
        {
            return $"{_playerOneName} Win";
        }
        else if (_playerTwoScore == 4)
        {
            return $"{_playerTwoName} Win";
        }
        else 
        { 
            return $"{score1} {score2}";
        }

    }
    // 各比分時所顯示的字串
    public string GetScore(int score, string name) 
    {
        switch (score) {
            case 0:
                return "Love";
            case 1:
                return "Fifteen";
            case 2:
                return "Thirty";
            case 3:
                return "Forty";
            default:
                return "";

        }
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