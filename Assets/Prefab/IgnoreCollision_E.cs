using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision_E : MonoBehaviour
{
  
    public GameObject ob;

    // Start is called before the first frame update
    private void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<EdgeCollider2D>(), ob.GetComponent<EdgeCollider2D>(), true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
