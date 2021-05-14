using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer m_lineRender;

    public ControlLight light;

    Transform m_transform;

    private void ShootLaser()
    {
        if (Physics2D.Raycast(m_transform.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
            if (_hit.collider.tag == "Player" && light.visible)
            {
                player.isCheckDie = true;
                Debug.Log("Hit");
            }

            Draw2Ray(laserFirePoint.position, _hit.point);
        }
        else
        {
            Draw2Ray(laserFirePoint.position, laserFirePoint.transform.position * defDistanceRay);
        }
    }
    void Draw2Ray(Vector2 startpos, Vector2 endPos)

    {
        m_lineRender.SetPosition(0, startpos);
        m_lineRender.SetPosition(1, endPos);
    }
    void Start()
    {
        m_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootLaser();
    }
}
