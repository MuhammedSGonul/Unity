using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class g_oyuncuHareket : MonoBehaviour
{



    public Transform oyuncuVeKamera;
    public bool Hareket1 = false;
    public bool Hareket2 = false;
    public bool Hareket3 = true;


    Animator kosmaAnim;
    Transform oyuncu;
    
    float dokunmaOrijin, kaymaMiktari, karakterOrijin, hedefMouse, hedefKarakter;
    int dokunmaAdim = 0;
    bool oyunBasladi = false;
    

    public float ilerlemeHizi = 0.18f;

    [Header("1. Hareket Şekli Ayarları")]
    public float sagSolHassasiyet = 0.0008f;
    public float sagSolMaxEsik = 4;
    public float donmeHizi = 1f;

    [Header("2. Hareket Şekli Ayarları (Klasik Hyper Casual)")]
    public float kaymaHizi = 1f;
    public float kaymaHassasiyet = 0.01f;
    
   


    





    void Start()
    {
        kosmaAnim = this.gameObject.GetComponent<Animator>();
        oyuncu = this.gameObject.GetComponent<Transform>();

    }



    void Update()
    {
        

        if(Hareket1 == false && Hareket2 == false && Hareket3 == false)
        {
            Hareket3 = true;
        }

        if(Hareket1 == true && Hareket2 == true && Hareket3 == true)
        {
            Hareket1 = false;
            Hareket2 = false;
        }

        if(Hareket1 == true && Hareket2 == true && Hareket3 == false)
        {
            Hareket1 = false;
            Hareket2 = true;
        }

        if (Hareket1 == true && Hareket2 == false && Hareket3 == true)
        {
            Hareket1 = false;
            Hareket3 = true;
        }

        if (Hareket1 == false && Hareket2 == true && Hareket3 == true)
        {
            Hareket2 = false;
            Hareket3 = true;
        }


        if (Hareket1 == true && Hareket2 == false && Hareket3 == false)
        {
            
            if(oyunBasladi == true && g_oyuncuYonetici.oyuncuDusmanaFirlatildi == false && g_oyuncuYonetici.oyuncuHareketKilit == false)
            {



            ileriGitme();
            oyuncu.transform.rotation = Quaternion.Lerp(oyuncu.transform.rotation, Quaternion.Euler(0, 0, 0), donmeHizi);

            if (Input.GetMouseButtonDown(0) && dokunmaAdim == 0)
            {
                dokunmaOrijin = Input.mousePosition.x;
                dokunmaAdim = 1;
            }

            if (Input.GetMouseButton(0) && dokunmaAdim == 1)
            {
                kaymaMiktari = Input.mousePosition.x - dokunmaOrijin;
                
                if (kaymaMiktari > 120) kaymaMiktari = 120;
                if (kaymaMiktari < -120) kaymaMiktari = -120;

                oyuncu.transform.position = new Vector3(oyuncu.transform.position.x + kaymaMiktari * sagSolHassasiyet * Time.deltaTime * 100
                    , oyuncu.transform.position.y, oyuncu.transform.position.z);


                if (oyuncu.transform.position.x > sagSolMaxEsik) oyuncu.transform.position = new Vector3 (sagSolMaxEsik, oyuncu.transform.position.y, oyuncu.transform.position.z);
                if (oyuncu.transform.position.x < -sagSolMaxEsik) oyuncu.transform.position = new Vector3(-sagSolMaxEsik, oyuncu.transform.position.y, oyuncu.transform.position.z);


                float hipo = Mathf.Sqrt(ilerlemeHizi * ilerlemeHizi + Mathf.Abs(kaymaMiktari * sagSolHassasiyet * kaymaMiktari * sagSolHassasiyet));

                float radyan = Mathf.Acos(Mathf.Abs(kaymaMiktari * sagSolHassasiyet) / hipo);
                float aci = radyan * Mathf.Rad2Deg;

                //karşı : ilerlemeHizi     komşu : kaymaMiktari * sagSolHassasiyet 

                if(kaymaMiktari > 0)
                {
                    float donmeAci = 90 - aci;
                    if (donmeAci > 20) donmeAci = 20;
                    oyuncu.transform.rotation = Quaternion.Lerp(oyuncu.transform.rotation, Quaternion.Euler(0, donmeAci, 0), donmeHizi * Time.deltaTime * 100);
                }

                if (kaymaMiktari < 0)
                {
                    float donmeAci = -90 + aci;
                    if (donmeAci < -20) donmeAci = -20;
                    oyuncu.transform.rotation = Quaternion.Lerp(oyuncu.transform.rotation, Quaternion.Euler(0, donmeAci, 0), donmeHizi * Time.deltaTime * 100);
                }




            }

            if (!Input.GetMouseButton(0) && dokunmaAdim == 1)
            {
                dokunmaAdim = 0;
            }

            }
            
        }

        if (Hareket1 == false && Hareket2 == true && Hareket3 == false)
        {
            if (oyunBasladi == true && g_oyuncuYonetici.oyuncuDusmanaFirlatildi == false && g_oyuncuYonetici.oyuncuHareketKilit == false)
            {

                ileriGitme();

                if (Input.GetMouseButtonDown(0) && dokunmaAdim == 0)
                {
                    dokunmaOrijin = Input.mousePosition.x;
                    karakterOrijin = oyuncu.transform.position.x;
                    dokunmaAdim = 1;
                }

                if (Input.GetMouseButton(0) && dokunmaAdim == 1)
                {
                    kaymaMiktari = Input.mousePosition.x - dokunmaOrijin;
                    hedefMouse = kaymaMiktari * kaymaHassasiyet;
                    hedefKarakter = karakterOrijin + hedefMouse;

                    if (kaymaMiktari < 0)
                    {
                        oyuncu.transform.position = new Vector3(oyuncu.transform.position.x - kaymaHizi * Time.deltaTime * 100
                        , oyuncu.transform.position.y, oyuncu.transform.position.z);

                        if (hedefKarakter > oyuncu.transform.position.x)
                        {
                            oyuncu.transform.position = new Vector3(hedefKarakter, oyuncu.transform.position.y, oyuncu.transform.position.z);
                        }
                    }

                    if (kaymaMiktari > 0)
                    {
                        oyuncu.transform.position = new Vector3(oyuncu.transform.position.x + kaymaHizi * Time.deltaTime * 100
                        , oyuncu.transform.position.y, oyuncu.transform.position.z);

                        if (hedefKarakter < oyuncu.transform.position.x)
                        {
                            oyuncu.transform.position = new Vector3(hedefKarakter, oyuncu.transform.position.y, oyuncu.transform.position.z);
                        }
                    }

                    if (oyuncu.transform.position.x > sagSolMaxEsik) oyuncu.transform.position = new Vector3(sagSolMaxEsik, oyuncu.transform.position.y, oyuncu.transform.position.z);
                    if (oyuncu.transform.position.x < -sagSolMaxEsik) oyuncu.transform.position = new Vector3(-sagSolMaxEsik, oyuncu.transform.position.y, oyuncu.transform.position.z);

                }

                if (!Input.GetMouseButton(0) && dokunmaAdim == 1)
                {
                    dokunmaAdim = 0;
                }

            }

        }




        if (Hareket1 == false && Hareket2 == false && Hareket3 == true)
        {
            if (oyunBasladi == true && g_oyuncuYonetici.oyuncuDusmanaFirlatildi == false && g_oyuncuYonetici.oyuncuHareketKilit == false)
            {

                ileriGitme();
                oyuncu.transform.rotation = Quaternion.Lerp(oyuncu.transform.rotation, Quaternion.Euler(0, 0, 0), donmeHizi);

                if (Input.GetMouseButtonDown(0) && dokunmaAdim == 0)
                {
                    dokunmaOrijin = Input.mousePosition.x;
                    karakterOrijin = oyuncu.transform.position.x;
                    dokunmaAdim = 1;
                }

                if (Input.GetMouseButton(0) && dokunmaAdim == 1)
                {
                    kaymaMiktari = Input.mousePosition.x - dokunmaOrijin;
                    hedefMouse = kaymaMiktari * kaymaHassasiyet;
                    hedefKarakter = karakterOrijin + hedefMouse;


                    float hipo = Mathf.Sqrt(ilerlemeHizi * ilerlemeHizi + Mathf.Abs(hedefMouse * hedefMouse));

                    float radyan = Mathf.Acos(Mathf.Abs(hedefMouse) / hipo);
                    float aci = radyan * Mathf.Rad2Deg;


                    if (kaymaMiktari < 0)
                    {
                        oyuncu.transform.position = new Vector3(oyuncu.transform.position.x - kaymaHizi * Time.deltaTime * 100
                        , oyuncu.transform.position.y, oyuncu.transform.position.z);

                        float donmeAci = -90 + aci;
                        if (donmeAci < -20) donmeAci = -20;
                        oyuncu.transform.rotation = Quaternion.Euler(0, donmeAci, 0);

                        if (hedefKarakter > oyuncu.transform.position.x)
                        {
                            oyuncu.transform.position = new Vector3(hedefKarakter, oyuncu.transform.position.y, oyuncu.transform.position.z);
                            oyuncu.transform.rotation = Quaternion.Lerp(oyuncu.transform.rotation, Quaternion.Euler(0, 0, 0), 0.5f);
                                            
                        }
                    }

                    if (kaymaMiktari > 0)
                    {
                        oyuncu.transform.position = new Vector3(oyuncu.transform.position.x + kaymaHizi * Time.deltaTime * 100
                        , oyuncu.transform.position.y, oyuncu.transform.position.z);

                        float donmeAci = 90 - aci;
                        if (donmeAci > 20) donmeAci = 20;
                        oyuncu.transform.rotation = Quaternion.Euler(0, donmeAci, 0);


                        if (hedefKarakter < oyuncu.transform.position.x)
                        {
                            oyuncu.transform.position = new Vector3(hedefKarakter, oyuncu.transform.position.y, oyuncu.transform.position.z);
                            oyuncu.transform.rotation = Quaternion.Lerp(oyuncu.transform.rotation, Quaternion.Euler(0, 0, 0), 0.5f);
                            
                        }



                    }

                    if (oyuncu.transform.position.x > sagSolMaxEsik) oyuncu.transform.position = new Vector3(sagSolMaxEsik, oyuncu.transform.position.y, oyuncu.transform.position.z);
                    if (oyuncu.transform.position.x < -sagSolMaxEsik) oyuncu.transform.position = new Vector3(-sagSolMaxEsik, oyuncu.transform.position.y, oyuncu.transform.position.z);









                }

                if (!Input.GetMouseButton(0) && dokunmaAdim == 1)
                {
                    dokunmaAdim = 0;
                }

            }

        }




    }

    public void oyunuBaslat()
    {
        oyunBasladi = true;
        kosmaAnim.GetComponent<Animator>().SetBool("kos", true);
    }


    public void oyuncuDurdurma()
    {
        ilerlemeHizi = 0;
    }

    

    public void oyuncuEngeleCarpmaAnim()    //animasyonun son frameinde oyuncuYoneticiye ordan da oyunYoneticisi'nden oyun başarısıza geçiyor
    {
        kosmaAnim.GetComponent<Animator>().SetBool("engeleCarpDus", true);
    }

    


    public void oyuncuFirlatmaAnim()
    {
        kosmaAnim.GetComponent<Animator>().SetBool("firlat", true);

    }

    void ileriGitme()
    {      
        
        oyuncuVeKamera.transform.position = new Vector3
                    (
                    oyuncuVeKamera.transform.position.x,
                    oyuncuVeKamera.transform.position.y,
                    oyuncuVeKamera.transform.position.z + ilerlemeHizi * Time.deltaTime * 100
                    );
        
    }

}
