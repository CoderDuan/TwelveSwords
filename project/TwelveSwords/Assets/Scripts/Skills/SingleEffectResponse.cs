using System.Collections.Generic;

public class SingleEffectResponse
{
	public int self_hp_change = 0;
	//public int self_hp = 0;
	public int self_mp_change = 0;
	//public int self_mp = 0;

	public int opponent_hp_change = 0;
	//public int opponent_hp = 0;
	public int opponent_mp_change = 0;
	//public int opponent_mp = 0;

	public int stage = 0;
	public int total = 0;

	public SkillType type;

	public List<Buff> self_buff_on = null;
	public List<Buff> self_buff_off = null;
	public List<Buff> opponent_buff_on = null;
	public List<Buff> opponent_buff_off = null;

	public float delay = 0.0f;
	public string prefabPath;

	public SingleEffectResponse() { }

	public SingleEffectResponse(SingleEffectResponse a)
	{
		type = a.type;
		self_hp_change = a.self_hp_change;
		//self_hp = a.self_hp;
		self_mp_change = a.self_mp_change;
		//self_mp = a.self_mp;

		opponent_hp_change = a.opponent_hp_change;
		//opponent_hp = a.opponent_hp;
		opponent_mp_change = a.opponent_mp_change;
		//opponent_mp = a.opponent_mp;

		self_buff_on = a.self_buff_on;
		self_buff_off = a.self_buff_off;
		opponent_buff_on = a.opponent_buff_on;
		opponent_buff_off = a.opponent_buff_off;
		total = a.total;
		stage = a.stage + 1;
		delay = a.delay;
		prefabPath = a.prefabPath;
	}
}
