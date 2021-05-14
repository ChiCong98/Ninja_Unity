using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOb : MonoBehaviour
{
    // Start is called before the first frame update
  void RemoveGameOb()
    {
        Destroy(gameObject);
    }
}
