using System.Collections;

public enum SkillType : int
{
    PHYSICAL = 0,
    MAGICAL = 1
}

abstract public class Skill
{
    public SkillType type;
    public int cost;
    public int proficient;
    public int constant;
    public string name;
    public string description;

    public bool isLocked;

    public abstract void init();

    public abstract float[] getProbability(int dice1);

    public abstract ArrayList apply(Creature from, Creature to, int dice1, int dice2);
}