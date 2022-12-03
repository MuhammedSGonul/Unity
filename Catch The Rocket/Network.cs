using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Network : MonoBehaviour
{

    public Animator ArkaFade, OnFade, Logo;

    public GameObject arkaFade, onFade, logo;

    int networkDegisken = 0;
    int m;

    void Start()
    {
        arkaFade.SetActive(false);
        onFade.SetActive(false);
        logo.SetActive(false);
    }




    // Update is called once per frame
    void Update()
    {
                                                                          //Adım adım yaptırma

        if (Application.internetReachability == NetworkReachability.NotReachable && m == 0)
        {

            arkaFade.SetActive(true);
            ArkaFade.SetFloat("AcilB", 1.0f);
        }

        if (Application.internetReachability == NetworkReachability.NotReachable && m == 1)
        {

            onFade.SetActive(true);
            OnFade.SetFloat("AcilP", 1.0f);
        }

        if (Application.internetReachability == NetworkReachability.NotReachable && m == 2)
        {

            logo.SetActive(true);
            Logo.SetFloat("AcilLogo", 1.0f);
        }

        if (Application.internetReachability == NetworkReachability.NotReachable && m == 3)
        {
            Logo.SetFloat("LogoDon", 1.0f);
            Logo.SetFloat("AcilLogo", 0f);
        }

        
        if (Application.internetReachability != NetworkReachability.NotReachable && m == 3)
        {
            Logo.SetFloat("LogoDon", 0f);
            Logo.SetFloat("KapanLogo", 1f);
        }

        if(Application.internetReachability != NetworkReachability.NotReachable && m == 2)
        {
            logo.SetActive(false);
            Logo.SetFloat("KapanLogo", 0);

            OnFade.SetFloat("KapanP", 1.0f);
            OnFade.SetFloat("AcilP", 0f);
        }

        if (Application.internetReachability != NetworkReachability.NotReachable && m == 1)
        {
            ArkaFade.SetFloat("KapanB", 1.0f);
            ArkaFade.SetFloat("AcilB", 0f);
        }

        if (Application.internetReachability != NetworkReachability.NotReachable && m == -1)
        {
            onFade.SetActive(false);
            arkaFade.SetActive(false);


            m = 0;
        }





    }

    public void ArkaFadeKapandi()
    {
        m = -1;
        PlayerPrefs.SetInt("networkBekleniyor", 0);
    }

    public void ArkaFadeAcildi()
    {
        m = 1;
        PlayerPrefs.SetInt("networkBekleniyor", 1);
    }
    public void OnFadeAcildi()
    {
        m = 2;
    }
    public void LogoAcildi()
    {
        m = 3;
    }


}
