using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DeadEventHandler();
public class Player : Character
{
    public bool isCheckDie;
    private static  Player instance;

    [SerializeField]
    private Transform startPos;

    public event DeadEventHandler Dead;

    public int coin;

    public int heart;

    public int kunai = 20;


    [SerializeField]
    private TextMesh userName;

    public static  Player Instance
    {
        get { 
            if(instance==null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }
            return instance; 
        }
        set { instance = value; }
    }

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groudRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private float jumpForce;

    private bool immortal = false;

    [SerializeField]
    private float immortalTime;

    private SpriteRenderer spriteRender;

    public Rigidbody2D MyRigidbody;


    public float GetForce()
    {
        return jumpForce;
    }


    public bool Slide { get; set; }
    public bool Jump { get; set; }
    public bool OnGround { get; set; }

    public override bool GetIsDead()
    {
        if (health <= 0)
        {
            OnDead();
        }
        return health <= 0;
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        coin = 0;

        heart = 3;
        PlayerInfo player = new PlayerInfo();

        player.LoadPlayer();

        userName.text= player.playerName;

        MyRigidbody = GetComponent<Rigidbody2D>();

        spriteRender = GetComponent<SpriteRenderer>();


    }
    void Update()
    {
        if (!TakingDamage && !GetIsDead())
        {
            if(transform.position.y<-20f)
            {
                Death();
            }
            HandleInput();
            FixUpdate();
        }
        if(isCheckDie)
        {
            StartCoroutine(TakeDamage());
            isCheckDie = false;
        }
    }

    // Update is called once per frame
    void FixUpdate()
    {
        if(!TakingDamage && !GetIsDead())
        {
            float horizontal = Input.GetAxis("Horizontal");

            OnGround = IsGround();

            HandleMoment(horizontal);

            Flip(horizontal);

            HandleLayers();
        }
       
    }
    public void OnDead()
    {
        if(Dead!=null)
        {
            Dead();
        }
    }
    private void HandleMoment(float horizontal)
    {
        if (MyRigidbody.velocity.y < 0)
        {
            MyAnimator.SetBool("land", true);
        }
        if (!Attack )
        {
            MyRigidbody.velocity = new Vector2(horizontal * movementSpeed, MyRigidbody.velocity.y);
        }
        //if (Jump && MyRigidbody.velocity.y == 0 && OnGround)
        //{

        //}

        MyAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }
    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            ChangeDirection();
        }
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            MyAnimator.SetTrigger("attack");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MyAnimator.SetTrigger("slide");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MyAnimator.SetTrigger("jump");
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(kunai>0)
            {
                MyAnimator.SetTrigger("throw");
            }
        }
    }

    private bool IsGround()
    {
        if (MyRigidbody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] collider = Physics2D.OverlapCircleAll(point.position, groudRadius, whatIsGround);
                for (int i = 0; i < collider.Length; i++)
                {
                    if (collider[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    private void HandleLayers()
    {
        if (!OnGround)
        {
            MyAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            MyAnimator.SetLayerWeight(1, 0);
        }
    }
    public override void ThrowKnife(int value)
    {
        if(!OnGround && value==1 || OnGround && value==0)
        {
            base.ThrowKnife(value);
        }

    }
    private IEnumerator IndicateImmortal()
    {
        while(immortal)
        {
            spriteRender.enabled = false;
            yield return new WaitForSeconds(.1f);
            spriteRender.enabled = true;
            yield return new WaitForSeconds(.1f);
        }
    }    
    public override IEnumerator TakeDamage()
    {
        if (!immortal)
        {
            health -= 1;
            heart--;
            if (!GetIsDead())
            {
                MyAnimator.SetTrigger("death");
                immortal = true;
                StartCoroutine(IndicateImmortal());
                yield return new WaitForSeconds(immortalTime);
                immortal = false;
            }
            else
            {
                MyAnimator.SetTrigger("die");
            }
            yield return null;
        }
       
    }

    public override void Death()
    {
        MyRigidbody.velocity = Vector2.zero;
        MyAnimator.SetTrigger("idle");
        health = 3;
        heart = 3;
        transform.position = startPos.position;
    }
    public float GetMoveSpeed()
    {
        return base.movementSpeed;
    }
    public void SetMoveSpeed(float speed)
    {
        base.movementSpeed = speed;
    }

    public bool GetIsGround()
    {
        return OnGround;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.tag == "Coin")
        {
            coin++;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "EnemyFly" || other.gameObject.tag == "Trap")
        {
            StartCoroutine(TakeDamage());
        }
    }
}
