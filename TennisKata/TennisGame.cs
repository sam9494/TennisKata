namespace TennisKata;

public class TennisGame
{
    private readonly Player _server;
    private readonly Player _receiver;

    public TennisGame(Player server, Player receiver)
    {
        _server = server;
        _receiver = receiver;
    }
    public string Score()
    {
        //1. 輸出必須為網球分數 例：1:0 => Fifteen Love 
        //2. 分數表達必須是文字例如Fifteen Forty 而非15：40 
        //3. 賽末點時 輸出為 Player Name Adv, 例：Sam Adv
        //4. 勝出時 輸出為 Player Name Win, 例：Sam Win
        return "Love All";
    }

    public void PlayerOneScore()
    {
        _server.Score++;
    }
    
    public void PlayerTwoScore()
    {
        _receiver.Score++; 
    }

}