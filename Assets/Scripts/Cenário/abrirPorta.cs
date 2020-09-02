using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPorta : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject porta;
    Animator anim;

    void Start()
    {
        anim = porta.GetComponent<Animator>();
        

    }
    void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E)){
            anim.SetTrigger("OpenCloseDoor");
        }
    }
}
