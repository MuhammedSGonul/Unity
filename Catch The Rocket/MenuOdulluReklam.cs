using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

[RequireComponent(typeof(Button))]
public class MenuOdulluReklam : MonoBehaviour, IUnityAdsListener
{

#if UNITY_IOS
    private string gameId = "3472969";
#elif UNITY_ANDROID
    private string gameId = "3472968";
#endif

    Button myButton;
    public string odulluReklam = "rewardedVideo";


    void Start()
    {
        myButton = GetComponent<Button>();


        myButton.interactable = Advertisement.IsReady(odulluReklam);

      
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

       
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
    }



    public void kirkBeseBasildi()
    {
       
    }


    void ShowRewardedVideo()
    {
        Advertisement.Show(odulluReklam);
    }

  
    public void OnUnityAdsReady(string placementId)
    {
       
        if (placementId == odulluReklam)
        {
            myButton.interactable = true;
        }
       /* else
        {
            myButton.interactable = false;
        }*/
    }


    IEnumerator reklamTimer()
    {
        yield return new WaitForSeconds(1);
    }




    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
      if(placementId == odulluReklam)
      {

        
        if (showResult == ShowResult.Finished)
        {
            int suankiCoin = PlayerPrefs.GetInt("coinDegeri");
            PlayerPrefs.SetInt("coinDegeri", suankiCoin + 45);
       
        }
        else if (showResult == ShowResult.Skipped)
        {
         
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");   
        }
            Advertisement.RemoveListener(this);
            StartCoroutine(reklamTimer());
            Advertisement.AddListener(this);
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