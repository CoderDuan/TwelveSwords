using System.Collections.Generic;

public class CounterEffectResponse
{
	public int self_hp_change = 0;
	public int self_mp_change = 0;

	public int opponent_hp_change = 0;
	public int opponent_mp_change = 0;

	public List<int> self_buff_on = null;
	public List<int> self_buff_off = null;
	public List<int> opponent_buff_on = null;
	public List<int> opponent_buff_off = null;

	public string name = "反击";

	public CounterEffectResponse() { }
}
