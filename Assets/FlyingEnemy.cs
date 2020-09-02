using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public playerCore thePlayer;

    public float moveSpeed;
    public float playerRange;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<playerCore>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
        transform.LookAt(thePlayer.transform);
    }
}
