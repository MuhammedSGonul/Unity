using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g_kopru : MonoBehaviour
{
    public GameObject kopruIlk, kopruSon;
    bool butonaBasildi = false;
    void Update()
    {
             
        if(butonaBasildi == true)
        {
            kopruIlk.transform.rotation = Quaternion.Lerp(kopruIlk.transform.rotation, Quaternion.Euler(0, kopruIlk.transform.rotation.y, 0), 0.1f * Time.deltaTime * 100);
            kopruSon.transform.rotation = Quaternion.Lerp(kopruSon.transform.rotation, Quaternion.Euler(180, kopruSon.transform.rotation.y, 0), 0.1f * Time.deltaTime * 100);
        }
            

    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "oyuncu")
        {
            butonaBasildi = true;
        }
    }

}
