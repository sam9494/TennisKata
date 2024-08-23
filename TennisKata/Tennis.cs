namespace TennisKata;

public class Tennis
{
    private readonly string _playerOneName;
    private readonly string _playerTwoName;
    private int _playerOneScore;
    private int _playerTwoScore;

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
        if (_playerOneScore == 0 && _playerTwoScore == 0)
        {
            return "Love All";
        }
        else if (_playerOneScore >= 4 && _playerOneScore - _playerTwoScore >= 2)
        {
            return $"{_playerOneName} Win";
        }
        else if (_playerTwoScore >= 4 && _playerTwoScore - _playerOneScore >= 2)
        {
            return $"{_playerTwoName} Win";
        }
        else if (_playerOneScore >= 3 && _playerTwoScore >= 3)
        {
            if (_playerOneScore == _playerTwoScore)
            {
                return "Deuce";
            }
            else if (_playerOneScore > _playerTwoScore)
            {
                return $"{_playerOneName} Adv";
            }
            else
            {
                return $"{_playerTwoName} Adv";
            }
        }
        else
        {
            return $"{GetScoreDescription(_playerOneScore)} {GetScoreDescription(_playerTwoScore)}";
        }
    }

    public string GetScoreDescription(int score)
    {
        switch (score)
        {
            case 0:
                return "Love";
            case 1:
                return "Fifteen";
            case 2:
                return "Thirty";
            case 3:
                return "Forty";
            default:
                return "Error";
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