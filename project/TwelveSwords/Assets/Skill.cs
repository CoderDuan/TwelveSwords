using System.Collections;

public enum SkillType : int
{
    PHYSICAL = 0,
    MAGICAL = 1
}

public enum SkillLevel : int
{
    PRIMARY = 0,
    ADVANCED,
    LEGENDARY
}

public enum SkillUsable : int
{
    UNIVERSAL = 0,
    MELANIZATION_ONLY,
    NORMAL_ONLY
}

abstract public class Skill
{
    public SkillType type;
    public SkillLevel level;
    public SkillUsable usable;
    public int cost;
    public int proficient;
    public int maxProficient;
    public int constant;
    public string name;
    public string description;

    public bool isLocked;

    public abstract void init();

    public abstract float[] getProbability(int dice1);

    public abstract int apply(Creature from, Creature to, int dice1, int dice2);
}