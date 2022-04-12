using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g_haritaOlusturucu : MonoBehaviour
{
    public GameObject oyunSonu, oyunSonBonus;
    public GameObject yol1, yol2;
    int yolUzunlugu;
    int yolA = 0, yolB = 0;

    int engelCesitSayi = 36;
    int kucultSayi = 8;
    int buyutSayi = 9;

    int engelPoz1 = 0, engelPoz2 = 0, engelPoz3 = 0, engelPoz4 = 0, engelPoz5 = 0;

    public int yiyecekEngelAciklik = 20;

    [Header("Kucultler : ")]
    public GameObject kucult1;
    public GameObject kucult2, kucult3, kucult4, kucult5, kucult6, kucult7;

    [Header("Buyutler : ")]
    public GameObject buyult1;
    public GameObject buyult2, buyult3, buyult4, buyult5, buyult6, buyult7, buyult8;

    [Header("Engeller : ")]
    public GameObject engelRampa;
    public GameObject engelKopru, engelKayanKopru, engelBosluk1, engelBosluk2, engelDik1, engelDik2, engelDik3, engelDik4, engelDik5, engelDik6,
        engelDinamit1, engelDinamit2, engelDinamit3, engelDinamit4, engelDuvar1, engelDuvar2, engelDuvar3, engelTestere1, engelTestere2, engelTestere3, engelTestere4, engelTestere5, engelLazer1;


    GameObject engel_Genel, kucult_Genel, buyut_Genel;

    List<int> engelList = new List<int>();
    List<int> kucultList = new List<int>();
    List<int> buyutList = new List<int>();

    int randomEngel, randomKucult, randomBuyut;

    void Start()
    {
        
        for (int n = 0; n < engelCesitSayi; n++)
        {
            engelList.Add(n);
        }
        for (int n = 0; n < kucultSayi; n++)
        {
            kucultList.Add(n);
        }
        for (int n = 0; n < buyutSayi; n++)
        {
            buyutList.Add(n);
        }


        int engelSayi = Random.Range(3, 6);

        switch (engelSayi)
        {
            case 2:
                engelPoz1 = 2;
                engelPoz2 = 4;
                yolUzunlugu = 7;
                ikiEngel();
                break;

            case 3:
                engelPoz1 = 2;
                engelPoz2 = 5;
                engelPoz3 = 8;
                yolUzunlugu = 11;
                ucEngel();
                break;

            case 4:
                engelPoz1 = 2;
                engelPoz2 = 5;
                engelPoz3 = 8;
                engelPoz4 = 11;
                yolUzunlugu = 14;
                dortEngel();
                break;

            case 5:
                engelPoz1 = 2;
                engelPoz2 = 5;
                engelPoz3 = 8;
                engelPoz4 = 11;
                engelPoz5 = 14;
                yolUzunlugu = 17;
                besEngel();
                break;

        }





    }



    void engelSecimi()
    {
        
        if (engelList.Count > 1)            //bu kod listeden seçtiği random sayıyı listeden çıkarıyor ve bir dahakine başka sayı seçmek zorunda kalıyor
        {
            int index = Random.Range(1, engelList.Count);    
            randomEngel = engelList[index];                            
            engelList.RemoveAt(index);                           
        }

        //Debug.Log("engel sayıları : " + engelList.Count + "   engel çeşidi : " + randomEngel);

        switch (randomEngel)
        {
            case 1:
                engel_Genel = engelRampa;
                break;
            case 2:
                engel_Genel = engelKopru;
                break;
            case 3:
                engel_Genel = engelBosluk1;
                break;
            case 4:
                engel_Genel = engelBosluk2;
                break;
            case 5:
                engel_Genel = engelDik1;
                break;
            case 6:
                engel_Genel = engelDik2;
                break;
            case 7:
                engel_Genel = engelDik3;
                break;
            case 8:
                engel_Genel = engelDik4;
                break;
            case 9:
                engel_Genel = engelDik5;
                break;
            case 10:
                engel_Genel = engelDik6;
                break;
            case 11:
                engel_Genel = engelDinamit1;
                break;
            case 12:
                engel_Genel = engelDinamit2;
                break;
            case 13:
                engel_Genel = engelDinamit3;
                break;
            case 14:
                engel_Genel = engelDinamit4;
                break;
            case 15:
                engel_Genel = engelDuvar1;
                break;
            case 16:
                engel_Genel = engelDuvar2;
                break;
            case 17:
                engel_Genel = engelDuvar3;
                break;
            case 18:
                engel_Genel = engelTestere1;
                break;
            case 19:
                engel_Genel = engelTestere2;
                break;
            case 20:
                engel_Genel = engelTestere3;
                break;
            case 21:
                engel_Genel = engelTestere4;
                break;
            case 22:
                engel_Genel = engelTestere5;
                break;
            case 23:
                engel_Genel = engelLazer1;
                break;
            case 24:
                engel_Genel = engelRampa;
                break;
            case 25:
                engel_Genel = engelKopru;
                break;
            case 26:
                engel_Genel = engelBosluk1;
                break;
            case 27:
                engel_Genel = engelBosluk2;
                break;
            case 28:
                engel_Genel = engelRampa;
                break;
            case 29:
                engel_Genel = engelKopru;
                break;
            case 30:
                engel_Genel = engelBosluk1;
                break;
            case 31:
                engel_Genel = engelBosluk2;
                break;
            case 32:
                engel_Genel = engelLazer1;
                break;
            case 33:
                engel_Genel = engelKayanKopru;
                break;
            case 34:
                engel_Genel = engelKayanKopru;
                break;
            case 35:
                engel_Genel = engelKayanKopru;
                break;




        }


    }


    void kucultSecim()
    {

        randomKucult = Random.Range(1, kucultList.Count);


        switch (randomKucult)
        {
            case 1:
                kucult_Genel = kucult1;
                break;
            case 2:
                kucult_Genel = kucult2;
                break;
            case 3:
                kucult_Genel = kucult3;
                break;
            case 4:
                kucult_Genel = kucult4;
                break;
            case 5:
                kucult_Genel = kucult5;
                break;
            case 6:
                kucult_Genel = kucult6;
                break;
            case 7:
                kucult_Genel = kucult7;
                break;
            
        }
    }

    void buyutSecim()
    {

        randomBuyut = Random.Range(1, buyutList.Count);

        switch (randomBuyut)
        {
            case 1:
                buyut_Genel = buyult1;
                break;
            case 2:
                buyut_Genel = buyult2;
                break;
            case 3:
                buyut_Genel = buyult3;
                break;
            case 4:
                buyut_Genel = buyult4;
                break;
            case 5:
                buyut_Genel = buyult5;
                break;
            case 6:
                buyut_Genel = buyult6;
                break;
            case 7:
                buyut_Genel = buyult7;
                break;
            case 8:
                buyut_Genel = buyult8;
                break;

        }
    }


    void ikiEngel()
    {
        for (int i = 0; i < yolUzunlugu; i++)
        {
            if (i == engelPoz1)
            {
                engelSecimi();

                kucultSecim();
                buyutSecim();

                kucult_Genel.SetActive(true);
                buyut_Genel.SetActive(true);
                GameObject m1 = Instantiate(kucult_Genel, new Vector3(0, 0, yolA + yiyecekEngelAciklik), Quaternion.identity);
                GameObject m2 = Instantiate(buyut_Genel, new Vector3(0, 0, yolA - yiyecekEngelAciklik), Quaternion.identity);


                engel_Genel.SetActive(true);
                GameObject y1 = Instantiate(engel_Genel, new Vector3(0, 0, yolA), Quaternion.identity);
                GameObject y2 = Instantiate(yol2, new Vector3(0, 0, 15 + yolB), Quaternion.identity);

                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;
                m1.transform.parent = klonParent.transform;
                m2.transform.parent = klonParent.transform;

                yolA = yolA + 30;
                yolB = yolB + 30;
            }


            if (i == engelPoz2)
            {
                engelSecimi();

                kucultSecim();
                buyutSecim();

                kucult_Genel.SetActive(true);
                buyut_Genel.SetActive(true);
                GameObject m1 = Instantiate(kucult_Genel, new Vector3(0, 0, yolB + 15 - yiyecekEngelAciklik), Quaternion.identity);
                GameObject m2 = Instantiate(buyut_Genel, new Vector3(0, 0, yolB + 15 + yiyecekEngelAciklik), Quaternion.identity);

                engel_Genel.SetActive(true);
                GameObject y1 = Instantiate(yol1, new Vector3(0, 0, 0 + yolA), Quaternion.identity);
                GameObject y2 = Instantiate(engel_Genel, new Vector3(0, 0, 15 + yolB), Quaternion.identity);



                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;
                m1.transform.parent = klonParent.transform;
                m2.transform.parent = klonParent.transform;

                yolA = yolA + 30;
                yolB = yolB + 30;
            }

            if (i != engelPoz1 && i != engelPoz2)
            {
                GameObject y1 = Instantiate(yol1, new Vector3(0, 0, 0 + yolA), Quaternion.identity);
                GameObject y2 = Instantiate(yol2, new Vector3(0, 0, 15 + yolB), Quaternion.identity);

                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;


                yolA = yolA + 30;
                yolB = yolB + 30;
            }



        }

        int oyunSonuZ = Mathf.Max(yolA - 15, yolB - 30) + 30;
        int oyunSonuBonusZ = Mathf.Max(yolA - 15, yolB - 30) + 295;
        oyunSonu.transform.position = new Vector3(0, 0, oyunSonuZ);
        oyunSonBonus.transform.position = new Vector3(0, 0, oyunSonuBonusZ);
    }





    void ucEngel()
    {
        for (int i = 0; i < yolUzunlugu; i++)
        {
            if (i == engelPoz1)
            {
                engelSecimi();

                kucultSecim();
                buyutSecim();

                kucult_Genel.SetActive(true);
                buyut_Genel.SetActive(true);
                GameObject m1 = Instantiate(kucult_Genel, new Vector3(0, 0, yolA + yiyecekEngelAciklik), Quaternion.identity);
                GameObject m2 = Instantiate(buyut_Genel, new Vector3(0, 0, yolA - yiyecekEngelAciklik), Quaternion.identity);

                engel_Genel.SetActive(true);
                GameObject y1 = Instantiate(engel_Genel, new Vector3(0, 0, yolA), Quaternion.identity);
                GameObject y2 = Instantiate(yol2, new Vector3(0, 0, 15 + yolB), Quaternion.identity);



                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;
                m1.transform.parent = klonParent.transform;
                m2.transform.parent = klonParent.transform;

                yolA = yolA + 30;
                yolB = yolB + 30;
            }


            if (i == engelPoz2)
            {
                engelSecimi();

                kucultSecim();
                buyutSecim();

                kucult_Genel.SetActive(true);
                buyut_Genel.SetActive(true);
                GameObject m1 = Instantiate(kucult_Genel, new Vector3(0, 0, yolB + 15 - yiyecekEngelAciklik), Quaternion.identity);
                GameObject m2 = Instantiate(buyut_Genel, new Vector3(0, 0, yolB + 15 + yiyecekEngelAciklik), Quaternion.identity);

                engel_Genel.SetActive(true);
                GameObject y1 = Instantiate(yol1, new Vector3(0, 0, 0 + yolA), Quaternion.identity);
                GameObject y2 = Instantiate(engel_Genel, new Vector3(0, 0, 15 + yolB), Quaternion.identity);


                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;
                m1.transform.parent = klonParent.transform;
                m2.transform.parent = klonParent.transform;

                yolA = yolA + 30;
                yolB = yolB + 30;
            }


            if (i == engelPoz3)
            {
                engelSecimi();

                kucultSecim();
                buyutSecim();


                kucult_Genel.SetActive(true);
                buyut_Genel.SetActive(true);
                GameObject m1 = Instantiate(kucult_Genel, new Vector3(0, 0, yolA - yiyecekEngelAciklik), Quaternion.identity);
                GameObject m2 = Instantiate(buyut_Genel, new Vector3(0, 0, yolA + yiyecekEngelAciklik), Quaternion.identity);

                engel_Genel.SetActive(true);
                GameObject y1 = Instantiate(engel_Genel, new Vector3(0, 0, yolA), Quaternion.identity);
                GameObject y2 = Instantiate(yol2, new Vector3(0, 0, 15 + yolB), Quaternion.identity);


                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;
                m1.transform.parent = klonParent.transform;
                m2.transform.parent = klonParent.transform;


                yolA = yolA + 30;
                yolB = yolB + 30;
            }


            if (i != engelPoz1 && i != engelPoz2 && i != engelPoz3)
            {
                GameObject y1 = Instantiate(yol1, new Vector3(0, 0, 0 + yolA), Quaternion.identity);
                GameObject y2 = Instantiate(yol2, new Vector3(0, 0, 15 + yolB), Quaternion.identity);


                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;



                yolA = yolA + 30;
                yolB = yolB + 30;
            }





        }


        int oyunSonuZ = Mathf.Max(yolA - 15, yolB - 30) + 30;
        int oyunSonuBonusZ = Mathf.Max(yolA - 15, yolB - 30) + 295;
        oyunSonu.transform.position = new Vector3(0, 0, oyunSonuZ);
        oyunSonBonus.transform.position = new Vector3(0, 0, oyunSonuBonusZ);
    }


    void dortEngel()
    {
        for (int i = 0; i < yolUzunlugu; i++)
        {
            if (i == engelPoz1)
            {
                engelSecimi();

                kucultSecim();
                buyutSecim();


                kucult_Genel.SetActive(true);
                buyut_Genel.SetActive(true);
                GameObject m1 = Instantiate(kucult_Genel, new Vector3(0, 0, yolA + yiyecekEngelAciklik), Quaternion.identity);
                GameObject m2 = Instantiate(buyut_Genel, new Vector3(0, 0, yolA - yiyecekEngelAciklik), Quaternion.identity);

                engel_Genel.SetActive(true);
                GameObject y1 = Instantiate(engel_Genel, new Vector3(0, 0, yolA), Quaternion.identity);
                GameObject y2 = Instantiate(yol2, new Vector3(0, 0, 15 + yolB), Quaternion.identity);


                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;
                m1.transform.parent = klonParent.transform;
                m2.transform.parent = klonParent.transform;


                yolA = yolA + 30;
                yolB = yolB + 30;
            }


            if (i == engelPoz2)
            {
                engelSecimi();

                kucultSecim();
                buyutSecim();


                kucult_Genel.SetActive(true);
                buyut_Genel.SetActive(true);
                GameObject m1 = Instantiate(kucult_Genel, new Vector3(0, 0, yolB + 15 - yiyecekEngelAciklik), Quaternion.identity);
                GameObject m2 = Instantiate(buyut_Genel, new Vector3(0, 0, yolB + 15 + yiyecekEngelAciklik), Quaternion.identity);

                engel_Genel.SetActive(true);
                GameObject y1 = Instantiate(yol1, new Vector3(0, 0, 0 + yolA), Quaternion.identity);
                GameObject y2 = Instantiate(engel_Genel, new Vector3(0, 0, 15 + yolB), Quaternion.identity);

                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;
                m1.transform.parent = klonParent.transform;
                m2.transform.parent = klonParent.transform;

                yolA = yolA + 30;
                yolB = yolB + 30;
            }


            if (i == engelPoz3)
            {
                engelSecimi();

                kucultSecim();
                buyutSecim();


                kucult_Genel.SetActive(true);
                buyut_Genel.SetActive(true);
                GameObject m1 = Instantiate(kucult_Genel, new Vector3(0, 0, yolA - yiyecekEngelAciklik), Quaternion.identity);
                GameObject m2 = Instantiate(buyut_Genel, new Vector3(0, 0, yolA + yiyecekEngelAciklik), Quaternion.identity);

                engel_Genel.SetActive(true);
                GameObject y1 = Instantiate(engel_Genel, new Vector3(0, 0, yolA), Quaternion.identity);
                GameObject y2 = Instantiate(yol2, new Vector3(0, 0, 15 + yolB), Quaternion.identity);


                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;
                m1.transform.parent = klonParent.transform;
                m2.transform.parent = klonParent.transform;

                yolA = yolA + 30;
                yolB = yolB + 30;
            }

            if (i == engelPoz4)
            {
                engelSecimi();

                kucultSecim();
                buyutSecim();


                kucult_Genel.SetActive(true);
                buyut_Genel.SetActive(true);
                GameObject m1 = Instantiate(kucult_Genel, new Vector3(0, 0, yolB + 15 - yiyecekEngelAciklik), Quaternion.identity);
                GameObject m2 = Instantiate(buyut_Genel, new Vector3(0, 0, yolB + 15 + yiyecekEngelAciklik), Quaternion.identity);

                engel_Genel.SetActive(true);
                GameObject y1 = Instantiate(yol1, new Vector3(0, 0, 0 + yolA), Quaternion.identity);
                GameObject y2 = Instantiate(engel_Genel, new Vector3(0, 0, 15 + yolB), Quaternion.identity);

                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;
                m1.transform.parent = klonParent.transform;
                m2.transform.parent = klonParent.transform;


                yolA = yolA + 30;
                yolB = yolB + 30;
            }

            

            if (i != engelPoz1 && i != engelPoz2 && i != engelPoz3 && i != engelPoz4)
            {
                GameObject y1 = Instantiate(yol1, new Vector3(0, 0, 0 + yolA), Quaternion.identity);
                GameObject y2 = Instantiate(yol2, new Vector3(0, 0, 15 + yolB), Quaternion.identity);


                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;


                yolA = yolA + 30;
                yolB = yolB + 30;
            }





        }


        int oyunSonuZ = Mathf.Max(yolA - 15, yolB - 30) + 30;
        int oyunSonuBonusZ = Mathf.Max(yolA - 15, yolB - 30) + 295;
        oyunSonu.transform.position = new Vector3(0, 0, oyunSonuZ);
        oyunSonBonus.transform.position = new Vector3(0, 0, oyunSonuBonusZ);
    }



     void besEngel()
    {
        for (int i = 0; i < yolUzunlugu; i++)
        {
            if (i == engelPoz1)
            {
                engelSecimi();

                kucultSecim();
                buyutSecim();


                kucult_Genel.SetActive(true);
                buyut_Genel.SetActive(true);
                GameObject m1 = Instantiate(kucult_Genel, new Vector3(0, 0, yolA + yiyecekEngelAciklik), Quaternion.identity);
                GameObject m2 = Instantiate(buyut_Genel, new Vector3(0, 0, yolA - yiyecekEngelAciklik), Quaternion.identity);


                engel_Genel.SetActive(true);
                GameObject y1 = Instantiate(engel_Genel, new Vector3(0, 0, yolA), Quaternion.identity);
                GameObject y2 = Instantiate(yol2, new Vector3(0, 0, 15 + yolB), Quaternion.identity);


                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;
                m1.transform.parent = klonParent.transform;
                m2.transform.parent = klonParent.transform;

                yolA = yolA + 30;
                yolB = yolB + 30;
            }


            if (i == engelPoz2)
            {
                engelSecimi();

                kucultSecim();
                buyutSecim();


                kucult_Genel.SetActive(true);
                buyut_Genel.SetActive(true);
                GameObject m1 = Instantiate(kucult_Genel, new Vector3(0, 0, yolB + 15 - yiyecekEngelAciklik), Quaternion.identity);
                GameObject m2 = Instantiate(buyut_Genel, new Vector3(0, 0, yolB + 15 + yiyecekEngelAciklik), Quaternion.identity);


                engel_Genel.SetActive(true);
                GameObject y1 = Instantiate(yol1, new Vector3(0, 0, 0 + yolA), Quaternion.identity);
                GameObject y2 = Instantiate(engel_Genel, new Vector3(0, 0, 15 + yolB), Quaternion.identity);

                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;
                m1.transform.parent = klonParent.transform;
                m2.transform.parent = klonParent.transform;


                yolA = yolA + 30;
                yolB = yolB + 30;
            }


            if (i == engelPoz3)
            {
                engelSecimi();

                kucultSecim();
                buyutSecim();


                kucult_Genel.SetActive(true);
                buyut_Genel.SetActive(true);
                GameObject m1 = Instantiate(kucult_Genel, new Vector3(0, 0, yolA - yiyecekEngelAciklik), Quaternion.identity);
                GameObject m2 = Instantiate(buyut_Genel, new Vector3(0, 0, yolA + yiyecekEngelAciklik), Quaternion.identity);



                engel_Genel.SetActive(true);
                GameObject y1 = Instantiate(engel_Genel, new Vector3(0, 0, yolA), Quaternion.identity);
                GameObject y2 = Instantiate(yol2, new Vector3(0, 0, 15 + yolB), Quaternion.identity);


                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;
                m1.transform.parent = klonParent.transform;
                m2.transform.parent = klonParent.transform;

                yolA = yolA + 30;
                yolB = yolB + 30;
            }

            if (i == engelPoz4)
            {
                engelSecimi();

                kucultSecim();
                buyutSecim();



                kucult_Genel.SetActive(true);
                buyut_Genel.SetActive(true);
                GameObject m1 = Instantiate(kucult_Genel, new Vector3(0, 0, yolB + 15 - yiyecekEngelAciklik), Quaternion.identity);
                GameObject m2 = Instantiate(buyut_Genel, new Vector3(0, 0, yolB + 15 + yiyecekEngelAciklik), Quaternion.identity);


                engel_Genel.SetActive(true);
                GameObject y1 = Instantiate(yol1, new Vector3(0, 0, 0 + yolA), Quaternion.identity);
                GameObject y2 = Instantiate(engel_Genel, new Vector3(0, 0, 15 + yolB), Quaternion.identity);

                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;
                m1.transform.parent = klonParent.transform;
                m2.transform.parent = klonParent.transform;


                yolA = yolA + 30;
                yolB = yolB + 30;
            }


            if (i == engelPoz5)
            {
                engelSecimi();

                kucultSecim();
                buyutSecim();


                kucult_Genel.SetActive(true);
                buyut_Genel.SetActive(true);
                GameObject m1 = Instantiate(kucult_Genel, new Vector3(0, 0, yolA - yiyecekEngelAciklik), Quaternion.identity);
                GameObject m2 = Instantiate(buyut_Genel, new Vector3(0, 0, yolA + yiyecekEngelAciklik), Quaternion.identity);



                engel_Genel.SetActive(true);
                GameObject y1 = Instantiate(engel_Genel, new Vector3(0, 0, yolA), Quaternion.identity);
                GameObject y2 = Instantiate(yol2, new Vector3(0, 0, 15 + yolB), Quaternion.identity);


                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;
                m1.transform.parent = klonParent.transform;
                m2.transform.parent = klonParent.transform;


                yolA = yolA + 30;
                yolB = yolB + 30;
            }

            if (i != engelPoz1 && i != engelPoz2 && i != engelPoz3 && i != engelPoz4 && i != engelPoz5)
            {
                GameObject y1 = Instantiate(yol1, new Vector3(0, 0, 0 + yolA), Quaternion.identity);
                GameObject y2 = Instantiate(yol2, new Vector3(0, 0, 15 + yolB), Quaternion.identity);


                GameObject klonParent = GameObject.FindGameObjectWithTag("klonParent");
                y1.transform.parent = klonParent.transform;
                y2.transform.parent = klonParent.transform;


                yolA = yolA + 30;
                yolB = yolB + 30;
            }





        }


        int oyunSonuZ = Mathf.Max(yolA - 15, yolB - 30) + 30;
        int oyunSonuBonusZ = Mathf.Max(yolA - 15, yolB - 30) + 295;
        oyunSonu.transform.position = new Vector3(0, 0, oyunSonuZ);
        oyunSonBonus.transform.position = new Vector3(0, 0, oyunSonuBonusZ);
    }
}
