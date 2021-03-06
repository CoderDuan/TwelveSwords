﻿using System.Collections;

public enum SkillType
{
    PHYSICAL = 0,
    MAGICAL,
	RECOVERY,
	MULTIPLE,
	// special
	UNCOUNTERABLE
};

public enum SkillLevel : int
{
    PRIMARY = 0,
    ADVANCED,
	MASTER,
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
	public SkillType type;
    public SkillLevel level;
    public SkillUsable usable;
    public int cost;
    public int proficient;
    public int maxProficient;
    public int constant;
    public string name;
    public string description;

    public string skillId;
	public string preparePath;

    // other display information
	public string damageFormula;
	public string[] proficientName = null;
	public string[] proficientEffect = null;
	public string[] proficientCondition = null;

    public bool isLocked;

	public abstract float[] getProbability(int dice1);

	public abstract SkillEffectResponse apply(Creature from, int dice1, int dice2);
}