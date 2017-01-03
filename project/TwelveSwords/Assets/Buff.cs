public enum BuffType : int
{
    DAMAGE_UP = 0,
    DAMAGE_DOWN,
    BLEEDING
}

public class Buff
{
    public bool accumulateable;
    public BuffType type;
    public int turn;
    public int extraValue; // may be used in burning and bleeding
    public string uniqueName;
    public string description;
}