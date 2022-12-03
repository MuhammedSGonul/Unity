using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterSecim : MonoBehaviour
{

    public GameObject K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15;
    public GameObject K2SatinAlmaMenu, K3SatinAlmaMenu, K4SatinAlmaMenu, K5SatinAlmaMenu, K6SatinAlmaMenu, K7SatinAlmaMenu, K8SatinAlmaMenu,
        K9SatinAlmaMenu, K10SatinAlmaMenu, K11SatinAlmaMenu, K12SatinAlmaMenu, K13SatinAlmaMenu, K14SatinAlmaMenu, K15SatinAlmaMenu;

    private int karakterNo = 1;
    int para;


    int K2SatinAlindi, K3SatinAlindi, K4SatinAlindi, K5SatinAlindi, K6SatinAlindi, K7SatinAlindi, K8SatinAlindi, K9SatinAlindi, K10SatinAlindi, K11SatinAlindi,
        K12SatinAlindi, K13SatinAlindi, K14SatinAlindi, K15SatinAlindi;



    //PlayerPrefs.SetInt("music", 1);
    //PlayerPrefs.GetInt ("music");
    void Awake()
    {
        karakterNo = PlayerPrefs.GetInt("secilenKarakterNo");

    }


    public void KarakterArttir()
    {
        karakterNo++;
    }


    public void KarakterAzalt()
    {
        karakterNo--;
    }

    public void Onayla()
    {

    }


    public void anaMenuyeDon()
    {
        K1.SetActive(false);
        K2.SetActive(false);
        K3.SetActive(false);
        K4.SetActive(false);
        K5.SetActive(false);
        K6.SetActive(false);
        K7.SetActive(false);
        K8.SetActive(false);
        K9.SetActive(false);
        K10.SetActive(false);
        K11.SetActive(false);
        K12.SetActive(false);
        K13.SetActive(false);
        K14.SetActive(false);
        K15.SetActive(false);
    }


    void Update()
    {
        karakterNo = PlayerPrefs.GetInt("karakterNo");

        para = PlayerPrefs.GetInt("coinDegeri");
        K2SatinAlindi = PlayerPrefs.GetInt("K2SatinAlindi");
        K3SatinAlindi = PlayerPrefs.GetInt("K3SatinAlindi");
        K4SatinAlindi = PlayerPrefs.GetInt("K4SatinAlindi");
        K5SatinAlindi = PlayerPrefs.GetInt("K5SatinAlindi");
        K6SatinAlindi = PlayerPrefs.GetInt("K6SatinAlindi");
        K7SatinAlindi = PlayerPrefs.GetInt("K7SatinAlindi");
        K8SatinAlindi = PlayerPrefs.GetInt("K8SatinAlindi");
        K9SatinAlindi = PlayerPrefs.GetInt("K9SatinAlindi");
        K10SatinAlindi = PlayerPrefs.GetInt("K10SatinAlindi");
        K11SatinAlindi = PlayerPrefs.GetInt("K11SatinAlindi");
        K12SatinAlindi = PlayerPrefs.GetInt("K12SatinAlindi");
        K13SatinAlindi = PlayerPrefs.GetInt("K13SatinAlindi");
        K14SatinAlindi = PlayerPrefs.GetInt("K14SatinAlindi");
        K15SatinAlindi = PlayerPrefs.GetInt("K15SatinAlindi");



        if (karakterNo < 1)
        {
            karakterNo = 1;
        }
        if (karakterNo > 15)
        {
            karakterNo = 15;
        }




        switch (karakterNo)
        {
            case 1:
                K1.SetActive(true);
                K2.SetActive(false);
                K3.SetActive(false);        //cost free
                K4.SetActive(false);
                K5.SetActive(false);
                K6.SetActive(false);
                K7.SetActive(false);
                K8.SetActive(false);
                K9.SetActive(false);
                K10.SetActive(false);
                K11.SetActive(false);
                K12.SetActive(false);
                K13.SetActive(false);
                K14.SetActive(false);
                K15.SetActive(false);
                PlayerPrefs.SetInt("secilenKarakterNo", karakterNo);
                break;
            case 2:
                K1.SetActive(false);
                K2.SetActive(true);
                K3.SetActive(false);        //cost 500
                K4.SetActive(false);
                K5.SetActive(false);
                K6.SetActive(false);
                K7.SetActive(false);
                K8.SetActive(false);
                K9.SetActive(false);
                K10.SetActive(false);
                K11.SetActive(false);
                K12.SetActive(false);
                K13.SetActive(false);
                K14.SetActive(false);
                K15.SetActive(false);

                if (K2SatinAlindi == 1)
                {
                    PlayerPrefs.SetInt("secilenKarakterNo", karakterNo);
                    K2SatinAlmaMenu.SetActive(false);
                }
                break;
            case 3:
                K1.SetActive(false);
                K2.SetActive(false);
                K3.SetActive(true);         //cost 500
                K4.SetActive(false);
                K5.SetActive(false);
                K6.SetActive(false);
                K7.SetActive(false);
                K8.SetActive(false);
                K9.SetActive(false);
                K10.SetActive(false);
                K11.SetActive(false);
                K12.SetActive(false);
                K13.SetActive(false);
                K14.SetActive(false);
                K15.SetActive(false);

                if (K3SatinAlindi == 1)
                {
                    PlayerPrefs.SetInt("secilenKarakterNo", karakterNo);
                    K3SatinAlmaMenu.SetActive(false);
                }
                break;
            case 4:
                K1.SetActive(false);
                K2.SetActive(false);
                K3.SetActive(false);       
                K4.SetActive(true);             //cost 500
                K5.SetActive(false);
                K6.SetActive(false);
                K7.SetActive(false);
                K8.SetActive(false);
                K9.SetActive(false);
                K10.SetActive(false);
                K11.SetActive(false);
                K12.SetActive(false);
                K13.SetActive(false);
                K14.SetActive(false);
                K15.SetActive(false);

                if (K4SatinAlindi == 1)
                {
                    PlayerPrefs.SetInt("secilenKarakterNo", karakterNo);
                    K4SatinAlmaMenu.SetActive(false);
                }
                break;

            case 5:
                K1.SetActive(false);
                K2.SetActive(false);
                K3.SetActive(false);        
                K4.SetActive(false);
                K5.SetActive(true);         //cost 1250
                K6.SetActive(false);
                K7.SetActive(false);
                K8.SetActive(false);
                K9.SetActive(false);
                K10.SetActive(false);
                K11.SetActive(false);
                K12.SetActive(false);
                K13.SetActive(false);
                K14.SetActive(false);
                K15.SetActive(false);

                if (K5SatinAlindi == 1)
                {
                    PlayerPrefs.SetInt("secilenKarakterNo", karakterNo);
                    K5SatinAlmaMenu.SetActive(false);
                }
                break;

            case 6:
                K1.SetActive(false);
                K2.SetActive(false);
                K3.SetActive(false);
                K4.SetActive(false);
                K5.SetActive(false);         //cost 1250
                K6.SetActive(true);
                K7.SetActive(false);
                K8.SetActive(false);
                K9.SetActive(false);
                K10.SetActive(false);
                K11.SetActive(false);
                K12.SetActive(false);
                K13.SetActive(false);
                K14.SetActive(false);
                K15.SetActive(false);

                if (K6SatinAlindi == 1)
                {
                    PlayerPrefs.SetInt("secilenKarakterNo", karakterNo);
                    K6SatinAlmaMenu.SetActive(false);
                }
                break;

            case 7:
                K1.SetActive(false);
                K2.SetActive(false);
                K3.SetActive(false);
                K4.SetActive(false);
                K5.SetActive(false);         //cost 1250
                K6.SetActive(false);
                K7.SetActive(true);
                K8.SetActive(false);
                K9.SetActive(false);
                K10.SetActive(false);
                K11.SetActive(false);
                K12.SetActive(false);
                K13.SetActive(false);
                K14.SetActive(false);
                K15.SetActive(false);

                if (K7SatinAlindi == 1)
                {
                    PlayerPrefs.SetInt("secilenKarakterNo", karakterNo);
                    K7SatinAlmaMenu.SetActive(false);
                }
                break;

            case 8:
                K1.SetActive(false);
                K2.SetActive(false);
                K3.SetActive(false);
                K4.SetActive(false);
                K5.SetActive(false);         //cost 1250
                K6.SetActive(false);
                K7.SetActive(false);
                K8.SetActive(true);
                K9.SetActive(false);
                K10.SetActive(false);
                K11.SetActive(false);
                K12.SetActive(false);
                K13.SetActive(false);
                K14.SetActive(false);
                K15.SetActive(false);

                if (K8SatinAlindi == 1)
                {
                    PlayerPrefs.SetInt("secilenKarakterNo", karakterNo);
                    K8SatinAlmaMenu.SetActive(false);
                }
                break;

            case 9:
                K1.SetActive(false);
                K2.SetActive(false);
                K3.SetActive(false);
                K4.SetActive(false);
                K5.SetActive(false);         //2k
                K6.SetActive(false);
                K7.SetActive(false);
                K8.SetActive(false);
                K9.SetActive(true);
                K10.SetActive(false);
                K11.SetActive(false);
                K12.SetActive(false);
                K13.SetActive(false);
                K14.SetActive(false);
                K15.SetActive(false);

                if (K9SatinAlindi == 1)
                {
                    PlayerPrefs.SetInt("secilenKarakterNo", karakterNo);
                    K9SatinAlmaMenu.SetActive(false);
                }
                break;

            case 10:
                K1.SetActive(false);
                K2.SetActive(false);
                K3.SetActive(false);
                K4.SetActive(false);
                K5.SetActive(false);         //2k
                K6.SetActive(false);
                K7.SetActive(false);
                K8.SetActive(false);
                K9.SetActive(false);
                K10.SetActive(true);
                K11.SetActive(false);
                K12.SetActive(false);
                K13.SetActive(false);
                K14.SetActive(false);
                K15.SetActive(false);

                if (K10SatinAlindi == 1)
                {
                    PlayerPrefs.SetInt("secilenKarakterNo", karakterNo);
                    K10SatinAlmaMenu.SetActive(false);
                }
                break;

            case 11:
                K1.SetActive(false);
                K2.SetActive(false);
                K3.SetActive(false);
                K4.SetActive(false);
                K5.SetActive(false);         //2k
                K6.SetActive(false);
                K7.SetActive(false);
                K8.SetActive(false);
                K9.SetActive(false);
                K10.SetActive(false);
                K11.SetActive(true);
                K12.SetActive(false);
                K13.SetActive(false);
                K14.SetActive(false);
                K15.SetActive(false);

                if (K11SatinAlindi == 1)
                {
                    PlayerPrefs.SetInt("secilenKarakterNo", karakterNo);
                    K11SatinAlmaMenu.SetActive(false);
                }
                break;

            case 12:
                K1.SetActive(false);
                K2.SetActive(false);
                K3.SetActive(false);
                K4.SetActive(false);
                K5.SetActive(false);         //2k
                K6.SetActive(false);
                K7.SetActive(false);
                K8.SetActive(false);
                K9.SetActive(false);
                K10.SetActive(false);
                K11.SetActive(false);
                K12.SetActive(true);
                K13.SetActive(false);
                K14.SetActive(false);
                K15.SetActive(false);

                if (K12SatinAlindi == 1)
                {
                    PlayerPrefs.SetInt("secilenKarakterNo", karakterNo);
                    K12SatinAlmaMenu.SetActive(false);
                }
                break;

            case 13:
                K1.SetActive(false);
                K2.SetActive(false);
                K3.SetActive(false);
                K4.SetActive(false);
                K5.SetActive(false);         //2k
                K6.SetActive(false);
                K7.SetActive(false);
                K8.SetActive(false);
                K9.SetActive(false);
                K10.SetActive(false);
                K11.SetActive(false);
                K12.SetActive(false);
                K13.SetActive(true);
                K14.SetActive(false);
                K15.SetActive(false);

                if (K13SatinAlindi == 1)
                {
                    PlayerPrefs.SetInt("secilenKarakterNo", karakterNo);
                    K13SatinAlmaMenu.SetActive(false);
                }
                break;

            case 14:
                K1.SetActive(false);
                K2.SetActive(false);
                K3.SetActive(false);
                K4.SetActive(false);
                K5.SetActive(false);         //cost 2k
                K6.SetActive(false);
                K7.SetActive(false);
                K8.SetActive(false);
                K9.SetActive(false);
                K10.SetActive(false);
                K11.SetActive(false);
                K12.SetActive(false);
                K13.SetActive(false);
                K14.SetActive(true);
                K15.SetActive(false);

                if (K14SatinAlindi == 1)
                {
                    PlayerPrefs.SetInt("secilenKarakterNo", karakterNo);
                    K14SatinAlmaMenu.SetActive(false);
                }
                break;

            case 15:
                K1.SetActive(false);
                K2.SetActive(false);
                K3.SetActive(false);
                K4.SetActive(false);
                K5.SetActive(false);         //cost 2k
                K6.SetActive(false);
                K7.SetActive(false);
                K8.SetActive(false);
                K9.SetActive(false);
                K10.SetActive(false);
                K11.SetActive(false);
                K12.SetActive(false);
                K13.SetActive(false);
                K14.SetActive(false);
                K15.SetActive(true);

                if (K15SatinAlindi == 1)
                {
                    PlayerPrefs.SetInt("secilenKarakterNo", karakterNo);
                    K15SatinAlmaMenu.SetActive(false);
                }
                break;

        }



    }







    public void K2SatinAlma()
    {
        if (para >= 500)
        {
            K2SatinAlindi = 1;
            para = para - 500;
            K2SatinAlmaMenu.SetActive(false);
            PlayerPrefs.SetInt("coinDegeri", para);
            PlayerPrefs.SetInt("K2SatinAlindi", 1);
        }
    }

    public void K3SatinAlma()
    {
        if (para >= 500)
        {
            K3SatinAlindi = 1;
            para = para - 500;
            K3SatinAlmaMenu.SetActive(false);
            PlayerPrefs.SetInt("coinDegeri", para);
            PlayerPrefs.SetInt("K3SatinAlindi", 1);
        }
    }

    public void K4SatinAlma()
    {
        if (para >= 500)
        {
            K4SatinAlindi = 1;
            para = para - 500;
            K4SatinAlmaMenu.SetActive(false);
            PlayerPrefs.SetInt("coinDegeri", para);
            PlayerPrefs.SetInt("K4SatinAlindi", 1);
        }
    }


    public void K5SatinAlma()
    {
        if (para >= 1250)
        {
            K5SatinAlindi = 1;
            para = para - 1250;
            K5SatinAlmaMenu.SetActive(false);
            PlayerPrefs.SetInt("coinDegeri", para);
            PlayerPrefs.SetInt("K5SatinAlindi", 1);
        }
    }


    public void K6SatinAlma()
    {
        if (para >= 1250)
        {
            K6SatinAlindi = 1;
            para = para - 1250;
            K6SatinAlmaMenu.SetActive(false);
            PlayerPrefs.SetInt("coinDegeri", para);
            PlayerPrefs.SetInt("K6SatinAlindi", 1);
        }
    }


    public void K7SatinAlma()
    {
        if (para >= 1250)
        {
            K7SatinAlindi = 1;
            para = para - 1250;
            K7SatinAlmaMenu.SetActive(false);
            PlayerPrefs.SetInt("coinDegeri", para);
            PlayerPrefs.SetInt("K7SatinAlindi", 1);
        }
    }


    public void K8SatinAlma()
    {
        if (para >= 1250)
        {
            K8SatinAlindi = 1;
            para = para - 1250;
            K8SatinAlmaMenu.SetActive(false);
            PlayerPrefs.SetInt("coinDegeri", para);
            PlayerPrefs.SetInt("K8SatinAlindi", 1);
        }
    }


    public void K9SatinAlma()
    {
        if (para >= 2000)
        {
            K9SatinAlindi = 1;
            para = para - 2000;
            K9SatinAlmaMenu.SetActive(false);
            PlayerPrefs.SetInt("coinDegeri", para);
            PlayerPrefs.SetInt("K9SatinAlindi", 1);
        }
    }


    public void K10SatinAlma()
    {
        if (para >= 2000)
        {
            K10SatinAlindi = 1;
            para = para - 2000;
            K10SatinAlmaMenu.SetActive(false);
            PlayerPrefs.SetInt("coinDegeri", para);
            PlayerPrefs.SetInt("K10SatinAlindi", 1);
        }
    }


    public void K11SatinAlma()
    {
        if (para >= 2000)
        {
            K11SatinAlindi = 1;
            para = para - 2000;
            K11SatinAlmaMenu.SetActive(false);
            PlayerPrefs.SetInt("coinDegeri", para);
            PlayerPrefs.SetInt("K11SatinAlindi", 1);
        }
    }


    public void K12SatinAlma()
    {
        if (para >= 2000)
        {
            K12SatinAlindi = 1;
            para = para - 2000;
            K12SatinAlmaMenu.SetActive(false);
            PlayerPrefs.SetInt("coinDegeri", para);
            PlayerPrefs.SetInt("K12SatinAlindi", 1);
        }
    }


    public void K13SatinAlma()
    {
        if (para >= 2000)
        {
            K13SatinAlindi = 1;
            para = para - 2000;
            K13SatinAlmaMenu.SetActive(false);
            PlayerPrefs.SetInt("coinDegeri", para);
            PlayerPrefs.SetInt("K13SatinAlindi", 1);
        }
    }


    public void K14SatinAlma()
    {
        if (para >= 2000)
        {
            K14SatinAlindi = 1;
            para = para - 2000;
            K14SatinAlmaMenu.SetActive(false);
            PlayerPrefs.SetInt("coinDegeri", para);
            PlayerPrefs.SetInt("K14SatinAlindi", 1);
        }
    }


    public void K15SatinAlma()
    {
        if (para >= 2000)
        {
            K15SatinAlindi = 1;
            para = para - 2000;
            K15SatinAlmaMenu.SetActive(false);
            PlayerPrefs.SetInt("coinDegeri", para);
            PlayerPrefs.SetInt("K15SatinAlindi", 1);
        }
    }




}
