public enum BuffType : int
{
    BURNING = 0, 
    BLEEDING,   
    POISIONED,
    RECOVERY,
    PARALYTIC, // 麻痹
    FROZEN,
    EMBRAVE, // 鼓舞
    ARMORDOWN, // 破甲
    INSPIRE, // 激励
    STUN,
    UNARMED, // 缴械
    SILENCE,
    BLIND,
    DESTROY,
    IMMUNE, // 免疫
    CURSE,  // 诅咒
    BRAND,  // 烙印
    SHIELD,
    DIRECT // 用来返回直接伤害值
}

public class Buff
{
    public bool accumulateable;
    public bool isPositive;
    public BuffType type;
    public int turn;
    public int extraValue; // may be used in burning and bleeding
    public string name;
    public string description;
    
    public void apply(Creature creature)
    {

    }
}