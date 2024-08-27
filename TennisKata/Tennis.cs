using System.Reflection.Metadata.Ecma335;

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
    public string Score() //?? 是不是要再拆分功能寫為function比較有可讀性，該放哪裡呼叫?
    {
        //1. 輸出必須為網球分數，例：1:0 => Fifteen Love 
        //2. 分數表達必須是文字，例: Fifteen Forty 而非 15：40 
        //3. 賽末點(gamepoint)時，輸出為 PlayerName Adv, 例：Sam Adv
        //4. 勝出時輸出為 PlayerName Win, 例：Sam Win

        // 同分
        if (_playerOneScore == _playerTwoScore)
        {
            return (_playerOneScore >= 3) ? "Deuce" : $"{GetScoreDescription(_playerOneScore)} All";
        }

        // 不同分 win
        if ((_playerOneScore >= 4 || _playerTwoScore >= 4) && Math.Abs(_playerOneScore - _playerTwoScore) == 2) // 勝利條件: 4分以上且比對手多2分
        {
            return (_playerOneScore > _playerTwoScore) ? $"{_playerOneName} Win" : $"{_playerTwoName} Win";
        }
        // 不同分 gamepoint
        else if (_playerOneScore >= 3 && _playerTwoScore >= 3) // 雙方皆得3分 => Deuce，Advantage放在win後面判斷否則通通吃到Adv的判定
        {
            return (_playerOneScore > _playerTwoScore) ? $"{_playerOneName} Adv" : $"{_playerTwoName} Adv";
        }
        // 不同分
        else
        {
            return $"{GetScoreDescription(_playerOneScore)} {GetScoreDescription(_playerTwoScore)}";
        }
    }

    public string GetScoreDescription(int score) //? 什麼時候用public 像這裡的轉換是for這個class才會使用到，那是不是用private就好
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
            // 不會出現 score == 4 比分情況，因為已含在特殊規則內。
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