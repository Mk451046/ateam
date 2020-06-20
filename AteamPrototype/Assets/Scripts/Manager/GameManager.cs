using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UISpace;
using UnityEngine.Analytics;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    PlayerManager playerManager = new PlayerManager();
    
    public static bool gameStart = false;
    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //time = timeSlider.value;
    }
    private void Update()
    {
        //if (time > 0 && gameStart == true)
        //{
        //    time -= Time.deltaTime;
        //}
        //else
        //{
        //    ChangeGameOver();
        //}
    }

    public void ChangeGameStart()
    {
        gameStart = true;
    }
    public void ChangeGameOver()
    {
        gameStart = false;
    }
}
