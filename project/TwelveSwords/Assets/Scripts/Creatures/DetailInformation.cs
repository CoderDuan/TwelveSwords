using System.Collections.Generic;

public class DetailInformation 
{
	public int max_hp;
	public int max_mp;
	public int cur_hp;
	public int cur_mp;

	public int final_atk;
	public int final_mag;

	public float do_damage_total = 1.0f;	
	public float do_damage_magical = 1.0f;
	public float do_damage_physical = 1.0f;

	public float take_damage_total = 1.0f;
	public float take_damage_magical = 1.0f;
	public float take_damage_physical = 1.0f;

	public float cost_coefficient = 1.0f;

	public float heal_coefficient = 1.0f;

	public DetailInformation() {}
}
