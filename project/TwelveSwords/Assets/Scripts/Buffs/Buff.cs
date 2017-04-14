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
	//public string buffId;

	// buffid 
	// 减宜效果： -2 ~ -MAX  -1：任意减宜
	// 增益效果： 2 ~ MAX  1：任意增益
	// 0 ： 任意buff
	public int buffid;

    public Buff() { }

    public void effect(Creature creature) { }
}