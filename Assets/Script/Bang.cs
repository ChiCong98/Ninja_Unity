using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bang : MonoBehaviour
{
    public ChangeColor color;

    private SpriteRenderer sprite;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (color.checkBom)
        {
            anim.SetTrigger("active");
        }
    }
    void RemoveOb()
    {
        Destroy(gameObject);
    }
}
