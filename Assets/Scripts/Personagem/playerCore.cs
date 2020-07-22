using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCore : MonoBehaviour
{
	#region Variaveis
	[SerializeField] private int speed = 20;
	[SerializeField] private int life;
	[SerializeField] private int maxLife;
	[SerializeField] private int mana;
	[SerializeField] private GameObject OpenInventory;
	[SerializeField] private float jumpForce = 20;
	[SerializeField] private LayerMask groundLayers;
	[SerializeField] private CapsuleCollider col;

	private Rigidbody rbPlayer;
	#endregion


	void Start()
	{
		rbPlayer = GetComponent<Rigidbody>();
		col = GetComponent<CapsuleCollider>();
	}

	void Update()
	{
		float moveH = Input.GetAxis("Horizontal");
		float moveV = Input.GetAxis("Vertical");
		move(moveH, moveV);

		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
			Pulo();
        }
	}

	#region Movimentacao
	//movimentação;
	public void move(float moveH, float moveV)
	{
		Vector3 novaVel = Vector3.right * moveH * speed;
		if (moveH < 0 && transform.rotation.eulerAngles.y != 180)
		{
			Vector3 newRot = new Vector3(0, 180, 0);
			transform.rotation = Quaternion.Euler(newRot);
		}
		if (moveH > 0 && transform.rotation.eulerAngles.y != 0)
		{
			Vector3 newRot = new Vector3(0, 0, 0);
			transform.rotation = Quaternion.Euler(newRot);
		}

		novaVel.y = rbPlayer.velocity.y;
		rbPlayer.velocity = novaVel;
	}
    #endregion

    #region Pulo
	void Pulo()
    {
		rbPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

	private bool IsGrounded()
    {
		return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
			col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }

    #endregion
    #region Metodos
    public void InventoryOpen(){
		
	}
	#endregion

}	
