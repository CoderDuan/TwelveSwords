using System.Collections.Generic;
using UnityEngine;

public class CounterEffectResponse  {
	// 技能对自己（含负数）
	public List<int> self_hp_change = null; // 记录每段对自己血量的变化
	public List<int> self_hp = null; // 记录每段血量变化后的血量
	public List<int> self_mp_change = null; // 记录每段对自己蓝量的变化
	public List<int> self_mp = null; // 记录每段蓝量变化后的蓝量

	// 技能对对手（含负数）
	public List<int> opponent_hp_change = null; // 记录每段对对手血量的变化
	public List<int> opponent_hp = null; // 记录每段血量变化后的血量
	public List<int> opponent_mp_change = null; // 记录每段对对手蓝量的变化
	public List<int> opponent_mp = null; // 记录每段蓝量变化后的蓝量

	public CounterEffectResponse() {}
}
