using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLandMove : MonoBehaviour
{
    private bool direction = true;
    [SerializeField]
    private float spped;
    private Rigidbody2D myRigid;
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FixedUpdate();
    }
    private void FixedUpdate()
    {
        if (direction)
        {
            myRigid.velocity = new Vector2(spped * Time.deltaTime, myRigid.velocity.y);
        }
        else
        {
            myRigid.velocity = new Vector2(-spped * Time.deltaTime, myRigid.velocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            direction = !direction;
        }

    }


}
