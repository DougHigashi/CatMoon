using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSystem : MonoBehaviour
{

    // isso aqui representa a classe ?
    #region variaveis
    private Dictionary<int, Magic> magics;

    #endregion
    void Start()
    {
        List<Magic> MagicsConvert = new List<Magic>();
        MagicsConvert.Add(new MagicSnow());


        MagicsConvert.ForEach(key =>
        {
            magics.Add(key.getID(), key);
        });

        Magic magic = null;
        magics.TryGetValue(0, out magic);

        if (magic.getID() == 0)
        {
            MagicSnow snow = (MagicSnow)magic;

            snow.getDamageMultiplier();
        }

        if (magic is MagicFire)
        {
            MagicFire damaged = (MagicFire)magic;
            damaged.getDamageMultiply();
        }
    }
    //to aprendendo a usar list e interface mt legal
    /* private Dictionary<int, Item> inventory;

     public bool addItem(Item item)
     {
         int slots = 30;

         if (inventory.Count >= slots)
         {
             return false;
         }

         for (int i = 0; i < slots; i++){
             Item test = null;
             inventory.TryGetValue(i, out test);
             if (test == null){
                 inventory.Add(i, item);
                 break;
             }
         }
 //
         return true;
     }

     public bool setItem(int slot, Item item){

     }

     public Item GetItem(int slot){
         Item item = null;
         inventory.TryGetValue(slot, out item);
         return item;
     }*/
    //isso aconteceu muito no joguinho anterior se lembra, por isso to focando em aprender isso. uhum, esse semestre agora olha que legal.

}
