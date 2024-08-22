namespace TennisKata;

public class Player(string name)
{
    public string Name { get; } = name;
    public int Score { get; set; } = 0;
    public override bool Equals(object? o)
    {
        if (o is Player player) return this.Name == player.Name;
        return false;
    }
}