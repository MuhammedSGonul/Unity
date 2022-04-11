using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;


public class ReklamYerlestirme : MonoBehaviour, IUnityAdsListener
{

#if UNITY_IOS
    private string gameId = "3472969";
#elif UNITY_ANDROID
    private string gameId = "3472968";
#endif



    public static string oyunArasiReklam = "video";
    public

    void Start()
    {
  
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
    }


    public static void oyunArasiReklamGoster()
    {
        Advertisement.Show(oyunArasiReklam);
    }


    public void OnUnityAdsReady(string placementId)
    {


    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
       if(placementId == oyunArasiReklam)
       {
        
        if (showResult == ShowResult.Finished)
        {
          
        }
        else if (showResult == ShowResult.Skipped)
        {
           
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");    
        }
            Advertisement.RemoveListener(this);
        }
    }


    public void OnUnityAdsDidError(string message)
    {
   
    }

    public void OnUnityAdsDidStart(string placementId)
    {
     
    }
}