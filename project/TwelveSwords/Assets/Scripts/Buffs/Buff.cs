public enum BuffType : int
{
	APPLY_DAMAGE = 0,
	APPLY_MAGICAL,
	APPLY_PHYSICAL,
	TAKE_DAMAGE,
	TAKE_MAGICAL,
	TAKE_PHYSICAL,
	CHANGE_HP,
	CHANGE_MP,
//    DAMAGE_INCREMENT = 0,
//    DAMAGE_REDUCTION,
//    BLEEDING,
//    HEALING
}

public enum BuffEffectMode : int
{
	MODE_DELAY = 0,
	MODE_INSTANT
}

public abstract class Buff
{
    public bool unique;
	public bool accumulative;
    public BuffType type;
	public BuffEffectMode mode;
    public int turn;
    public float extraValue; 
    public string name;
    public string description;
	//public string buffId;

	// buffid 
	// 减宜效果： -2 ~ -MAX  -1：任意减宜
	// 增益效果： 2 ~ MAX  1：任意增益
	// 0 ： 任意buff
	public int buffid;

    public Buff() { }

	public abstract void takeEffect (Creature target);
}