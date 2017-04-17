public class BuffAmplifyDamage : Buff 
{
	public BuffAmplifyDamage()
	{
		unique = true;
		type = BuffType.APPLY_DAMAGE;
		turn = 4;
		extraValue = 50;
		name = "Amplify Damage";
		description = "Amplify Damage by 50%";
		buffid = 2;
	}

	public override void takeEffect(Creature target)
	{
	}
}
