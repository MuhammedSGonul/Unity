using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool gameOver = false;


    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver = true;
        Debug.Log("GameOver");

    }




    
}
