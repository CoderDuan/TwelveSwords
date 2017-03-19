using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPair
{
    public GameObject visualBuff;
    public Buff buff;

    public BuffPair(GameObject vb, Buff b)
    {
        visualBuff = vb;
        buff = b;
    }
}

public class BuffManager 
{
    public List<BuffPair> buffList;
    private const int _MAX = 20;

    public BuffManager()
    {
        buffList = new List<BuffPair>();
    }

    public void addOne(BuffPair bp)
    {
        int size = buffList.Count;
        if (size >= _MAX) return;
        buffList.Add(bp);
    }

    public void countBuff()
    {
        int size = buffList.Count;
        for (int i=size-1;i>=0;i--)
        {
            buffList[i].buff.turn--;
            if (buffList[i].buff.turn == 0)
            {
                Object.Destroy(buffList[i].visualBuff);
                buffList.RemoveAt(i);
            }
            // visual buff count --
        }
    }

    public void updateDamageEffect(Creature creature)
    {
        int size = buffList.Count;
        float damage_increment = 0.0f;
        float damage_reduction = 1.0f;
        for (int i=0;i<size;i++)
        {
            if (buffList[i].buff.type == BuffType.DAMAGE_INCREMENT)
            {
                damage_increment += buffList[i].buff.extraValue;
            }
            else if (buffList[i].buff.type == BuffType.DAMAGE_REDUCTION)
            {
                damage_reduction *= (1.0f - buffList[i].buff.extraValue);
            }
        }
        creature.damage_increment = damage_increment;
        creature.damage_reduction = damage_reduction;
    }

    public void updateBuffList(SkillEffectResponse response)
    {

    }
}
