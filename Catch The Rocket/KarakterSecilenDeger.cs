using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterSecilenDeger : MonoBehaviour
{

    public GameObject anaMenu;
    int karakterNo;

    void Start()
    {
        
    }


    void Update()
    {
        
        if (anaMenu.activeSelf == true)
        {
            karakterNo = PlayerPrefs.GetInt("secilenKarakterNo");
            PlayerPrefs.SetInt("karakterNo", karakterNo);
        }

    }
}
