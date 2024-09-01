namespace TennisKata;

public class TennisByShon
{
    private readonly string _playerOneName;
    private readonly string _playerTwoName;
    private int _playerOneScore;
    private int _playerTwoScore;


    public TennisByShon(string playerOneName, string playerTwoName)
    {
        _playerOneName = playerOneName;
        _playerTwoName = playerTwoName;
        _playerOneScore = 0;
        _playerTwoScore = 0;
    }

    private readonly Dictionary<int, string> _scoreDic = new Dictionary<int, string>() {
        { 0,"Love"},
        { 1,"Fifteen"},
        { 2,"Thirty"},
        { 3,"Forty"}
    };

    public string Score()
    {
        //1. 輸出必須為網球分數 例：1:0 => Fifteen Love 
        //2. 分數表達必須是文字例如Fifteen Forty 而非15：40 
        //3. 賽末點時 輸出為 Player Name Adv, 例：Sam Adv
        //4. 勝出時 輸出為 Player Name Win, 例：Sam Win


        if (IsSameScore())
        {
            return IsBothMoreThanThreePoint() ? Deuce() : ScoreAll();
        }

        if (GetLeadingScore() >= 4)
        {
            var end = GetScoreGap() == 1 ? " Adv" : " Win";
            return GetLeadingPlayerName() + end;
        }

        return GetNormalScoreDisplay();
    }

    private string GetNormalScoreDisplay()
    {
        return _scoreDic[_playerOneScore] + " " + _scoreDic[_playerTwoScore];
    }

    private string ScoreAll()
    {
        return _scoreDic[_playerOneScore] + " All";
    }

    private static string Deuce()
    {
        return "Deuce";
    }

    private string GetLeadingPlayerName()
    {
        return _playerOneScore > _playerTwoScore ? _playerOneName : _playerTwoName;
    }

    private int GetLeadingScore()
    {
        return _playerOneScore > _playerTwoScore ? _playerOneScore : _playerTwoScore;
    }

    private int GetScoreGap()
    {
        return Math.Abs(_playerOneScore - _playerTwoScore);
    }

    private bool IsBothMoreThanThreePoint()
    {
        return _playerOneScore >= 3 && _playerTwoScore >= 3;
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

    public void GiveScoreToPlayers(int givePlayerOneScore, int givePlayerTwoScore)
    {
        for (var i = 0; i < givePlayerOneScore; i++) { PlayerOneScore(); }
        for (var i = 0; i < givePlayerTwoScore; i++) { PlayerTwoScore(); }
    }
}