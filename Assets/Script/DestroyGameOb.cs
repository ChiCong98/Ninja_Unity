using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameOb : MonoBehaviour
{
    // Start is called before the first frame update
 void RemoveOb()
    {
        Destroy(gameObject);
    }
}
