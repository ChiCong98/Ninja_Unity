using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public AIPath aiPath;

    // Update is called once per frame
    void Update()
    {
        if (aiPath.velocity.x > 0.01f)
        {
            transform.localScale = new Vector3(3, 3, 1);
        }
        else if (aiPath.velocity.x < -0.01f)
        {
            transform.localScale = new Vector3(-3, 3, 1);
        }
    }
}
