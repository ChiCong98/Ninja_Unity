using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlUIGame : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private Text textCoin;


    [SerializeField]
    private Text textHeart;

    [SerializeField]
    private Text textKunai;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textCoin.text = "x"+ player.coin.ToString();

        textHeart.text = player.heart.ToString()+"x";

        textKunai.text = "x" + player.kunai.ToString();
    }
}
