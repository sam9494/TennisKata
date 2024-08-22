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
        Dictionary<int,string> scoreName = new Dictionary<int, string>();
        scoreName.Add(0, "Love");
        scoreName.Add(1, "Fifteen");
        scoreName.Add(2, "Thirty");
        scoreName.Add(3, "Forty");

        var playerOneScore = _playerOneScore;
        var playerTwoScore = _playerTwoScore;

        if (playerOneScore == playerTwoScore && scoreName.ContainsKey(playerOneScore) && playerOneScore < 3)
        {
            return scoreName[playerTwoScore] + " ALL";
        }
        
        if (playerOneScore == playerTwoScore)
        {
            return "deuce";
        }
        
        if (playerOneScore >= 4 && (playerOneScore-playerTwoScore >= 2))
        {
            return _playerOneName + " Win";
        }
        
        if (playerTwoScore >= 4 && (playerTwoScore-playerOneScore >= 2))
        {
            return _playerTwoName + " Win";
        }

        if (playerOneScore >= 3 && (playerOneScore-playerTwoScore >= 1))
        {
            return _playerOneName + " Adv";
        }
        
        if (playerTwoScore >= 3 && (playerTwoScore-playerOneScore >= 1))
        {
            return _playerTwoName + " Adv";
        }

        if (scoreName.TryGetValue(playerOneScore, out var score1) && scoreName.TryGetValue(playerTwoScore, out var score2))
        {
            return score1 +" "+ score2;
        }

        return "Love All";
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