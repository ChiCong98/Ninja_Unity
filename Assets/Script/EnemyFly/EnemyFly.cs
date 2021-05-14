using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFly : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private int  health;

    [SerializeField]
    private GameObject pointFloat;
    // Start is called before the first frame update
    void Start()
    {
        health = 60;

        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="sword"|| collision.gameObject.tag == "Knife")
        {
            health -= 20;
            GameObject point = Instantiate(pointFloat, transform.position, Quaternion.identity);
            slider.value = health;
        }
    }
}
