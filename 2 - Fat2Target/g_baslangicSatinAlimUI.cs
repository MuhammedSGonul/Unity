using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class g_baslangicSatinAlimUI : MonoBehaviour
{
    int ziplamaYukseltLevelPP, coinYukseltLevelPP;

    
    Button ziplamaLevelYukseltButon, coinLevelYukseltButon, parasutButon, renkDegistirButon, sifirlaButon;

    public TMPro.TextMeshProUGUI ziplamaLevelText, ziplamaFiyatText, coinLevelText, coinFiyatText, parasutFiyatText, anaCoinText; 

    int anaCoinMiktarPP;

    void Start()
    {
       /* 
        int ilkOynanisKontrol = PlayerPrefs.GetInt("ilkOynanisKontrol");
        if(ilkOynanisKontrol == 0) //ilk 
        {

            PlayerPrefs.SetInt("ilkOynanisKontrol", 1);
        }
       */

        /*
        playerPrefsDegerleriGetir();

        if (ziplamaYukseltLevelPP == 0) PlayerPrefs.SetInt("ziplamaLevel", 1);
        if (coinYukseltLevelPP == 0) PlayerPrefs.SetInt("coinLevel", 1);

        playerPrefsDegerleriGetir();
        UIObjeleriniGetir();
        playerPrefsDegerleriniYazdir();
        */

    }

    void Update()
    {
        /*
        playerPrefsDegerleriGetir();

        

        playerPrefsDegerleriniYazdir();

        

        if (anaCoinMiktarPP < int.Parse(ziplamaFiyatText.text))
        {
            ziplamaLevelYukseltButon.interactable = false;
        }
        else
        {
            ziplamaLevelYukseltButon.interactable = true;
            
        }

        if (anaCoinMiktarPP < int.Parse(coinFiyatText.text))
        {
            coinLevelYukseltButon.interactable = false;
        }

        if (anaCoinMiktarPP < 100)
        {
            renkDegistirButon.interactable = false;
        }
        /*
        if (anaCoinMiktarPP < int.Parse(parasutFiyatText.text))
        {
            parasutButon.interactable = false;
        }
        */
        





    }

    public void ziplamaLevelYukseltFonksiyon()
    {
        //Debug.Log("bastı");

        int anaCoin = PlayerPrefs.GetInt("anaCoinMiktar");
        PlayerPrefs.SetInt("anaCoinMiktar", anaCoin - int.Parse(ziplamaFiyatText.text));
        int anaCoinYeniden = PlayerPrefs.GetInt("anaCoinMiktar");
        anaCoinText.text = anaCoinYeniden.ToString();

        int ziplamaLevel = PlayerPrefs.GetInt("ziplamaLevel");
        PlayerPrefs.SetInt("ziplamaLevel", ziplamaLevel + 1);

    }

    public void coinLevelYukseltFonksiyon()
    {
        //Debug.Log("bastı");

        int anaCoin = PlayerPrefs.GetInt("anaCoinMiktar");
        PlayerPrefs.SetInt("anaCoinMiktar", anaCoin - int.Parse(coinFiyatText.text));
        int anaCoinYeniden = PlayerPrefs.GetInt("anaCoinMiktar");
        anaCoinText.text = anaCoinYeniden.ToString();

        int coinLevel = PlayerPrefs.GetInt("coinLevel");
        PlayerPrefs.SetInt("coinLevel", coinLevel + 1);


    }

    public void renkDegistirFonksiyon()
    {
        //Debug.Log("bastı");

        int anaCoin = PlayerPrefs.GetInt("anaCoinMiktar");
        PlayerPrefs.SetInt("anaCoinMiktar", anaCoin - 100);
        int anaCoinYeniden = PlayerPrefs.GetInt("anaCoinMiktar");
        anaCoinText.text = anaCoinYeniden.ToString();

    }

    public void parasutFonksiyon()
    {
        //Debug.Log("bastı");

        int anaCoin = PlayerPrefs.GetInt("anaCoinMiktar");
        PlayerPrefs.SetInt("anaCoinMiktar", anaCoin - int.Parse(parasutFiyatText.text));
        int anaCoinYeniden = PlayerPrefs.GetInt("anaCoinMiktar");
        anaCoinText.text = anaCoinYeniden.ToString();



    }


    void UIObjeleriniGetir()
    {
        ziplamaLevelYukseltButon = GameObject.FindGameObjectWithTag("UI_baslangicPanel_ziplamaYukseltButon").gameObject.GetComponent<Button>();
        coinLevelYukseltButon = GameObject.FindGameObjectWithTag("UI_baslangicPanel_coinYukseltButon").gameObject.GetComponent<Button>();
        parasutButon = GameObject.FindGameObjectWithTag("UI_baslangicPanel_parasutButon").gameObject.GetComponent<Button>();
        renkDegistirButon = GameObject.FindGameObjectWithTag("UI_baslangicPanel_renkDegistirButon").gameObject.GetComponent<Button>();
        sifirlaButon = GameObject.FindGameObjectWithTag("UI_devPanel_sifirlaButon").gameObject.GetComponent<Button>();

        ziplamaLevelText = GameObject.FindGameObjectWithTag("UI_baslangicPanel_ziplamaYukseltLevelText").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        ziplamaFiyatText = GameObject.FindGameObjectWithTag("UI_baslangicPanel_ziplamaYukseltFiyatText").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        coinLevelText = GameObject.FindGameObjectWithTag("UI_baslangicPanel_coinYukseltLevelText").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        coinFiyatText = GameObject.FindGameObjectWithTag("UI_baslangicPanel_coinYukseltFiyatText").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        parasutFiyatText = GameObject.FindGameObjectWithTag("UI_baslangicPanel_parasutFiyatText").gameObject.GetComponent<TMPro.TextMeshProUGUI>();

        anaCoinText = GameObject.FindGameObjectWithTag("UI_baslangicPanel_coinMiktarText").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }
   

    void playerPrefsDegerleriGetir()
    {
        ziplamaYukseltLevelPP = PlayerPrefs.GetInt("ziplamaLevel");
        coinYukseltLevelPP = PlayerPrefs.GetInt("coinLevel");
        anaCoinMiktarPP = PlayerPrefs.GetInt("anaCoinMiktar");

    }


    void playerPrefsDegerleriniYazdir()
    {
        anaCoinText.text = anaCoinMiktarPP.ToString();
        ziplamaLevelText.text = ziplamaYukseltLevelPP.ToString();
        coinLevelText.text = coinYukseltLevelPP.ToString();
    }



    public void playerPrefsDegerleriniSifirla()
    {
        PlayerPrefs.DeleteAll();
    }
}  
