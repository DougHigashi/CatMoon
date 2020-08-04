using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : InventoryInterface
{
    public int GetInventoryID()
    {
        return 0;
    }
    public int GetInventorySlots()
    {
        return 12;
    }
    public int GetInventoryMaxSlots()
    {
        return 50;
    }

}