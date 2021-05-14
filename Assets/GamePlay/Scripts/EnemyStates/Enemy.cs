using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : Character
{
    private IEnemyState currentSate;

    public GameObject Target { get; set; }

    [SerializeField]
    private float meleeRange;

    [SerializeField]
    private float throwRange;

    [SerializeField]
    private Transform leftEdge;

    [SerializeField]
    private Transform rightEdge;

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private GameObject pointFloat;
    public bool InMeleeRange
    {
        get
        {
            if(Target!=null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= meleeRange;
            }
            return false;
        }
    }

    public bool InThrowRange
    {
        get
        {
            if (Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= throwRange;
            }
            return false;
        }
    }

    public override bool GetIsDead()
    {
        return health <= 0;
    }



    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        slider.maxValue = health;
        slider.value = health;
        Player.Instance.Dead += new DeadEventHandler(RemoveTarget);
        Debug.Log("Enemy Start");
        ChangeState(new IdleState());
    }

   

    // Update is called once per frame
    void Update()
    {
        if(!GetIsDead())
        {
            if(!TakingDamage)
            {
                currentSate.Execute();
            }


            LookAtTarget();
        }
    }
    public void RemoveTarget()
    {
        Target = null;
        ChangeState(new PatrolState());
    }
    private void LookAtTarget()
    {
        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;
            if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
            {
                ChangeDirection();
            }
        }
    }
    public void ChangeState(IEnemyState newState)
    {
        if(currentSate!=null)
        {
            currentSate.Exit();
        }
        currentSate = newState;

        currentSate.Enter(this);
    }
    public void Move()
    {
        if (!Attack)
        {
            if ((GetDirection().x > 0 && transform.position.x < rightEdge.position.x) || (GetDirection().x < 0 && transform.position.x > leftEdge.position.x))
            {
                MyAnimator.SetFloat("speed", 1);

                transform.Translate(GetDirection() * (movementSpeed * Time.deltaTime));
            }
            else if(currentSate is PatrolState)
            {
                ChangeDirection();
            }
            
        }
        
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        currentSate.OnTriggerEnter(collision);
    }
    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }

    public override IEnumerator TakeDamage()
    {
        GameObject point= Instantiate(pointFloat, transform.position, Quaternion.identity);
        
        health -= 20;
        slider.value = health;
        if (!GetIsDead())
        {
            MyAnimator.SetTrigger("death");
        }
        else
        {
            MyAnimator.SetTrigger("die");
            yield return null;
        }

    }

    public override void Death()
    {
        DestroyObject(gameObject);
    }
}
