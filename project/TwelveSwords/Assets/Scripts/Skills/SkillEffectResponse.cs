// 用来记录技能释放到目标身上后，造成的所有效果
// 其中有一部分是专门用来显示的信息
// 在 skill.apply 中创建
// 在 skill.apply, creature.takeDamagePrimary 和 creature.takeDamge 中修改

using System.Collections.Generic;
//using UnityEngine;

// 技能应用后的返回结构体
public class SkillEffectResponse  {

	public List<int> proficient = null; // 记录触发了哪些精通（精通的index）
	public List<SingleEffectResponse> effects = null;

    public SkillEffectResponse() { }
}