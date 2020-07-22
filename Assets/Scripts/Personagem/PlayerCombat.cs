using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{   
    //instacia o animator
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    
    
    public float attackrange = 0.5f;
    public int attackDamage = 40;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
		{
            MeleeAttack();
		}
    }

    void MeleeAttack()
	{   
        //Detecta o inimigo no alcance do ataque
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackrange, enemyLayers);
	    
        foreach(Collider enemy in hitEnemies)
		{
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            Debug.Log("Fatiei o " + enemy.name);
		}
    }

	private void OnDrawGizmosSelected()
	{
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackrange);
	}
}
