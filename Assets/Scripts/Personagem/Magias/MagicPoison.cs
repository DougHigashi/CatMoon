using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPoison : Magic
{

    public int getID()
    {
        return 3;
    }
    public string getName()
    {
        return "Veneno pra todo lado";
    }
    public long getCooldown()
    {
        return 21500;
    }

    public double getDamageMultiplier()
    {
        return 2.2;
    }
}