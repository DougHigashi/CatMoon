using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSnow : Magic
{

    public int getID()
    {
        return 0;
    }
    public string getName()
    {
        return "Invocação do Polo Norte";
    }
    public long getCooldown()
    {
        return 35000;
    }

    public double getDamageMultiplier()
    {
        return 2.0;
    }
}