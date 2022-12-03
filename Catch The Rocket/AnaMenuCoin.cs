using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaMenuCoin : MonoBehaviour
{
    public GameObject CoinText;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int coinMiktar = PlayerPrefs.GetInt("coinDegeri");

        CoinText.GetComponent<UnityEngine.UI.Text>().text = coinMiktar.ToString();

    }
}
