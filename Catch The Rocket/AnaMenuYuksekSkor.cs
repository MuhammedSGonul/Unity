using System.Collections;
using System.Collections.Generic;
using UnityEngine;              //Burada sadece ana menude high score gösteriyor
using UnityEngine.UI;

public class AnaMenuYuksekSkor : MonoBehaviour
{
    public GameObject yuksekSkorText;
    public GameObject sonSkorText;


    void Start()
    {

    }

    void Update()
    {
        //int highscore = YuksekSkor.yuksekSkor;
        float highscore = PlayerPrefs.GetFloat("yuksekSkor");       //LeaderBoarda gireceğimiz değişken
        float sonSkor = PlayerPrefs.GetFloat("SonOyundakiSkor");

        //yuksekSkorText.GetComponent<UnityEngine.UI.Text>().text = highscore.ToString();
        yuksekSkorText.GetComponent<UnityEngine.UI.Text>().text = string.Format("{0:#0.00}", highscore);
        sonSkorText.GetComponent<UnityEngine.UI.Text>().text = string.Format("{0:#0.00}", sonSkor);
    }
}
