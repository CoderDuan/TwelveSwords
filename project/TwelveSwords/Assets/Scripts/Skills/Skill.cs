using System.Collections;

public enum DamageType
{
    PHYSICAL = 0,
    MAGICAL
};

public enum SkillLevel : int
{
    PRIMARY = 0,
    ADVANCED,
    LEGENDARY
};

public enum SkillUsable : int
{
    UNIVERSAL = 0,
    MELANIZATION_ONLY,
    NORMAL_ONLY
};

abstract public class Skill
{
    public DamageType type;
    public SkillLevel level;
    public SkillUsable usable;
    public int cost;
    public int proficient;
    public int maxProficient;
    public int constant;
    public string name;
    public string description;

    public string skillId;

    // other display information
	public string damageFormula;
	public string[] proficientName = new string[3];
    public string[] proficientInformation = new string[3];

    public bool isLocked;

	public abstract float[] getProbability(int dice1);

	public abstract SkillEffectResponse apply(Creature from, Creature to, int dice1, int dice2);
}