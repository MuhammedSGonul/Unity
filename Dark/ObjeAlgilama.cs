using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeAlgilama : MonoBehaviour
{
    // Sahne NOLARI
    //1 : Yatak Odasi
    //2 : Koridor
    //3 : WC
    //4 : Merdiven AltKat
    //5 : AltKat


    public GameObject Uyari;

    public static int etkilesimNo = 0;
    public static int sahneNo = 1;

    int ObjeDurumu = 0;
    bool karakterUzerineBasildiCheck = false;

    void Update()
    {
        uyariSign();
        mouseClick();
    }




    void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {

            case "Laptop":
                ObjeDurumu = 1;
                break;

            case "Gardrop":
                ObjeDurumu = 2;
                break;

            case "YatakOdaKapi1":
                ObjeDurumu = 3;
                break;

            case "YatakOdaKapi2":
                ObjeDurumu = 4;
                break;

            case "WCKapi1":
                ObjeDurumu = 5;
                break;

            case "WCKapi2":
                ObjeDurumu = 6;
                break;

        }

    }


    void OnTriggerExit2D(Collider2D other)
    {
        ObjeDurumu = 0;
    }


    void OnMouseDown()
    {
        karakterUzerineBasildiCheck = true;
    }



    void mouseClick()
    {

        if(karakterUzerineBasildiCheck == true)
        {
            switch (ObjeDurumu)
            {
                case 1:
                    etkilesimNo = 1;
                    karakterUzerineBasildiCheck = false;
                    break;

                case 2:
                    etkilesimNo = 2;
                    karakterUzerineBasildiCheck = false;
                    break;

                case 3:
                    etkilesimNo = 3;
                    sahneNo = 2;    //Koridor
                    karakterUzerineBasildiCheck = false;
                    break;

                case 4:
                    etkilesimNo = 4;
                    sahneNo = 1;    //Yatak Odasi
                    karakterUzerineBasildiCheck = false;
                    break;

                case 5:
                    etkilesimNo = 5;
                    sahneNo = 3;    //WC
                    karakterUzerineBasildiCheck = false;
                    break;

                case 6:
                    etkilesimNo = 6;
                    sahneNo = 2;    //Koridor
                    karakterUzerineBasildiCheck = false;
                    break;

            }
        }
        else
        {
            etkilesimNo = 0;
        }

    }


    void uyariSign()
    {
        if (ObjeDurumu != 0)
        {
            Uyari.SetActive(true);
        }
        else
        {
            Uyari.SetActive(false);
        }
    }
    
}
