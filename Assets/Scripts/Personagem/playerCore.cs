using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerCore : MagicSystem
{
    #region Variaveis
    [Header("Atributos do Player")]
    [SerializeField] private int speed = 20;
    [SerializeField] private int life = 20;
    [SerializeField] private int maxLife = 50;
    [SerializeField] private int mana;
    [SerializeField] private int manaMax;

    [Header("Player Components")]
    [SerializeField] private GameObject OpenInventory;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private CapsuleCollider col;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody rbPlayer;
    [SerializeField] private Transform frontCheck; //Checa colisões com paredes

    [Header("Player Movement Variables")]
    [SerializeField] private float jumpForce = 20;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float lowJumpMultiplier;
    [SerializeField] private float originalHeight;
    [SerializeField] private float reducedHeight;
    [SerializeField] private float slideSpeed;
    [SerializeField] private float originalSlideSpeed;
    [SerializeField] private bool isSliding;
    [SerializeField] private bool closeInventory;
    [SerializeField] private bool touchingWall;
    [SerializeField] private bool wallSlideable;
    [SerializeField] private float wallSlideSpeed;


    [Header("Images")]
    [SerializeField] private Image _lifeBarImage;
    [SerializeField] private Image _manaBarImage;




    #endregion
    void awake()
    {
        this.life = 50;
        this.maxLife = 50;
        this.mana = 20;
        this.manaMax = 50;
        this.fallMultiplier = 2.5f;
        this.lowJumpMultiplier = 2f;
        this.rbPlayer = this.GetComponent<Rigidbody>();
        this.col = this.GetComponent<CapsuleCollider>();
        this.playerTransform = this.GetComponent<Transform>();
        this.originalHeight = col.height;
        this.closeInventory = false;
        //Mudanças
        slideSpeed =7f;
        originalSlideSpeed = slideSpeed;


    }
    // playerCore => playerController
    //Core = trata as informações
    //Controller => Core = trata elasa;
    //(Controller) => Movimentações
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        bool slide = Input.GetKey(KeyCode.LeftControl);
        move(moveH, moveV);
        BetterJump();


        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isSliding = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isSliding = false;
            getUp();
        }
        if (isSliding && IsGrounded())
        {
            Slide();
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Pulo();
        }


        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory();
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
        rbPlayer.velocity = Vector3.up * jumpForce;
    }

    void BetterJump()
    {
        if (rbPlayer.velocity.y < 0)
        {
            rbPlayer.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rbPlayer.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rbPlayer.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void Slide()
    {
        col.height = reducedHeight;
        if (playerTransform.rotation.eulerAngles.y == 180 && isSliding) // virado pra esquerda
        {
            col.center = new Vector3(0, -0.5f, 0);
            rbPlayer.AddForce(new Vector3(-1, 0, 0) * slideSpeed, ForceMode.Impulse);
            slideSpeed -= 4.5f * Time.deltaTime;
            if (slideSpeed <= 0)
            {
                slideSpeed = 0;
            }
        }
        else if (playerTransform.rotation.eulerAngles.y == 0 && isSliding)
        {
            col.center = new Vector3(0, -0.5f, 0);
            rbPlayer.AddForce(new Vector3(1, 0, 0) * slideSpeed, ForceMode.Impulse);

            slideSpeed -= 4.5f * Time.deltaTime;
            if (slideSpeed <= 0)
            {
                slideSpeed = 0;
            }
        }

    }
    void getUp()
    {
        col.center = new Vector3(0, 0, 0);
        col.height = originalHeight;
        slideSpeed = originalSlideSpeed;
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
            col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }



    #endregion
    #region Controlador_De_Vida
    public int GetHealth() => this.life;
    public void SetHealth(int _life)
    {
        if (_life > maxLife)
        {
            this.life = maxLife;
        }
        else
        {
            this.life = _life;
        }

        UpdateLifeBar();

        if (this.life <= 0)
        {
            DeathController();
        }
    }
    public void AddHealth(int lifeIncrement) => this.SetHealth(this.life + lifeIncrement);
    public void RemoveHealth(int lifeIncrement) => this.SetHealth(this.life - lifeIncrement);
    public void UpdateLifeBar() => this._lifeBarImage.fillAmount = ((1.0f / this.maxLife) * this.life);
    public void DeathController()
    {
        Destroy(gameObject);
    }
    #endregion
    #region ManaController
    public int GetMana() => this.mana;
    public void SetMana(int manaAmount)
    {
        if (manaAmount > manaMax)
        {
            this.mana = manaMax;
        }
        else
        {
            this.mana = manaAmount;
        }
        UpdateManaBar();

        if (this.mana <= 0)
        {

        }

    }
    public void IncrementManaMax(int manaIncrement) => this.manaMax += manaIncrement;
    public void UpdateManaBar() => this._manaBarImage.fillAmount = ((1.0f / this.manaMax) * this.mana);


    #endregion
    #region Colliders_And_Triggers
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Inimigo")
        {
            RemoveHealth(2);
        }
        if (other.gameObject.tag == "armadilhas")
        {
            SetHealth(2);
        }
        if (other.gameObject.tag == "limbo")
        {
            DeathController();
        }
    }
    void OnTriggerEnter(Collider other)
    {

    }

    #endregion
    #region Inventory
    public void Inventory()
    {
        if (closeInventory == false)
        {
            Debug.Log("Abrindo Inventario");
            closeInventory = true;
            OpenInventory.gameObject.SetActive(true);
        }
        else
        {
            closeInventory = false;
            Debug.Log("Fechando Inventario");
            OpenInventory.gameObject.SetActive(false);
        }
    }
    #endregion

}
