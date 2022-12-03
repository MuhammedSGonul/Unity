using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YuksekSkor : MonoBehaviour
{
    public Transform Karakter;              //skor burada hesaplanıyor

    

    public static float skor
    {
        get;
        private set;
    }

    public static float yuksekSkor
    {
        get;
        private set;
    }

    private Vector2 baslangicPosition;

    void Awake()
    {
        baslangicPosition = Karakter.position;
        skor = 0; 
    }

    void Update()
    {
        float anaMenuYuksekSkor = PlayerPrefs.GetFloat("yuksekSkor");

        skor = Mathf.Abs(Karakter.position.y - baslangicPosition.y);
        yuksekSkor = Mathf.Max(skor, yuksekSkor);

        float anayuksekSkor = Mathf.Max(yuksekSkor, anaMenuYuksekSkor);

        PlayerPrefs.SetFloat("yuksekSkor", anayuksekSkor);
    }


}
