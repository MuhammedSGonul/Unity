using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dogoin : MonoBehaviour
{

    //-0.0683 -------  0.455

    public GameObject Coin;
    public Transform Karakter;
    public Transform coinOlusturmaNoktasi;
    public float coinArasiUzaklik = 0.1f;
    float pay = 5f;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(Karakter.transform.position.y > coinOlusturmaNoktasi.transform.position.y)
        {
            float coinX = Random.Range(-0.0683f, 0.455f);
            float coinY = Random.Range(0, 1f);
            int coinMiktar = Random.Range(3, 5);

            switch (coinMiktar)
            {
                case 3:
                    Instantiate(Coin, new Vector2(coinX, coinOlusturmaNoktasi.transform.position.y + pay + coinY), Quaternion.identity);
                    Instantiate(Coin, new Vector2(coinX, coinOlusturmaNoktasi.transform.position.y + pay + coinY + coinArasiUzaklik), Quaternion.identity);
                    Instantiate(Coin, new Vector2(coinX, coinOlusturmaNoktasi.transform.position.y + pay + coinY + (2 * coinArasiUzaklik)), Quaternion.identity);
                    coinOlusturmaNoktasi.transform.position = new Vector2(0, coinOlusturmaNoktasi.transform.position.y + (pay / 2f));
                    break;
                case 4:
                    Instantiate(Coin, new Vector2(coinX, coinOlusturmaNoktasi.transform.position.y + pay + coinY), Quaternion.identity);
                    Instantiate(Coin, new Vector2(coinX, coinOlusturmaNoktasi.transform.position.y + pay + coinY + coinArasiUzaklik), Quaternion.identity);
                    Instantiate(Coin, new Vector2(coinX, coinOlusturmaNoktasi.transform.position.y + pay + coinY + (2 * coinArasiUzaklik)), Quaternion.identity);
                    Instantiate(Coin, new Vector2(coinX, coinOlusturmaNoktasi.transform.position.y + pay + coinY + (3 * coinArasiUzaklik)), Quaternion.identity);
                    coinOlusturmaNoktasi.transform.position = new Vector2(0, coinOlusturmaNoktasi.transform.position.y + (pay / 2f));
                    break;
                case 5:
                    Instantiate(Coin, new Vector2(coinX, coinOlusturmaNoktasi.transform.position.y + pay + coinY), Quaternion.identity);
                    Instantiate(Coin, new Vector2(coinX, coinOlusturmaNoktasi.transform.position.y + pay + coinY + coinArasiUzaklik), Quaternion.identity);
                    Instantiate(Coin, new Vector2(coinX, coinOlusturmaNoktasi.transform.position.y + pay + coinY + (2 * coinArasiUzaklik)), Quaternion.identity);
                    Instantiate(Coin, new Vector2(coinX, coinOlusturmaNoktasi.transform.position.y + pay + coinY + (3 * coinArasiUzaklik)), Quaternion.identity);
                    Instantiate(Coin, new Vector2(coinX, coinOlusturmaNoktasi.transform.position.y + pay + coinY + (4 * coinArasiUzaklik)), Quaternion.identity);
                    coinOlusturmaNoktasi.transform.position = new Vector2(0, coinOlusturmaNoktasi.transform.position.y + (pay / 2f));
                    break;



            }




        }



        
    }




}
