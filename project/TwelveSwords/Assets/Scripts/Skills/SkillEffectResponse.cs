// 用来记录技能释放到目标身上后，造成的所有效果
// 其中有一部分是专门用来显示的信息
// 在 skill.apply 中创建
// 在 skill.apply, creature.takeDamagePrimary 和 creature.takeDamge 中修改

using System.Collections.Generic;
 
public class SkillEffectResponse  {
    public DamageType type;	// 记录伤害类型
	public List<bool> proficient = null; // 记录触发的技能精通
	public List<int> hp = null;	// 记录每段伤害后，剩余的血量
    public List<int> damage = null;	// 记录每段伤害
    public List<int> healing = null; // 记录每段治疗量（对自己）
    public List<int> mana = null; // 记录每段耗蓝量（对自己）
	public List<int> remana = null; // 记录每段回蓝量（对自己）
	public List<int> hpcost = null; // 记录每段耗血量（对自己）
	//public List<Buff> remove_self_buff = null; // 记录从自己身上移除的buff
	public List<Buff> add_self_buff = null; // 记录给自己上的buff
    //public List<Buff> remove_opp_buff = null; // 记录从对手身上移除的buff
    public List<Buff> add_opp_buff = null; // 记录给对手上的buff

	// 记录反击
	public List<int> counterattack = null; // 记录每段的反击伤害
	// 记录反伤
	public List<int> counterDamage = null; // 记录受到的每段反伤伤害
	// 反击和反伤的血量都记录在这里
	public List<int> counterhp = null; // 记录受到每段反击后，剩余的血量

    public SkillEffectResponse() { }
}
