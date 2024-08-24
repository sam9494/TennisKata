namespace TennisKata;

public class EnumHelper
{
    public static ScoreName? GetScoreName(int score)
    {
        ScoreName? scoreName = score switch
        {
            3 => ScoreName.Forty,
            2 => ScoreName.Thirty,
            1 => ScoreName.Fifteen,
            0 => ScoreName.Love,
            _ => null
        };
        return scoreName;
    }
}