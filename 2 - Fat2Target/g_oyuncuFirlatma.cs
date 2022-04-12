using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g_oyuncuFirlatma : MonoBehaviour
{
    Transform oyuncuTransform;
    Rigidbody oyuncuRb;
    public Transform dusman;

    //float zaman = 0, dikeyHiz, yatayHiz;
    float dikeyHizB, yatayHizB;     //eğik atış değişkenleri
    float yercekimiKatsayisi = 60.0f;

    float firlatmaGucu;
    GameObject powerBar;


    void Start()
    {
        oyuncuTransform = this.gameObject.GetComponent<Transform>();
        oyuncuRb = this.gameObject.GetComponent<Rigidbody>();
    }

    

    public void oyuncuyuDusmanaFirlat()
    {
        float aradakiMesafe = dusman.transform.position.z - oyuncuTransform.transform.position.z;

        atisDegerleriniHesapla(20, 15, aradakiMesafe);
        oyuncuRb.velocity = new Vector3(0, dikeyHizB, yatayHizB);
    }
    public void oyuncuBonusFirlatma()
    {
        oyuncuRb.velocity = new Vector3(0, firlatmaGucu * 1 / 4, firlatmaGucu / 2);
        g_oyuncuYonetici.oyuncuBonusaFirlatildi = true;
    }

    void Update()
    {

        


        if (g_oyuncuYonetici.oyuncuFirlatmaDuzen == true && g_oyuncuYonetici.oyuncuHareketKilit == true && g_oyuncuYonetici.oyuncuDusmanaFirlatildi == false)       //finish cizgisinden sonra x eksenini 0' a çekmek için yapılan düzeltme
        {
            float duzenlemeNoktasiZ = GameObject.FindGameObjectWithTag("oyuncuFirlatmaNokta").GetComponent<Transform>().position.z;

            oyuncuTransform.transform.rotation = Quaternion.Lerp(oyuncuTransform.transform.rotation, Quaternion.Euler(0, 0, 0), 1);
            oyuncuTransform.transform.position = Vector3.MoveTowards(oyuncuTransform.transform.position, new Vector3(0, transform.position.y, duzenlemeNoktasiZ), Time.deltaTime * 7f);          //fırlatma için hizaya geliyor
        }



        if (g_oyunYoneticisi.powerBarPanelAktif == true && Input.GetMouseButtonDown(0))
        {
            powerBar = GameObject.FindGameObjectWithTag("powerBarIbre");
            firlatmaGucu = 180 - powerBar.transform.eulerAngles.z;
            //Debug.Log(firlatmaGucu);
            g_oyunYoneticisi.powerBarPanelAktif = false;
        }




        /*
        if (g_oyuncuHareket.firlatmaAsamasi == true)
        {
            zaman += Time.deltaTime;

            dikeyHiz = dikeyHizB - yercekimiKatsayisi * zaman;
            yatayHiz = yatayHizB;

            oyuncuTransform.transform.Rotate(new Vector3(20, 0, 0) * Time.deltaTime);

            /*        
             *        bu şekilde trajectory ye göre bir rotation olacak ama başlangıçta çok yapay olduğu için ben bunu kullanmayı tercih etmedim bir de max noktadan sonra şaşırıyor onu if ile düzeltebilirsin
             *                         
            float hipo = Mathf.Sqrt(Mathf.Abs(dikeyHiz) * Mathf.Abs(dikeyHiz) + yatayHiz * yatayHiz);


            float rad = Mathf.Acos(yatayHiz / hipo);
            float aci = rad * Mathf.Rad2Deg;

            oyuncuTransform.transform.rotation = Quaternion.Lerp(oyuncuTransform.transform.rotation, Quaternion.Euler(90 - aci, 0, 0), 1 );     //* Time.deltaTime * 100

            Debug.Log("dikey hiz : " + dikeyHiz + "  yatay hiz : " + yatayHiz + "  aci : " + aci);
            
        }
        */


    }




    void atisDegerleriniHesapla(float maxYukseklik, float hedefYuksekligi, float menzil)
    {
        dikeyHizB = Mathf.Sqrt(2 * yercekimiKatsayisi * maxYukseklik);
        

        float sureCikis = dikeyHizB / yercekimiKatsayisi;
        float sureUcus = 2 * sureCikis;
        float sureMaxYuksekliktenHedefYuksekligineDusme = Mathf.Sqrt( (2 * (maxYukseklik - hedefYuksekligi)) / yercekimiKatsayisi);
        float maxMenzil = (sureUcus * menzil) / (sureCikis + sureMaxYuksekliktenHedefYuksekligineDusme);

        yatayHizB = maxMenzil / sureUcus;


        //Debug.Log("Aradaki mesafe :  " + aradakiMesafe + "  Dikey hiz  : " + dikeyHizB + "  Yatay Hiz :  " + yatayHizB);

    }



}
