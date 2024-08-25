using TennisKata.Helper;

namespace TennisKata;

public class Tennis
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;
    private int _leadScore;
    private int _highestScore;

    public Tennis(string playerOneName, string playerTwoName)
    {
        _playerOne = new Player(playerOneName);
        _playerTwo = new Player(playerTwoName);
        _leadScore = 0;
        _highestScore = 0;
    }

    public void PlayerOneScore()
    {
        var isGameOver = CheckGameOver();
        if (isGameOver) return;
        _playerOne.Score++;
        UpdateLeadAndHightestScore();
    }
    
    public void PlayerTwoScore()
    {
        var isGameOver = CheckGameOver();
        if(isGameOver) return;
        _playerTwo.Score++;
        UpdateLeadAndHightestScore();
    }

    private void UpdateLeadAndHightestScore()
    {
        _leadScore= Math.Abs(_playerOne.Score - _playerTwo.Score);
        _highestScore = Math.Max(_playerOne.Score, _playerTwo.Score);
    }

    private bool CheckGameOver()
    {
        var isGameOver = _leadScore >= 2 && _highestScore >= 4;
        if (isGameOver) Console.WriteLine("Game Over.");
        return isGameOver;
    }

    
    public string Score()
    {
        //1. 輸出必須為網球分數 例：1:0 => Fifteen Love 
        //2. 分數表達必須是文字例如Fifteen Forty 而非15：40 
        //3. 賽末點時 輸出為 Player Name Adv, 例：Sam Adv
        //4. 勝出時 輸出為 Player Name Win, 例：Sam Win
        
        // code small: magic number
        // 應有個 變數/方法 提升閱讀性，以抽象命名替代實作細節
        // 如果是 leadScore >= 2 而不是 leadScore == 2，閱讀者會推測 2 以上用在哪，不明確

        var currentScoreNameOfPlayers ="";

        var isWin = _highestScore >= 4 && _leadScore == 2;
        if (isWin)
        {
            var leadPlayer = _playerOne.Score > _playerTwo.Score ? _playerOne : _playerTwo;
            currentScoreNameOfPlayers = $"{leadPlayer.Name} {LeadStatus.Win}.";
        }
        
        var isAdv = _highestScore >= 4 && _leadScore == 1;
        if (isAdv)
        {
            var leadPlayer = _playerOne.Score > _playerTwo.Score ? _playerOne : _playerTwo;
            currentScoreNameOfPlayers = $"{leadPlayer.Name} {LeadStatus.Adv}.";
        }
        
        
        var isDeuce = _highestScore >= 3 && _leadScore == 0;
        if (isDeuce) currentScoreNameOfPlayers = $"{LeadStatus.Deuce}.";
        
        
        var isAll = _highestScore <= 2 && _leadScore == 0;
        if (isAll)
        {
            var scoreNameOfScoreEqual = EnumHelper.GetScoreName(_highestScore);
            currentScoreNameOfPlayers = scoreNameOfScoreEqual == null
                                        ? "ScoreName is Null, Please Check Values"
                                        : $"{scoreNameOfScoreEqual} all.";
        }
        
        var isOnlyScores = _highestScore <= 2 && _leadScore != 0;
        if (isOnlyScores)
        {
            var playerOneScoreName = EnumHelper.GetScoreName(_playerOne.Score);
            var playerTwoScoreName = EnumHelper.GetScoreName(_playerTwo.Score);
            currentScoreNameOfPlayers = playerOneScoreName == null && playerTwoScoreName == null
                                        ? "ScoreName is Null, Please Check Values"
                                        : $"{playerOneScoreName} {playerTwoScoreName}.";
        }

        return currentScoreNameOfPlayers;
    }
}