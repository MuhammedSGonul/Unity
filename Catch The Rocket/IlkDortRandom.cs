using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlkDortRandom : MonoBehaviour
{


    public GameObject R1;
    public GameObject R2;
    public GameObject R3;
    public GameObject R4;
    public GameObject R5;
    
    public Transform Karakter;

    int RandomDeger;
    int RandomDegerb;
    int RandomDegerc;
    int RandomDegerd;
    int a = 0;

    
     

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float ikiRoketArasindaUzaklik = OyununFizigi.uzaklikY;              //UzaklikY 
        float soldakiY = OyununFizigi.soldakiYNoktasi;                      
        float sagdakiY = soldakiY + (ikiRoketArasindaUzaklik / 2);


        if(a == 0)
        { 
            RandomDeger = Random.Range(1, 6);
            RandomDegerb = Random.Range(1, 6);
            RandomDegerc = Random.Range(1, 6);
            RandomDegerd = Random.Range(1, 6);

            switch (RandomDeger)               /////////SIRA SIRA ROKET OLUŞTURMA 
            {
                case 1:
                    Instantiate(R1, new Vector2(-0.325f, soldakiY), Quaternion.identity);
                    break;

                case 2:
                    Instantiate(R2, new Vector2(-0.325f, soldakiY), Quaternion.identity);
                    break;

                case 3:
                    Instantiate(R3, new Vector2(-0.325f, soldakiY), Quaternion.identity);
                    break;

                case 4:
                    Instantiate(R4, new Vector2(-0.325f, soldakiY), Quaternion.identity);
                    break;

                case 5:
                    Instantiate(R5, new Vector2(-0.325f, soldakiY), Quaternion.identity);
                    break;
            }

            switch (RandomDegerb)             
            {
                case 1:
                GameObject R1Klonb = Instantiate(R1, new Vector2(0.7369f, sagdakiY), Quaternion.identity);
                    R1Klonb.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                break;

                case 2:
                    GameObject R2Klonb = Instantiate(R2, new Vector2(0.7369f, sagdakiY), Quaternion.identity);
                    R2Klonb.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    break;

                case 3:
                    GameObject R3Klonb = Instantiate(R3, new Vector2(0.7369f, sagdakiY), Quaternion.identity);
                    R3Klonb.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    break;

                case 4:
                    GameObject R4Klonb = Instantiate(R4, new Vector2(0.7369f, sagdakiY), Quaternion.identity);
                    R4Klonb.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    break;

                case 5:
                    GameObject R5Klonb = Instantiate(R5, new Vector2(0.7369f, sagdakiY), Quaternion.identity);
                    R5Klonb.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    break;
            }

            switch (RandomDegerc)               /////////SIRA SIRA ROKET OLUŞTURMA 
            {
                case 1:
                    Instantiate(R1, new Vector2(-0.325f, soldakiY + ikiRoketArasindaUzaklik), Quaternion.identity);
                    break;

                case 2:
                    Instantiate(R2, new Vector2(-0.325f, soldakiY + ikiRoketArasindaUzaklik), Quaternion.identity);
                    break;

                case 3:
                    Instantiate(R3, new Vector2(-0.325f, soldakiY + ikiRoketArasindaUzaklik), Quaternion.identity);
                    break;

                case 4:
                    Instantiate(R4, new Vector2(-0.325f, soldakiY + ikiRoketArasindaUzaklik), Quaternion.identity);
                    break;

                case 5:
                    Instantiate(R5, new Vector2(-0.325f, soldakiY + ikiRoketArasindaUzaklik), Quaternion.identity);
                    break;
            }

            switch (RandomDegerd)
            {
                case 1:
                    GameObject R1Klond = Instantiate(R1, new Vector2(0.7369f, sagdakiY + ikiRoketArasindaUzaklik), Quaternion.identity);
                        R1Klond.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    break;

                case 2:
                    GameObject R2Klond = Instantiate(R2, new Vector2(0.7369f, sagdakiY + ikiRoketArasindaUzaklik), Quaternion.identity);
                        R2Klond.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    break;

                case 3:
                    GameObject R3Klond = Instantiate(R3, new Vector2(0.7369f, sagdakiY + ikiRoketArasindaUzaklik), Quaternion.identity);
                        R3Klond.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    break;

                case 4:
                    GameObject R4Klond = Instantiate(R4, new Vector2(0.7369f, sagdakiY + ikiRoketArasindaUzaklik), Quaternion.identity);
                        R4Klond.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    break;

                case 5:
                    GameObject R5Klond = Instantiate(R5, new Vector2(0.7369f, sagdakiY + ikiRoketArasindaUzaklik), Quaternion.identity);
                        R5Klond.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    break;
            }

            a++;

        }



    }



}

