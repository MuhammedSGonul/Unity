using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SesAyarlariMenu : MonoBehaviour
{

    public Toggle AnaMenuMuzik, AnaMenuSes;

    int SesDurum;
    int MuzikDurum;


    public void MuzikDurumuGuncelle()
    {


        if (AnaMenuMuzik.isOn == true)
        {
            PlayerPrefs.SetInt("MuzikDurum", 0);   // 1 Kapalı 0 Acik
        }
        else
        {
            PlayerPrefs.SetInt("MuzikDurum", 1);   // 1 Kapalı 0 Acik
        }


       
    }

    public void SesDurumuGuncelle()
    {

        if (AnaMenuSes.isOn == true)
        {
            PlayerPrefs.SetInt("SesDurum", 0);   // 1 Kapalı 0 Acik
        }
        else
        {
            PlayerPrefs.SetInt("SesDurum", 1);   // 1 Kapalı 0 Acik
        }

    }



    void Update()
    {
        MuzikDurum = PlayerPrefs.GetInt("MuzikDurum");
        SesDurum = PlayerPrefs.GetInt("SesDurum");


        if(MuzikDurum == 1)
        {
            
            AnaMenuMuzik.isOn = false;
        }
        else
        {
            
            AnaMenuMuzik.isOn = true;
        }

        if (SesDurum == 1)
        {
            
            AnaMenuSes.isOn = false;
        }
        else
        {
            
            AnaMenuSes.isOn = true;
        }




    }


}
