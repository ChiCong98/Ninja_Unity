using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour
{

    public Animator MyAnimator { get; private set; }

    [SerializeField]
    protected GameObject knifePrefab;

    [SerializeField]
    protected int health;

    [SerializeField]
    private EdgeCollider2D swordCollider;

    [SerializeField]
    private List<string> damageCollider;

    public abstract bool GetIsDead();

    [SerializeField]
    protected float movementSpeed;

    public bool Attack { get; set; }

    public bool TakingDamage { get; set; }
    public EdgeCollider2D SwordCollider { get => swordCollider; set => swordCollider = value; }

    [SerializeField]
    private Transform knifePos;

    protected  bool facingRight;


    // Start is called before the first frame update
    public virtual void Start()
    {
        facingRight = true;
        MyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeDirection()
    {
        //facingRight = !facingRight;
        //transform.localScale = new Vector3(transform.localScale.x * -1f, 1f, 1);
        facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        
    }
    public virtual void ThrowKnife(int value)
    {
        if (facingRight)
        {
            GameObject tmp = (GameObject)Instantiate(knifePrefab, knifePos.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            tmp.GetComponent<Knife>().Initialize(Vector2.right);
        }
        else
        {
            GameObject tmp = (GameObject)Instantiate(knifePrefab, knifePos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            tmp.GetComponent<Knife>().Initialize(Vector2.left);
        }
    }
    public abstract IEnumerator TakeDamage();
    public abstract void Death();

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(damageCollider.Contains(other.tag))
        {
            StartCoroutine(TakeDamage());
        }
    }
    public void MeleeAttack()
    {
        SwordCollider.enabled = true;
    }
}
