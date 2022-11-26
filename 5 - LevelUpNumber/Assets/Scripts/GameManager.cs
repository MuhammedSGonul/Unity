using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [HideInInspector] public static bool isGameOver = false;

    [SerializeField] UIManager UIManager;

    private void Awake()
    {
        isGameOver = false;
    }


    public void overflowGameOver()
    {
        isGameOver = true;
        UIManager.activeGameOverPanel(true);

    }

    public void levelCompleted()
    {
        isGameOver = true;
        UIManager.activeLevelCompletedPanel(true, CounterController.number);
    }




}
