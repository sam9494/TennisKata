namespace TennisKata;

public class Tennis
{
    private readonly Player _playerOne;
    private readonly Player _playerTwo;
    private readonly Scorer _scorer;

    public Tennis(string playerOneName, string playerTwoName)
    {
        _playerOne = new Player(playerOneName);
        _playerTwo = new Player(playerTwoName);
        _scorer = new Scorer();
    }

    public void PlayerOneScore()
    {
        _scorer.AddPlayerScore(_playerOne, _playerTwo);
        Console.WriteLine(Score());
    }
    
    public void PlayerTwoScore()
    {
        _scorer.AddPlayerScore(_playerTwo, _playerOne);
        Console.WriteLine(Score());
    }
    public string Score()
    {
        //1. 輸出必須為網球分數 例：1:0 => Fifteen Love 
        //2. 分數表達必須是文字例如Fifteen Forty 而非15：40 
        //3. 賽末點時 輸出為 Player Name Adv, 例：Sam Adv
        //4. 勝出時 輸出為 Player Name Win, 例：Sam Win
        return "Love All";
    }
}