public enum BuffType : uint
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
    SHIELD
}

public class Buff
{
    public bool accumulateable;
    public bool isPositive;
    public BuffType type;
    public int turn;
    public int extraValue; // may be used in burning and bleeding
    
    public void apply(Creature creature)
    {

    }
}