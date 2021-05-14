using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator anim;
    public Color color1;

    private Color color;

    private SpriteRenderer sprite;

    private int health=15;

    public bool isDestroy=false;

    public GameObject ob;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="sword")
        {
            ChangeColor();
            health -= 5;
            if(health<=0)
            {
                Debug.Log("Earn Coin");
                anim.SetTrigger("Bang");
                isDestroy = true;
                //Instantiate(ob, transform.position, Quaternion.identity);
                StartCoroutine(SpawnReward());
                sprite.enabled = false;
            }
        }
    }
    void ChangeColor()
    {
        StartCoroutine(ChangeColorChest());
    }
    IEnumerator ChangeColorChest()
    {
        sprite.color = color1;
        yield return new WaitForSeconds(0.5f);
        sprite.color = color;
    }
    IEnumerator SpawnReward()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(ob, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
