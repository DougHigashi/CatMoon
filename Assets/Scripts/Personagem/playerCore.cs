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

	private Rigidbody rbPlayer;
	#endregion


	void Start()
	{
		rbPlayer = GetComponent<Rigidbody>();
	}

	void Update()
	{
		float moveH = Input.GetAxis("Horizontal");
		float moveV = Input.GetAxis("Vertical");
		move(moveH, moveV);
	}

	#region Movimentacao
	//movimentação;
	public void move(float moveH, float moveV)
	{
		Vector3 novaVel = Vector3.right * moveH * speed;
		if (moveH < 0 && transform.rotation.eulerAngles.y != 270)
		{
			Vector3 newRot = new Vector3(0, 270, 0);
			transform.rotation = Quaternion.Euler(newRot);
		}
		if (moveH > 0 && transform.rotation.eulerAngles.y != 90)
		{
			Vector3 newRot = new Vector3(0, 90, 0);
			transform.rotation = Quaternion.Euler(newRot);
		}

		novaVel.y = rbPlayer.velocity.y;
		rbPlayer.velocity = novaVel;
	}
	#endregion
}
