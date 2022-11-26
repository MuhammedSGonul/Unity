using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject LevelCompletedPanel;
    [SerializeField] private TextMeshProUGUI collectedNumber;

    public void activeGameOverPanel(bool setState)
    {
        GameOverPanel.SetActive(setState);
    }

    public void activeLevelCompletedPanel(bool setState, int number)
    {
        LevelCompletedPanel.SetActive(setState);
        collectedNumber.text = "Numbers : " + number.ToString();

    }


}
