using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g_engel : MonoBehaviour
{
    GameObject engel;
    public float engelHareketHizi = 0.02f;
    public float beklemeSuresi = 2f;

    int engelKilit = 0;
    float zaman;
    

    

    void Update()
    {
        

        if (engelKilit == 0)
        {
            zaman = 0;
            engelYukari();
        }
        
        if(engelKilit == 1)
        {
            zaman += Time.deltaTime;

            if(zaman > beklemeSuresi)
            {
                engelKilit = 2;
            }
        }


        if(engelKilit == 2)
        {
            zaman = 0;
            engelAsagi();
        }


        if (engelKilit == 3)
        {
            zaman += Time.deltaTime;

            if (zaman > beklemeSuresi)
            {
                engelKilit = 0;
            }
        }

    }



    void engelYukari()
    {
        //Debug.Log("yukarı");


        
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * 100 * engelHareketHizi, transform.position.z);
        
        
        if (transform.position.y > 1.5f)
        {          
            transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
    
            engelKilit = 1;
        }

    }

    void engelAsagi()
    {
        //Debug.Log("aşağı");

        
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * 100 * engelHareketHizi, transform.position.z);
        

        if (transform.position.y < -0.5f)
        {           
            transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);            
            engelKilit = 3;
        }
    }


   
    

}
