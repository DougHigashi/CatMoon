using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public interface Magic {

    int getID();
    string getName();
    long getCooldown();
    
    // 1.000 - 1.500 - 1.250
    // 1000 - 1500 - 1250
    // 1.25 segundos entendi então o primeiro de tudo é criar a base em si pra depois definir oq fazer com ela ?
}