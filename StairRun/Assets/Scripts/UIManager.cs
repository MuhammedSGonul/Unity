using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject Panel_Start;
    [SerializeField] GameObject Panel_Static, Panel_GameOver, Panel_Finished;
    [SerializeField] TextMeshProUGUI FinishedCollectedBonusText;
    [SerializeField] GameObject CursorDot;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CursorDot.SetActive(true);
        }
        if (Input.GetMouseButton(0))
        {
            CursorDot.transform.position = Input.mousePosition;
        }
        if (!Input.GetMouseButton(0))
        {
            CursorDot.SetActive(false);
        }
    }



    public void StaticPanel(bool isActive)
    {
        Panel_Static.SetActive(isActive);
    }
    public void StartPanel(bool isActive)
    {
        Panel_Start.SetActive(isActive);
    }
    public void GameOverPanel(bool isActive)
    {
        Panel_GameOver.SetActive(isActive);
    }
    public void FinishedPanel(bool isActive, string collected)
    {
        Panel_Finished.SetActive(isActive);
        FinishedCollectedBonusText.text = "Collected : " + collected;
    }


}
