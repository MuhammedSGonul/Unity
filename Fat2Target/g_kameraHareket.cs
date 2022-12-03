using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g_kameraHareket : MonoBehaviour
{
    float hedefX, hedefZ, hedefY,hedefRotX, hedefRotY;
    int adim = 0;
    public static bool kameraHedefeGitti = false;

    void Start()
    {

    }

    void Update()
    {
        
        if (g_oyuncuYonetici.oyuncuFirlatmaDuzen == true && g_oyuncuYonetici.oyuncuHareketKilit == true && g_oyuncuYonetici.oyuncuRotasyonKilit == false && adim == 0)
        {
            hedefX = this.gameObject.transform.position.x + 10;
            hedefZ = this.gameObject.transform.position.z + 10;
            hedefRotX = this.gameObject.transform.rotation.x + 15;
            hedefRotY = this.gameObject.transform.rotation.y - 20;
            adim = 1;
        }

        if (g_oyuncuYonetici.oyuncuHareketKilit == true && g_oyuncuYonetici.oyuncuRotasyonKilit == false && adim == 1)
        {
            this.gameObject.GetComponent<Animator>().enabled = false;
            this.gameObject.transform.rotation = Quaternion.Lerp(this.gameObject.transform.rotation, Quaternion.Euler(hedefRotX, hedefRotY, 0), Time.deltaTime * 5f);
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, new Vector3(hedefX, transform.position.y, hedefZ), Time.deltaTime * 100 * 0.1f);
        }

        if(g_oyuncuYonetici.oyuncuDusmanaFirlatildi == true && adim == 1)
        {
            hedefX = this.gameObject.transform.position.x;
            hedefY = this.gameObject.transform.position.y + 10;
            hedefZ = this.gameObject.transform.position.z + 45;
            hedefRotX = this.gameObject.transform.rotation.x;
            hedefRotY = this.gameObject.transform.rotation.y;
            adim = 2;
        }

        if (g_oyuncuYonetici.oyuncuBonusaGecti == true && adim ==2)
        {
            //this.gameObject.transform.rotation = Quaternion.Lerp(this.gameObject.transform.rotation, Quaternion.Euler(hedefRotX, hedefRotY, 0), Time.deltaTime * 5f);
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, new Vector3(hedefX, hedefY, hedefZ), Time.deltaTime * 100 * 0.8f);
            if (this.gameObject.transform.position.z == hedefZ)
            {
                kameraHedefeGitti = true;
                adim = 3;
            }

        }

        if(g_oyuncuYonetici.oyuncuBonusaFirlatildi == true && adim == 3)
        {
            Vector3 oyuncuPoz = GameObject.FindGameObjectWithTag("oyuncu").transform.position;

            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, oyuncuPoz.z - 25);
        }
        

    }
}
