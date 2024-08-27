using TennisKata.Helper;

namespace TennisKata;

public class Tennis
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;
    private int _leadScore;
    private int _highestScore;
    private bool _isGameOver;
    private string _currentScoreNameOfPlayers;
    private bool _isNeedUpdateScoreName;

    public Tennis(string playerOneName, string playerTwoName)
    {
        _playerOne = new Player(playerOneName);
        _playerTwo = new Player(playerTwoName);
        _leadScore = 0;
        _highestScore = 0;
        _currentScoreNameOfPlayers = "Love all";
        _isGameOver = false;
        _isNeedUpdateScoreName = false;
    }

    public void PlayerOneScore()
    {
        if (_isGameOver) return;
        _playerOne.Score++;
        _isNeedUpdateScoreName = true;
        UpdateLeadAndHighestScore();
        CheckGameOver();
    }
    
    public void PlayerTwoScore()
    {
        if(_isGameOver) return;
        _playerTwo.Score++;
        _isNeedUpdateScoreName = true;
        UpdateLeadAndHighestScore();
        CheckGameOver();
    }

    private void UpdateLeadAndHighestScore()
    {
        _leadScore= Math.Abs(_playerOne.Score - _playerTwo.Score);
        _highestScore = Math.Max(_playerOne.Score, _playerTwo.Score);
    }

    private void CheckGameOver()
    {
        _isGameOver = _leadScore >= 2 && _highestScore >= 4;
        if (_isGameOver) Console.WriteLine("Game Over.");
    }

    
    public string Score()
    {
        //1. 輸出必須為網球分數 例：1:0 => Fifteen Love 
        //2. 分數表達必須是文字例如Fifteen Forty 而非15：40 
        //3. 賽末點時 輸出為 Player Name Adv, 例：Sam Adv
        //4. 勝出時 輸出為 Player Name Win, 例：Sam Win
        
        // code smell: magic number
        // 應有個 變數/方法 提升閱讀性: 以抽象命名替代實作細節
        // 如果是 leadScore >= 2 而不是 leadScore == 2，閱讀者會推測 2 以上用在哪，不明確
        // 4:1 或 4:0 時用 leadScore == 2 會漏檢核，應使用 leadScore >= 2
        if(!_isNeedUpdateScoreName) return _currentScoreNameOfPlayers;
        
        var isWin = _highestScore >= 4 && _leadScore >= 2;
        if (isWin) UpdateScoreNameWin();
        
        var isAdv = _highestScore >= 4 && _leadScore == 1;
        if (isAdv) UpdateScoreNameAdv();
        
        var isDeuce = _highestScore >= 3 && _leadScore == 0;
        if (isDeuce) UpdateScoreNameDeuce();
        
        var isAll = _highestScore <= 2 && _leadScore == 0;
        if (isAll) UpdateScoreNameAll();
        
        var isOnlyScore = _highestScore <= 2 && _leadScore != 0;
        if (isOnlyScore) UpdateScoreNameOnlyScore();

        _isNeedUpdateScoreName = false;
        
        return _currentScoreNameOfPlayers;
    }

    private void UpdateScoreNameOnlyScore()
    {
        var playerOneScoreName = EnumHelper.GetScoreName(_playerOne.Score);
        var playerTwoScoreName = EnumHelper.GetScoreName(_playerTwo.Score);
        
        _currentScoreNameOfPlayers = playerOneScoreName == null && playerTwoScoreName == null
            ? "ScoreName is Null, Please Check Values"
            : $"{playerOneScoreName} {playerTwoScoreName}.";
    }

    private void UpdateScoreNameAll()
    {
        var scoreNameOfScoreEqual = EnumHelper.GetScoreName(_highestScore);
        
        _currentScoreNameOfPlayers = scoreNameOfScoreEqual == null
            ? "ScoreName is Null, Please Check Values"
            : $"{scoreNameOfScoreEqual} {ScoreStatus.All}.";
    }

    private void UpdateScoreNameDeuce()
    {
        _currentScoreNameOfPlayers = $"{ScoreStatus.Deuce}.";
    }

    private void UpdateScoreNameAdv()
    {
        var leadPlayer = _playerOne.Score > _playerTwo.Score ? _playerOne : _playerTwo;
        
        _currentScoreNameOfPlayers = $"{leadPlayer.Name} {ScoreStatus.Adv}.";
    }

    private void UpdateScoreNameWin()
    {
        var leadPlayer = _playerOne.Score > _playerTwo.Score ? _playerOne : _playerTwo;
        
        _currentScoreNameOfPlayers = $"{leadPlayer.Name} {ScoreStatus.Win}.";
    }
}