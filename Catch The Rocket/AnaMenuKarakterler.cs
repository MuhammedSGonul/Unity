using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaMenuKarakterler : MonoBehaviour
{
    public GameObject K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15;

    int karakterNo = 1;
    int ilkDefaKarakter;

    void Start()
    {
       
        
    }

    public void karakterMenuyeGit()
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

        karakterNo = PlayerPrefs.GetInt("secilenKarakterNo");


        switch (karakterNo)
        {

            case 0:
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

                break;

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

                break;
        }

    }
}
