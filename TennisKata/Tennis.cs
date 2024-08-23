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

        //平手條件
        if (_playerOneScore == _playerTwoScore)
        {
            return _playerOneScore >= 3
                ? "Deuce"
                : $"{ScoreMeaning(_playerOneScore)} All";
        }

        //賽末點或贏家條件
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

        //未滿 4 分直接輸出比分條件
        if (_playerOneScore < 4 && _playerTwoScore < 4)
            return $"{ScoreMeaning(_playerOneScore)} {ScoreMeaning(_playerTwoScore)}";

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