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
<<<<<<< HEAD
<<<<<<< Updated upstream

	private Rigidbody rbPlayer;
=======
	[SerializeField] private Transform playerTransform;
	[SerializeField] private Rigidbody rbPlayer;
	[SerializeField] private float originalHeight; 
	[SerializeField] private float reducedHeight;
	[SerializeField] private float slideSpeed;
	[SerializeField] private float originalSlideSpeed;
	[SerializeField] private bool isSliding;
	[SerializeField] private bool TouchingWall;
>>>>>>> Stashed changes
=======
	[SerializeField] private Transform playerTransform;
	[SerializeField] private Rigidbody rbPlayer;
	[SerializeField] private float originalHeight; 
	[SerializeField] private float reducedHeight;
	[SerializeField] private float slideSpeed = 7f;
	[SerializeField] private bool isSliding;

>>>>>>> master
	#endregion

	void start()
	{
		rbPlayer = GetComponent<Rigidbody>();
		col = GetComponent<CapsuleCollider>();
<<<<<<< HEAD
<<<<<<< Updated upstream
=======
		playerTransform = GetComponent<Transform>();
		originalHeight = col.height;
		originalSlideSpeed = slideSpeed;
>>>>>>> Stashed changes
=======
		playerTransform = GetComponent<Transform>();
		originalHeight = col.height;
>>>>>>> master
	}

	void Update()
	{
		float moveH = Input.GetAxis("Horizontal");
		float moveV = Input.GetAxis("Vertical");
		bool slide = Input.GetKey(KeyCode.LeftControl);
		move(moveH, moveV);

<<<<<<< HEAD
<<<<<<< Updated upstream
=======
=======
>>>>>>> master

		if(Input.GetKeyDown(KeyCode.LeftControl))
        {
			isSliding = true;
        }
		else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
			isSliding = false;
<<<<<<< HEAD
			GetUp();
=======
			getUp();
>>>>>>> master
        }
		if(isSliding && IsGrounded())
        {
			Slide();
        }

<<<<<<< HEAD
>>>>>>> Stashed changes
=======
>>>>>>> master
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

<<<<<<< HEAD
<<<<<<< Updated upstream
=======
=======
>>>>>>> master
	void Slide()
    {
		col.height = reducedHeight;
		if(playerTransform.rotation.eulerAngles.y == 180 && isSliding) // virado pra esquerda
		{
			col.center = new Vector3(0, -0.5f, 0);
			rbPlayer.AddForce(new Vector3(-1, 0, 0) * slideSpeed, ForceMode.Impulse);
<<<<<<< HEAD
			slideSpeed -= 4.5f * Time.deltaTime;
			if (slideSpeed <= 0)
			{
				slideSpeed = 0;
			}
		}
=======
        }
>>>>>>> master
		else if(playerTransform.rotation.eulerAngles.y == 0 && isSliding)
        {
			col.center = new Vector3(0, -0.5f, 0);
			rbPlayer.AddForce(new Vector3(1, 0, 0) * slideSpeed, ForceMode.Impulse);
<<<<<<< HEAD
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

>>>>>>> Stashed changes
=======
		}

	}
	void getUp()
    {
		col.center = new Vector3(0, 0, 0);
		col.height = originalHeight;
    }

>>>>>>> master
	private bool IsGrounded()
    {
		return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
			col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }

<<<<<<< HEAD
<<<<<<< Updated upstream
=======

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

	


=======
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
>>>>>>> master





<<<<<<< HEAD
>>>>>>> Stashed changes
=======
>>>>>>> master
    #endregion
    #region Metodos
    public void InventoryOpen(){
		
	}
	#endregion

}	
