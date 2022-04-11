using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;


public class OyunBitisOdulluReklam : MonoBehaviour, IUnityAdsListener
{

#if UNITY_IOS
    private string gameId = "3472969";
#elif UNITY_ANDROID
    private string gameId = "3472968";
#endif
    public GameObject buton;
    public GameObject menu;
    public Button myButton;
    public string coinIkiKati = "olduktenSonra";
    int toplananCoin = 0;
    int reklamBittiTest = 0;
    

    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.interactable = Advertisement.IsReady(coinIkiKati);
  
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
    }

    void Update()
    {
        
        toplananCoin = FizikAlgoritma3.oyundaToplananCoinMiktari;
        reklamBittiTest = PlayerPrefs.GetInt("reklamBittiMenuyuKapat");
      


        if (toplananCoin == 0)
        {
            buton.SetActive(false);
            menu.SetActive(false);
        }
        else
        {
            buton.SetActive(true);
            menu.SetActive(true);
        }

        if(reklamBittiTest == 1)
        {
            buton.SetActive(false);
            menu.SetActive(false);
            PlayerPrefs.SetInt("reklamBittiMenuyuKapat", 0);
        }

    }
    

    public void olduktenSonrayaBasildi()
    {
       
    }
    

  
    public void ShowRewardedVideo()
    {
        Advertisement.Show(coinIkiKati);
    }

   
    public void OnUnityAdsReady(string placementId)
    {
       
        if (placementId == coinIkiKati)
        {
            myButton.interactable = true;
        }
        /* else
         {
             myButton.interactable = false;
         }*/
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
     if(placementId == coinIkiKati)
     {

        
        if (showResult == ShowResult.Finished)
        {

     
                int guncelCoin = PlayerPrefs.GetInt("coinDegeri");
                int oyundaToplanilan = FizikAlgoritma3.oyundaToplananCoinMiktari;
                PlayerPrefs.SetInt("coinDegeri", guncelCoin + oyundaToplanilan);
                PlayerPrefs.SetInt("reklamBittiMenuyuKapat", 1);

        }
        else if (showResult == ShowResult.Skipped)
        {
           
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");     //errrorrorrr ver
        }
            Advertisement.RemoveListener(this);
        }

    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }





}