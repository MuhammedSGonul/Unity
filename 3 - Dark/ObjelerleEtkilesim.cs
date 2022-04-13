using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjelerleEtkilesim : MonoBehaviour
{
    
    public Transform kamera;
    public Transform karakter;


   
    
    void Update()
    {
        Etkilesim();

        
    }

    void Etkilesim()
    {
        switch (ObjeAlgilama.etkilesimNo)
        {
            case 1:

                break;

            case 2:

                break;

            case 3: //Koridora Geciyor
                karakter.transform.position = new Vector3(-46.23f, -0.7084919f, 0);
                kamera.transform.position = new Vector3(-50.5f, 0, -10f);
                break;

            case 4: //Yatak Odasına Geciyor
                karakter.transform.position = new Vector3(-28.93f, -0.7084919f, 0);
                kamera.transform.position = new Vector3(-20.7f, 0, -10f);
                break;

            case 5:

                break;

            case 6:

                break;

        }
    }

}
