using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class g_skorText : MonoBehaviour
{

    void Start()
    {
        int anaSkor = PlayerPrefs.GetInt("anaSkor");
        Text skorText = GameObject.FindGameObjectWithTag("UI_baslangicSkor").GetComponent<Text>();
        skorText.text = anaSkor.ToString();
    }




}
