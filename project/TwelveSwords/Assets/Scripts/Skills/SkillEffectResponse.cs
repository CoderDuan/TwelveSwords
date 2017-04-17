// 用来记录技能释放到目标身上后，造成的所有效果
// 其中有一部分是专门用来显示的信息
// 在 skill.apply 中创建
// 在 skill.apply, creature.takeDamagePrimary 和 creature.takeDamge 中修改

using System.Collections.Generic;
//using UnityEngine;

// 技能应用后的返回结构体
// 指导UI该怎么画
// 实际效果在生成结构体时就已经应用了
// 对于buff，每次都会根据英雄或怪物对象刷新buff列表
public class SkillEffectResponse  {
//    public DamageType type;	// 记录伤害类型
//	public List<bool> proficient = null; // 记录触发的技能精通
//	public List<int> hp = null;	// 记录每段伤害后，剩余的血量
//    public List<int> damage = null;	// 记录每段伤害
//    public List<int> healing = null; // 记录每段治疗量（对自己）
//    public List<int> mana = null; // 记录每段耗蓝量（对自己）
//	public List<int> remana = null; // 记录每段回蓝量（对自己）
//	public List<int> hpcost = null; // 记录每段耗血量（对自己）
//	//public List<Buff> remove_self_buff = null; // 记录从自己身上移除的buff
//	public List<Buff> add_self_buff = null; // 记录给自己上的buff
//    //public List<Buff> remove_opp_buff = null; // 记录从对手身上移除的buff
//    public List<Buff> add_opp_buff = null; // 记录给对手上的buff
//
//	// 记录反击
//	public List<int> counterattack = null; // 记录每段的反击伤害
//	// 记录反伤
//	public List<int> counterDamage = null; // 记录受到的每段反伤伤害
//	// 反击和反伤的血量都记录在这里
//	public List<int> counterhp = null; // 记录受到每段反击后，剩余的血量

	//public SkillType type = SkillType.MAGICAL; // 记录技能类型，在UI上决定画什么
	//public Color color = Color.white;	// 决定涂什么颜色
	public List<int> proficient = null; // 记录触发了哪些精通（精通的index）
	public List<SingleEffectResponse> effects = null;

	// 技能对自己（含负数）
//	public List<int> self_hp_change = null; // 记录每段对自己血量的变化
//	public List<int> self_hp = null; // 记录每段血量变化后的血量
//	public List<int> self_mp_change = null; // 记录每段对自己蓝量的变化
//	public List<int> self_mp = null; // 记录每段蓝量变化后的蓝量

	// 技能对对手（含负数）
//	public List<int> opponent_hp_change = null; // 记录每段对对手血量的变化
//	public List<int> opponent_hp = null; // 记录每段血量变化后的血量
//	public List<int> opponent_mp_change = null; // 记录每段对对手蓝量的变化
//	public List<int> opponent_mp = null; // 记录每段蓝量变化后的蓝量

    public SkillEffectResponse() { }
}
//
//STATE_WAIT,
//
//STATE_DICE_1,
//STATE_SKILL,
//STATE_DICE_2,
//STATE_PROFICIENT,
//STATE_SKILL_ANI,
//STATE_EFFECT,
//STATE_COUNTER,
//STATE_COUNTER_EFFECT