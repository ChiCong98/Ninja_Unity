using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{
    public string userName;

    [SerializeField]
    private InputField inputName;

    //private Players players=new Players();
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        userName = inputName.text;
    }
    public void NewGame()
    {
        PlayerInfo player = new PlayerInfo();

        player.playerName = userName;
        player.SavePlayer();
        SceneManager.LoadScene("Forest");
    }
}
