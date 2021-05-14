using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyFocus : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AIPath aiPath;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            aiPath.canSearch = true;
        }
    }
}
