public enum SkillType : int
{
    PHYSICAL = 0,
    MAGIC = 1
}

abstract public class Skill
{
    public SkillType type;
    public int cost;
    public int proficient;
    public int constant;

    public virtual void init();

    public virtual float[] getProbability(int dice1);

    public virtual void apply(Creature from, Creature to, int dice1, int dice2);
}