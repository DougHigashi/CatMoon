using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
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
	[SerializeField] private Transform playerTransform;
	[SerializeField] private Rigidbody rbPlayer;
	[SerializeField] private float originalHeight; 
	[SerializeField] private float reducedHeight;
	[SerializeField] private float slideSpeed;
	[SerializeField] private float originalSlideSpeed;
	[SerializeField] private bool isSliding;
	[SerializeField] private bool TouchingWall;
	[SerializeField] private Transform playerTransform;
	[SerializeField] private Rigidbody rbPlayer;
	[SerializeField] private float originalHeight; 
	[SerializeField] private float reducedHeight;
	[SerializeField] private float slideSpeed = 7f;
	[SerializeField] private bool isSliding;

	#endregion

	void start()
	{
		rbPlayer = GetComponent<Rigidbody>();
		col = GetComponent<CapsuleCollider>();

		playerTransform = GetComponent<Transform>();
		originalHeight = col.height;
		originalSlideSpeed = slideSpeed;

		playerTransform = GetComponent<Transform>();
		originalHeight = col.height;

	}

	void Update()
	{
		float moveH = Input.GetAxis("Horizontal");
		float moveV = Input.GetAxis("Vertical");
		bool slide = Input.GetKey(KeyCode.LeftControl);
		move(moveH, moveV);


		if(Input.GetKeyDown(KeyCode.LeftControl))
        {
			isSliding = true;
        }
		else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
			isSliding = false;
			GetUp();

			getUp();
        }
		if(isSliding && IsGrounded())
        {
			Slide();
        }

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


	void Slide()
    {
		col.height = reducedHeight;
		if(playerTransform.rotation.eulerAngles.y == 180 && isSliding) // virado pra esquerda
		{
			col.center = new Vector3(0, -0.5f, 0);
			rbPlayer.AddForce(new Vector3(-1, 0, 0) * slideSpeed, ForceMode.Impulse);
			slideSpeed -= 4.5f * Time.deltaTime;
			if (slideSpeed <= 0)
			{
				slideSpeed = 0;
			}
		}

        }
		else if(playerTransform.rotation.eulerAngles.y == 0 && isSliding)
        {
			col.center = new Vector3(0, -0.5f, 0);
			rbPlayer.AddForce(new Vector3(1, 0, 0) * slideSpeed, ForceMode.Impulse);

			slideSpeed -= 4.5f * Time.deltaTime;
			if(slideSpeed <= 0)
            {
				slideSpeed = 0;
            }
		}

	}
	void GetUp()
    {
		col.center = new Vector3(0, 0, 0);
		col.height = originalHeight;
		slideSpeed = originalSlideSpeed;
    }

		}

	}
	void getUp()
    {
		col.center = new Vector3(0, 0, 0);
		col.height = originalHeight;
    }

	private bool IsGrounded()
    {
		return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
			col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }


		void OnCollisionStay(Collision collisionInfo)
		{
			if(!IsGrounded())
            {
				if(Input.GetKeyDown(KeyCode.Space))
                {
					Debug.Log("WALLJUMP");
                }
            }
			
	}

	



	/*
	void OnCollisionStay(Collision collisionInfo)
	{
		if(collisionInfo.collider.tag == "Wall" && !IsGrounded())
        {
			if(Input.GetKeyDown(KeyCode.Space))
			{
				rbPlayer.AddForce(new Vector3(10, 1, 0) * jumpForce, ForceMode.Impulse);
				Debug.Log("WALLJUMP");
			}

        }
	}

	*/



    #endregion
    #region Metodos
    public void InventoryOpen(){
		
	}
	#endregion

}	
