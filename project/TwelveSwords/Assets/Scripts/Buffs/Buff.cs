public enum BuffType : int
{
    DAMAGE_INCREMENT = 0,
    DAMAGE_REDUCTION,
    BLEEDING,
    HEALING
}

public class Buff
{
    public bool accumulateable;
    public BuffType type;
    public int turn;
    public int extraValue; 
    public string name;
    public string description;
	public string buffId;

    public Buff() { }

    public void effect(Creature creature) { }
}