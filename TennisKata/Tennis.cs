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
        // 從分數是多少 = 甚麼條件去思考
        // 甚麼時候是賽末點，或有可能無限 adv 
        // 比分可能無上限?

        if (_playerOneScore == _playerTwoScore)
        {
            /*if (_playerOneScore == 0)
                return "Love All";

            else if (_playerOneScore == 1)
                return "Fifteen All";

            else if (_playerOneScore == 2)
                return "Thirty All";

            else return "Deuce";*/

            return _playerOneScore >= 3 
                ? "Deuce" 
                : $"{ScoreMeaning(_playerOneScore)} All";
        }

        /*//選手二號 0 分的條件
        if (_playerOneScore > _playerTwoScore && _playerTwoScore == 0)
        {
            if (_playerOneScore == 1)
                return "Fifteen Love";

            else if (_playerOneScore == 2)
                return "Thirty Love";

            else if (_playerOneScore == 3)
                return "Forty Love";

            else return $"{_playerOneName} Win!";
        }

        //選手二號 1 分的條件
        if (_playerOneScore > _playerTwoScore && _playerTwoScore == 1)
        {
            if (_playerOneScore == 2)
                return "Thirty Fifteen";

            else if (_playerOneScore == 3)
                return "Forty Fifteen";

            else return $"{_playerOneName} Win!";
        }

        //選手二號 2 分的條件
        if (_playerOneScore > _playerTwoScore && _playerTwoScore == 2)
        {
            if (_playerOneScore == 3)
                return "Forty Thirty";

            else return $"{_playerOneName} Win!";
        }

        //選手二號 3 分或以上的條件
        if (_playerOneScore > _playerTwoScore && _playerTwoScore >= 3)
        {
            if (_playerOneScore - _playerTwoScore == 1)
                return $"{_playerOneName} Adv";

            else return $"{_playerOneName} Win!";
        }

        //選手一號 0 分的條件
        if (_playerTwoScore > _playerOneScore && _playerOneScore == 0)
        {
            if (_playerTwoScore == 1)
                return "Love Fifteen";

            else if (_playerTwoScore == 2)
                return "Love Thirty";

            else if (_playerTwoScore == 3)
                return "Love Forty";

            else return $"{_playerTwoName} Win!";
        }

        //選手一號 1 分的條件
        if (_playerTwoScore > _playerOneScore && _playerOneScore == 1)
        {
            if (_playerTwoScore == 2)
                return "Fifteen Thirty";

            else if (_playerTwoScore == 3)
                return "Fifteen Forty";

            else return $"{_playerTwoName} Win!";
        }

        //選手一號 2 分的條件
        if (_playerTwoScore > _playerOneScore && _playerOneScore == 2)
        {
            if (_playerTwoScore == 3)
                return "Thirty Forty";

            else return $"{_playerTwoName} Win!";
        }

        選手一號 3 分或以上的條件
        if (_playerTwoScore > _playerOneScore && _playerOneScore >= 3)
        {
            if (_playerTwoScore - _playerOneScore == 1)
                return $"{_playerTwoName} Adv";

            else return $"{_playerTwoName} Win!";
        }*/

        if (_playerOneScore >= 4 || _playerTwoScore >= 4)
        {
            var scoreResult = _playerOneScore - _playerTwoScore;

            if (scoreResult == 1)
                return $"{_playerOneName} Adv";

            if (scoreResult >= 2)
                return $"{_playerOneName} Win!";

            if (scoreResult == -1)
                return $"{_playerTwoName} Adv";

            if (scoreResult <= -2)
                return $"{_playerTwoName} Win!";
        }

        return $"{ScoreMeaning(_playerOneScore)} {ScoreMeaning(_playerTwoScore)}";
    }

    public void PlayerOneScore()
    {
        _playerOneScore++;
    }

    public void PlayerTwoScore()
    {
        _playerTwoScore++;
    }

    public string ScoreMeaning(int score)
    {
        return score switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            3 => "Forty",
            _ => score.ToString()
        };
    }

}