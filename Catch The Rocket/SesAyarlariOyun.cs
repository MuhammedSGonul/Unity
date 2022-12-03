using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SesAyarlariOyun : MonoBehaviour
{
    public Toggle OyunDurdurmaMuzik, OyunBittiMuzik, OyunBittiSes, OyunDurdurmaSes;




    public void MuzikDurumuGuncelle()
    {

        if (OyunDurdurmaMuzik.isOn == true)
        {
            PlayerPrefs.SetInt("MuzikDurum", 0);   // 1 Kapalı 0 Acik
        }
        else
        {
            PlayerPrefs.SetInt("MuzikDurum", 1);   // 1 Kapalı 0 Acik
        }

    }

    public void MuzikDurumunuGuncelleBitti()
    {

        if (OyunBittiMuzik.isOn == true)
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

        if (OyunDurdurmaSes.isOn == true)
        {
            PlayerPrefs.SetInt("SesDurum", 0);   // 1 Kapalı 0 Acik
        }
        else
        {
            PlayerPrefs.SetInt("SesDurum", 1);   // 1 Kapalı 0 Acik
        }
 
    }

    public void SesDurumunuGuncelleBitti()
    {
        if (OyunBittiSes.isOn == true)
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
        int MuzikDurum = PlayerPrefs.GetInt("MuzikDurum");
        int SesDurum = PlayerPrefs.GetInt("SesDurum");


        if (MuzikDurum == 1)
        {
            OyunBittiMuzik.isOn = false;
            OyunDurdurmaMuzik.isOn = false;
        }
        else
        {
            OyunBittiMuzik.isOn = true;
            OyunDurdurmaMuzik.isOn = true;
        }

        if (SesDurum == 1)
        {

            OyunDurdurmaSes.isOn = false;
            OyunBittiSes.isOn = false;
        }
        else
        {

            OyunDurdurmaSes.isOn = true;
            OyunBittiSes.isOn = true;
        }




    }
}
