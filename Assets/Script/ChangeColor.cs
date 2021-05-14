using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sprite;
    public Color color1;
    public Color color2;

    private float timeCountDown = 2;

    public bool checkBom = false;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (checkBom)
        {
            sprite.enabled = false;
            checkBom = false;
        }
    }
    IEnumerator Change()
    {
        float time = 0;

        while (!checkBom)
        {
            if (sprite.color == color1)
            {
                sprite.color = color2;
            }
            else
            {
                sprite.color = color1;
            }
            time += Time.deltaTime + 0.25f;
            if (time >= timeCountDown)
            {
                checkBom = true;
            }
            yield return new WaitForSeconds(0.25f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            StartCoroutine(Change());
        }
    }
}
