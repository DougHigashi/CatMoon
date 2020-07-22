using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicFire : Magic, DamageMultiply
{
    public int getID()
    {
        return 1;
    }
    public string getName()
    {
        return "Invocação do BURNNN";
    }
    public long getCooldown()
    {
        return 25000;
        //cooldown 25 s
    }
    public double getDamageMultiply()
    {
        return 1.5;
    }
    public int getBaseDamage(){
        return 15;
    }
}