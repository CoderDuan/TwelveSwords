public enum SkillType : int
{
    PHYSICAL = 0,
    MAGICAL = 1
}

public class Skill
{
    public SkillType type;
    public uint cost;
    public uint proficient;
    public uint coefficient;
    public uint constant;

    public virtual float[] getProbability(uint dice1)
    {
        float [] ret = new float[] {0.0f,0.0f,0.0f,0.0f};

        return ret;
    }

    public virtual void apply(Creature from, Creature to, uint dice1, uint dice2)
    {

    }
}