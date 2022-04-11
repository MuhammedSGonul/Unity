using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public Transform meteorOlusturmaNoktasi;
    public Transform Karakter;

    public GameObject meteor;
    public static GameObject meteorKlon;
    public float dusmeHizi = 40f;

    public float meteorUzaklik = 15f;


    public static float meteorX;          //0 - 0.4f
    public static int meteorOlustuMu = 0;

    int a = 1;
    int b = 1;

    public GameObject MeteorUyariObje;
    public Transform MeteorUyariTransform;
    void Start()
    {
    }

    void Update()
    {
   
        if (Karakter.transform.position.y > meteorOlusturmaNoktasi.transform.position.y && a == 1)
        {
            meteorX = Random.Range(0f, 0.4f);
            meteorKlon = Instantiate(meteor, new Vector2(meteorX, Karakter.transform.position.y + meteorUzaklik), Quaternion.identity);
            meteorKlon.GetComponent<Rigidbody2D>().AddForce(-transform.up * dusmeHizi);
            meteorOlusturmaNoktasi.transform.position = new Vector2(0, meteorOlusturmaNoktasi.transform.position.y + 3.5f);
            a++;
        }


        if (Karakter.transform.position.y > meteorOlusturmaNoktasi.transform.position.y && a == 2)
        {
            meteorOlusturmaNoktasi.transform.position = new Vector2(0, meteorOlusturmaNoktasi.transform.position.y + 8f);
            a--;
        }

        if (a == 2)
        {
            MeteorUyariTransform.transform.position = new Vector2(meteorX, MeteorUyariTransform.transform.position.y);
            MeteorUyariObje.SetActive(true);
        }
        if(a == 1)
        {
            MeteorUyariObje.SetActive(false);
        }
   

    }


    
}
