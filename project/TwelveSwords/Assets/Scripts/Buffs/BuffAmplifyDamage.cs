public class BuffAmplifyDamage : Buff 
{
	public BuffAmplifyDamage()
	{
		unique = true;
		accumulative = false;
		type = BuffType.APPLY_DAMAGE;
		mode = BuffEffectMode.MODE_INSTANT;
		turn = 4;
		extraValue = 0.5f;
		name = "伤害强化";
		description = "所有伤害增加 50%";
		buffid = 2;
	}

	public override void takeEffect(Creature target)
	{
		target.detail.do_damage_total += extraValue;
	}
}
