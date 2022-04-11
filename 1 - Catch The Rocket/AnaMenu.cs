using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AnaMenu : MonoBehaviour
{
    public Animator S1DenS2GecisAnimasyoncusu;
    public Animator S2DenS1GecisAnimasyoncusu;
    public Animator S2DenS1GecinceGelecekAnimasyoncu;



    //Gecis --> S1 kapanis
    //Gecis4 --> S1 acilis

    //Gecis2 --> S2 kapanis
    //Gecis3 --> S2 acilis
    Scene SuankiSahne;
    static int MenuDegiskeni = 0;           //Static başlığı sayesinde değişkenimiz global bir değiken oldu(Sahneler arası değişken)
    public static int AnaMenuyeDonBasildi = 0;



    void Start()
    {
       
    }


    public void YeniOyunOlustur()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SceneAzalt()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void S1denS2GecisAnimasyonunuOynat()
    {

        S1DenS2GecisAnimasyoncusu.SetFloat("Gecis", 1.0f);
    }

    public void S2denS1GecisAnimasyonunuOynat()
    {
        AnaMenuyeDonBasildi++;
        Time.timeScale = 1.0f;
        S2DenS1GecisAnimasyoncusu.SetFloat("Gecis2", 1.0f);
    }

    public void S2denS1AcilisAnimasyonuOynat()
    {
        S2DenS1GecinceGelecekAnimasyoncu.SetFloat("Gecis4", 1.0f);
    }

    public void coinTest()
    {
        int suankiCoin = PlayerPrefs.GetInt("coinDegeri");
        suankiCoin = suankiCoin + 1000;
        PlayerPrefs.SetInt("coinDegeri", suankiCoin);
    }

    public void verileriSifirla()
    {
        PlayerPrefs.DeleteAll();
    }


    void FixedUpdate()
    {
        Scene SuankiSahne = SceneManager.GetActiveScene();



        if (SuankiSahne.name == "Giris" && MenuDegiskeni == 0)
        {
            MenuDegiskeni++;
            AnaMenuyeDonBasildi = 0;
        }
        if(SuankiSahne.name == "Oyun" && MenuDegiskeni == 1)
        {
            S1DenS2GecisAnimasyoncusu.SetFloat("Gecis3", 1.0f);
            MenuDegiskeni++;
        }

        if(MenuDegiskeni == 2 && SuankiSahne.name == "Giris")
        {
           S2DenS1GecinceGelecekAnimasyoncu.SetFloat("Gecis4", 1.0f);
           MenuDegiskeni = 0;
        }


    }


}
