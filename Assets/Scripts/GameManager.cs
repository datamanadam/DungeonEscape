using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public Player Player { get; private set; }

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("Game Mangaer is Null");
            }
            return _instance;
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }


    public bool HasKeyToCastle { get; set; }

    private void Awake()
    {
        _instance = this;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
}
