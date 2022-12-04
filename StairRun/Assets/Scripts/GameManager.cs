using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIManager UIManager;
    [HideInInspector] public static bool isFinished = false, isMove = false;

    void Update()
    {

        if (Input.GetMouseButton(0) && UIManager.Panel_Start.activeSelf)
        {
            UIManager.StartPanel(false);
            UIManager.StaticPanel(true);
            PlayerController.speed = 1;
            isMove = true;
        }

        if(BridgeManager.collectedBricks < 0 )
        {
            GameOver();
        }
    }


    public void GameOver()
    {
        Time.timeScale = 0;
        UIManager.GameOverPanel(true);
    }

    public void GameFinished(string collected)
    {
        PlayerController.speed = 0;
        UIManager.FinishedPanel(true, collected);
    }
}
