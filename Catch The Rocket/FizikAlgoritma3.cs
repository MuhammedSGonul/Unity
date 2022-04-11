using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FizikAlgoritma3 : MonoBehaviour
{

    public OyunYoneticisi oyunYonet;

    public Animator Animasyoncu;
    public Animator KameraShakeIcin;

    public float speed;
    float merdivenTirmanmaHizi = 0.4f;
    public float ziplamaGucu;
    public LayerMask WhatIsLadder;      //bu hangi layerda merdiven ona yarıyor
    public LayerMask WhatIsLadderBitis;
    public float distance;          //bu merdiveni ne kadar yukardaysa ona göre algılıyor diyelim 5 yaptın 5 metre yukardaki merdivene tırmanıyo öyle düşün

    public GameObject kamera;

    public Transform Karakter;
    public Transform olusturmaCizgi;
    //bu yüzden public ekledim publicin içine de boş bir sprite attım


    private Rigidbody2D rb; // karakterimizin rigidbodysi


    int roketArasiUzaklikSabiti = 3;   //Algoritma V3 kağıdına bakarak anlayabilirsin


    private bool tirmanmaDurumu = true;         //bunun true olması sayesinde ilk başlarken rokete tırmanır şekilde başlıyor buna da baya kafa yorduydum meğerse burdaymuş sorun. tm eyw
    private bool ziplayabilmeDurumu = false;

    float roketBoyutu = 0.3798615f;

    public static float uzaklikY = 2.7f;    

    public static float sagdakiXNoktasi = 0.7369f;
    public static float soldakiXNoktasi = -0.325f;
    float ortaNokta = ((sagdakiXNoktasi + soldakiXNoktasi) / 2f);

    public static float soldakiYNoktasi = 15.396f;                    
    float sagdakiYNoktasi = soldakiYNoktasi + (uzaklikY / 2f);           

    float olusturmaCizgiY = soldakiYNoktasi + uzaklikY + (uzaklikY / 2f);
    int olusturmaCizgiSayaci = 1;

    int roketSoldakiSayac = 1;              
    int roketSagdakiSayac = 1;               



    int a;
    int b;
    int ziplamaSayaci = 0;
    int coinsayac;
    public static int oyundaToplananCoinMiktari = 0;        //bunun için kafayı yedim meğerse her seferinde sıfırlanmıyormuş static olduğu için


    public GameObject R1;
    public GameObject R2;
    public GameObject R3;
    public GameObject R4;
    public GameObject R5;
    public static GameObject destroyClonea, destroyCloneb, destroyClonec, destroyCloned, destroyClonee, destroyClonef;

    int randomRoketOlustura, randomRoketOlusturb, randomRoketOlusturc, randomRoketOlusturd, randomRoketOlusture, randomRoketOlusturf;



    



    void Awake()
    {
        //clone = (GameObject)Instantiate(R1, new Vector2(soldakiXNoktasi + 1, soldakiYNoktasi + (roketSoldakiSayac * uzaklikY)), Quaternion.identity);
    }

    void Start()
    {
        olusturmaCizgi.transform.position = new Vector2(olusturmaCizgi.transform.position.x, olusturmaCizgiY);
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.8f;
        ilkAltiRandomRoket();
        oyundaToplananCoinMiktari = 0;
    }




    public void SagaGitme()                 ///////////////////////////
    {
        b = 1;
    }

    public void SolaGitme()                     //Yatay Değişkenler
    {
        b = 2;
    }


    private void OnTriggerEnter2D(Collider2D other)                 //Karakter başka bir collider a girerse yapılacak şeyler
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            oyundaToplananCoinMiktari++;
            coinsayac++;
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("coinDegeri", coinsayac);
            
        }
        if (other.gameObject.CompareTag("DusecekMetero"))
        {
            PlayerPrefs.SetInt("oyunBitti", 1);
        }

    }








    void FixedUpdate()  //niye fixedupdate döngüsünün içine yazdık bilmiyorum merdiveni yapan adamın videosunda öyle gösteriyordu
    {
        OyunYoneticisi.sesVerisi = 1;


        
        if (Karakter.transform.position.y > olusturmaCizgi.transform.position.y)
        {

            switch (olusturmaCizgiSayaci)
            { 
                case 1:     //a pozisyonundaki roket
                    Destroy(destroyClonea);                                                     //Buradaki işlem : önce geride kalan a pozisyonundaki roketler silinir sonra yenileri eklenip oluşturma cizgisi yukarı çıkarılır ardından adım 2 olan b pozisyonundaki roketlere geçilir
                    randomRoketSecim();         //random roket sececek
                    roketOlusturAPozisyon();
                    olusturmaCizgi.transform.position = new Vector2(olusturmaCizgi.transform.position.x, olusturmaCizgi.transform.position.y + (uzaklikY / 2f));
                    olusturmaCizgiSayaci++;
                    break;

                case 2:     //b pozisyonundaki roket
                    Destroy(destroyCloneb);
                    randomRoketSecim();
                    roketOlusturBPozisyon();
                    olusturmaCizgi.transform.position = new Vector2(olusturmaCizgi.transform.position.x, olusturmaCizgi.transform.position.y + (uzaklikY / 2f));
                    olusturmaCizgiSayaci++;
                    break;

                case 3:     //c pozisyonundaki roket
                    Destroy(destroyClonec);
                    randomRoketSecim();
                    roketOlusturCPozisyon();
                    olusturmaCizgi.transform.position = new Vector2(olusturmaCizgi.transform.position.x, olusturmaCizgi.transform.position.y + (uzaklikY / 2f));
                    olusturmaCizgiSayaci++;
                    break;

                case 4:     //d pozisyonundaki roket
                    Destroy(destroyCloned);
                    randomRoketSecim();
                    roketOlusturDPozisyon();
                    olusturmaCizgi.transform.position = new Vector2(olusturmaCizgi.transform.position.x, olusturmaCizgi.transform.position.y + (uzaklikY / 2f));
                    olusturmaCizgiSayaci++;
                    break;

                case 5:     //e pozisyonundaki roket
                    Destroy(destroyClonee);
                    randomRoketSecim();
                    roketOlusturEPozisyon();
                    olusturmaCizgi.transform.position = new Vector2(olusturmaCizgi.transform.position.x, olusturmaCizgi.transform.position.y + (uzaklikY / 2f));
                    roketSoldakiSayac++;
                    olusturmaCizgiSayaci++;
                    break;

                case 6:     //f pozisyonundaki roket
                    Destroy(destroyClonef);
                    randomRoketSecim();
                    roketOlusturFPozisyon();
                    olusturmaCizgi.transform.position = new Vector2(olusturmaCizgi.transform.position.x, olusturmaCizgi.transform.position.y + (uzaklikY / 2f));
                    roketSagdakiSayac++;
                    olusturmaCizgiSayaci = 1;
                    break;



            }



        }


     
        Karakter.rotation = Quaternion.Euler(0, 0, 0);  // bu komut sayesinde karakterimiz hiç bir şekilde yamulup ters düşmeyecek
        rb.gravityScale = 0.8f; // komutlar dışında her ne zaman olursa olsun yerçekimi olaccak komudu bu olmazsa zıplarken uçuyoruz galiba

        

        KameraShakeIcin.SetFloat("KameraShake", 0f);

        coinsayac = PlayerPrefs.GetInt("coinDegeri");
        int karakterNo = PlayerPrefs.GetInt("secilenKarakterNo");

                                // bi nedenden ötürü ekledim ama hatırlamıyorum

        Animasyoncu.enabled = true;


        if ((Input.GetKeyDown(KeyCode.RightArrow) || b == 1) && Karakter.transform.position.x < ortaNokta)                                                 ////SAĞA SOLA GİTME KOMUTLARI
        {   // burada eğer sağ butona basarsak sağa gitmesini sağlayan komutlar var
            rb.velocity = new Vector2(speed, rb.velocity.y);
            Karakter.localScale = new Vector3(0.07059001f, 0.07059001f, 0.07059001f);// bak bu kod önemli olabilir senin için bu kod sağa sola dönmeni sağlıyor
            ziplayabilmeDurumu = true;
        }

        if ((Input.GetKeyDown(KeyCode.LeftArrow) || b == 2) && Karakter.transform.position.x > ortaNokta)
        {   //aynı şekilde sola gitme komutu
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            Karakter.localScale = new Vector3(-0.07059001f, 0.07059001f, 0.07059001f);
            ziplayabilmeDurumu = true;
        }

        ////SAĞA SOLA GİTME KOMUTLARI





        RaycastHit2D hitInfo = Physics2D.Raycast(Karakter.transform.position, Vector2.up, distance, WhatIsLadder);
        RaycastHit2D hitInfoBitis = Physics2D.Raycast(Karakter.transform.position, Vector2.up, distance, WhatIsLadderBitis);



        if (hitInfo.collider != null)                         //////////////////
        {
            switch (karakterNo)
            {
                case 0:
                    Animasyoncu.SetFloat("K1", 1.0f);
                    break;
                case 1:
                    Animasyoncu.SetFloat("K1", 1.0f);
                    break;
                case 2:
                    Animasyoncu.SetFloat("K2", 1.0f);
                    break;
                case 3:
                    Animasyoncu.SetFloat("K3", 1.0f);
                    break;
                case 4:
                    Animasyoncu.SetFloat("K4", 1.0f);
                    break;
                case 5:
                    Animasyoncu.SetFloat("K5", 1.0f);
                    break;
                case 6:
                    Animasyoncu.SetFloat("K6", 1.0f);
                    break;
                case 7:
                    Animasyoncu.SetFloat("K7", 1.0f);
                    break;
                case 8:
                    Animasyoncu.SetFloat("K8", 1.0f);
                    break;
                case 9:
                    Animasyoncu.SetFloat("K9", 1.0f);
                    break;
                case 10:
                    Animasyoncu.SetFloat("K10", 1.0f);
                    break;
                case 11:
                    Animasyoncu.SetFloat("K11", 1.0f);
                    break;
                case 12:
                    Animasyoncu.SetFloat("K12", 1.0f);
                    break;
                case 13:
                    Animasyoncu.SetFloat("K13", 1.0f);
                    break;
                case 14:
                    Animasyoncu.SetFloat("K14", 1.0f);
                    break;
                case 15:
                    Animasyoncu.SetFloat("K15", 1.0f);
                    break;
            }


            float kameraylaHizlanma = YeniKameraTakip.speed;


            if (OyunYoneticisi.CanvasDurum == 0)
            {
                OyunYoneticisi.sesVerisi = 0;
            }

            KameraShakeIcin.SetFloat("KameraShake", 1.0f);
            rb.gravityScale = 0.0f;
            rb.velocity = new Vector2(rb.velocity.x, merdivenTirmanmaHizi + kameraylaHizlanma);
            ziplamaSayaci = 1;
        }
        else
        {
            rb.gravityScale = 0.8f;
        }

        if (hitInfoBitis.collider != null)
        {
            rb.gravityScale = 0.0f;
            rb.velocity = new Vector2(rb.velocity.x, 0f);

            if (Karakter.transform.position.x > ortaNokta)
            {
                rb.velocity = new Vector2(-0.5f, rb.velocity.y);
                Karakter.localScale = new Vector3(-0.07059001f, 0.07059001f, 0.07059001f);
            }

            if (Karakter.transform.position.x < ortaNokta)
            {
                rb.velocity = new Vector2(0.5f, rb.velocity.y);
                Karakter.localScale = new Vector3(0.07059001f, 0.07059001f, 0.07059001f);
            }

        }





        if (ziplayabilmeDurumu == true && ziplamaSayaci == 1)
        {
            rb.AddForce(Vector2.up * ziplamaGucu);
            ziplamaSayaci++;
            b = 0;
            ziplayabilmeDurumu = false;


        }



    }



    void ilkAltiRandomRoket()
    {
        randomRoketSecim();

        switch (randomRoketOlustura)               
        {
            case 1:
                destroyClonea = (GameObject)Instantiate(R1, new Vector2(soldakiXNoktasi, soldakiYNoktasi), Quaternion.identity);
                break;

            case 2:
                destroyClonea = (GameObject)Instantiate(R2, new Vector2(soldakiXNoktasi, soldakiYNoktasi), Quaternion.identity);
                break;

            case 3:        
                destroyClonea = (GameObject)Instantiate(R3, new Vector2(soldakiXNoktasi, soldakiYNoktasi), Quaternion.identity);
                break;

            case 4:
                destroyClonea = (GameObject)Instantiate(R4, new Vector2(soldakiXNoktasi, soldakiYNoktasi), Quaternion.identity);
                break;

            case 5:
                destroyClonea = (GameObject)Instantiate(R5, new Vector2(soldakiXNoktasi, soldakiYNoktasi), Quaternion.identity);
                break;

        }

        switch (randomRoketOlusturb)
        {
            case 1:
                destroyCloneb = (GameObject)Instantiate(R1, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi), Quaternion.identity);
                destroyCloneb.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 2:
                destroyCloneb = (GameObject)Instantiate(R2, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi), Quaternion.identity);
                destroyCloneb.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 3:
                destroyCloneb = (GameObject)Instantiate(R3, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi), Quaternion.identity);
                destroyCloneb.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 4:
                destroyCloneb = (GameObject)Instantiate(R4, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi), Quaternion.identity);
                destroyCloneb.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 5:
                destroyCloneb = (GameObject)Instantiate(R5, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi), Quaternion.identity);
                destroyCloneb.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;
        }


        switch (randomRoketOlusturc)               
        {
            case 1:
                destroyClonec = (GameObject)Instantiate(R1, new Vector2(soldakiXNoktasi, soldakiYNoktasi + uzaklikY), Quaternion.identity);
                break;

            case 2:
                destroyClonec = (GameObject)Instantiate(R2, new Vector2(soldakiXNoktasi, soldakiYNoktasi + uzaklikY), Quaternion.identity);
                break;

            case 3:
                destroyClonec = (GameObject)Instantiate(R3, new Vector2(soldakiXNoktasi, soldakiYNoktasi + uzaklikY), Quaternion.identity);
                break;

            case 4:
                destroyClonec = (GameObject)Instantiate(R4, new Vector2(soldakiXNoktasi, soldakiYNoktasi + uzaklikY), Quaternion.identity);
                break;

            case 5:
                destroyClonec = (GameObject)Instantiate(R5, new Vector2(soldakiXNoktasi, soldakiYNoktasi + uzaklikY), Quaternion.identity);
                break;
        }

        switch (randomRoketOlusturd)               
        {
            case 1:
                destroyCloned = (GameObject)Instantiate(R1, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + uzaklikY), Quaternion.identity);
                destroyCloned.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 2:
                destroyCloned = (GameObject)Instantiate(R2, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + uzaklikY), Quaternion.identity);
                destroyCloned.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 3:
                destroyCloned = (GameObject)Instantiate(R3, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + uzaklikY), Quaternion.identity);
                destroyCloned.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 4:
                destroyCloned = (GameObject)Instantiate(R4, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + uzaklikY), Quaternion.identity);
                destroyCloned.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 5:
                destroyCloned = (GameObject)Instantiate(R5, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + uzaklikY), Quaternion.identity);
                destroyCloned.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;
        }

        switch (randomRoketOlusture)               
        {
            case 1:
                destroyClonee = (GameObject)Instantiate(R1, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (2 * uzaklikY)), Quaternion.identity);
                break;

            case 2:
                destroyClonee = (GameObject)Instantiate(R2, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (2 * uzaklikY)), Quaternion.identity);
                break;

            case 3:
                destroyClonee = (GameObject)Instantiate(R3, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (2 * uzaklikY)), Quaternion.identity);
                break;

            case 4:
                destroyClonee = (GameObject)Instantiate(R4, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (2 * uzaklikY)), Quaternion.identity);
                break;

            case 5:
                destroyClonee = (GameObject)Instantiate(R5, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (2 * uzaklikY)), Quaternion.identity);
                break;
        }

        switch (randomRoketOlusturf)               
        {
            case 1:
                destroyClonef = (GameObject)Instantiate(R1, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (2 * uzaklikY)), Quaternion.identity);
                destroyClonef.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 2:
                destroyClonef = (GameObject)Instantiate(R2, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (2 * uzaklikY)), Quaternion.identity);
                destroyClonef.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 3:
                destroyClonef = (GameObject)Instantiate(R3, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (2 * uzaklikY)), Quaternion.identity);
                destroyClonef.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 4:
                destroyClonef = (GameObject)Instantiate(R4, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (2 * uzaklikY)), Quaternion.identity);
                destroyClonef.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 5:
                destroyClonef = (GameObject)Instantiate(R5, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (2 * uzaklikY)), Quaternion.identity);
                destroyClonef.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;
        }

    }








    void roketOlusturAPozisyon()
    {
        switch (randomRoketOlustura)               
        {
            case 1:
                destroyClonea = (GameObject)Instantiate(R1, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketSoldakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                break;

            case 2:
                destroyClonea = (GameObject)Instantiate(R2, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketSoldakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                break;

            case 3:
                destroyClonea = (GameObject)Instantiate(R3, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketSoldakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                break;

            case 4:
                destroyClonea = (GameObject)Instantiate(R4, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketSoldakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                break;

            case 5:
                destroyClonea = (GameObject)Instantiate(R5, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketSoldakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                break;

        }

       
    }

    void roketOlusturBPozisyon()
    {
        switch (randomRoketOlusturb)
        {
            case 1:
                destroyCloneb = (GameObject)Instantiate(R1, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (roketSagdakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                destroyCloneb.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 2:
                destroyCloneb = (GameObject)Instantiate(R2, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (roketSagdakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                destroyCloneb.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 3:
                destroyCloneb = (GameObject)Instantiate(R3, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (roketSagdakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                destroyCloneb.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 4:
                destroyCloneb = (GameObject)Instantiate(R4, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (roketSagdakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                destroyCloneb.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 5:
                destroyCloneb = (GameObject)Instantiate(R5, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (roketSagdakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                destroyCloneb.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;
        }


    }

    void roketOlusturCPozisyon()
    {
        switch (randomRoketOlusturc)
        {
            case 1:
                destroyClonec = (GameObject)Instantiate(R1, new Vector2(soldakiXNoktasi, (soldakiYNoktasi + uzaklikY) + (roketSoldakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                break;

            case 2:
                destroyClonec = (GameObject)Instantiate(R2, new Vector2(soldakiXNoktasi, (soldakiYNoktasi + uzaklikY) + (roketSoldakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                break;

            case 3:
                destroyClonec = (GameObject)Instantiate(R3, new Vector2(soldakiXNoktasi, (soldakiYNoktasi + uzaklikY) + (roketSoldakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                break;

            case 4:
                destroyClonec = (GameObject)Instantiate(R4, new Vector2(soldakiXNoktasi, (soldakiYNoktasi + uzaklikY) + (roketSoldakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                break;

            case 5:
                destroyClonec = (GameObject)Instantiate(R5, new Vector2(soldakiXNoktasi, (soldakiYNoktasi + uzaklikY) + (roketSoldakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                break;
        }


    }

    void roketOlusturDPozisyon()
    {
        switch (randomRoketOlusturd)
        {
            case 1:
                destroyCloned = (GameObject)Instantiate(R1, new Vector2(sagdakiXNoktasi, (sagdakiYNoktasi + uzaklikY) + (roketSagdakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                destroyCloned.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 2:
                destroyCloned = (GameObject)Instantiate(R2, new Vector2(sagdakiXNoktasi, (sagdakiYNoktasi + uzaklikY) + (roketSagdakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                destroyCloned.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 3:
                destroyCloned = (GameObject)Instantiate(R3, new Vector2(sagdakiXNoktasi, (sagdakiYNoktasi + uzaklikY) + (roketSagdakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                destroyCloned.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 4:
                destroyCloned = (GameObject)Instantiate(R4, new Vector2(sagdakiXNoktasi, (sagdakiYNoktasi + uzaklikY) + (roketSagdakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                destroyCloned.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 5:
                destroyCloned = (GameObject)Instantiate(R5, new Vector2(sagdakiXNoktasi, (sagdakiYNoktasi + uzaklikY) + (roketSagdakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                destroyCloned.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;
        }


    }


    void roketOlusturEPozisyon()
    {
        switch (randomRoketOlusture)
        {
            case 1:
                destroyClonee = (GameObject)Instantiate(R1, new Vector2(soldakiXNoktasi, (soldakiYNoktasi + (2 * uzaklikY)) + (roketSoldakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                break;

            case 2:
                destroyClonee = (GameObject)Instantiate(R2, new Vector2(soldakiXNoktasi, (soldakiYNoktasi + (2 * uzaklikY)) + (roketSoldakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                break;

            case 3:
                destroyClonee = (GameObject)Instantiate(R3, new Vector2(soldakiXNoktasi, (soldakiYNoktasi + (2 * uzaklikY)) + (roketSoldakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                break;

            case 4:
                destroyClonee = (GameObject)Instantiate(R4, new Vector2(soldakiXNoktasi, (soldakiYNoktasi + (2 * uzaklikY)) + (roketSoldakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                break;

            case 5:
                destroyClonee = (GameObject)Instantiate(R5, new Vector2(soldakiXNoktasi, (soldakiYNoktasi + (2 * uzaklikY)) + (roketSoldakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                break;
        }


    }

    void roketOlusturFPozisyon()
    {
        switch (randomRoketOlusturf)
        {
            case 1:
                destroyClonef = (GameObject)Instantiate(R1, new Vector2(sagdakiXNoktasi, (sagdakiYNoktasi + (2 * uzaklikY)) + (roketSagdakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                destroyClonef.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 2:
                destroyClonef = (GameObject)Instantiate(R2, new Vector2(sagdakiXNoktasi, (sagdakiYNoktasi + (2 * uzaklikY)) + (roketSagdakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                destroyClonef.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 3:
                destroyClonef = (GameObject)Instantiate(R3, new Vector2(sagdakiXNoktasi, (sagdakiYNoktasi + (2 * uzaklikY)) + (roketSagdakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                destroyClonef.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 4:
                destroyClonef = (GameObject)Instantiate(R4, new Vector2(sagdakiXNoktasi, (sagdakiYNoktasi + (2 * uzaklikY)) + (roketSagdakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                destroyClonef.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;

            case 5:
                destroyClonef = (GameObject)Instantiate(R5, new Vector2(sagdakiXNoktasi, (sagdakiYNoktasi + (2 * uzaklikY)) + (roketSagdakiSayac * roketArasiUzaklikSabiti * uzaklikY)), Quaternion.identity);
                destroyClonef.transform.localScale = new Vector3(-roketBoyutu, roketBoyutu, roketBoyutu);
                break;
        }


    }


    void randomRoketSecim()
    {
        randomRoketOlustura = Random.Range(1, 6);
        randomRoketOlusturb = Random.Range(1, 6);
        randomRoketOlusturc = Random.Range(1, 6);
        randomRoketOlusturd = Random.Range(1, 6);
        randomRoketOlusture = Random.Range(1, 6);
        randomRoketOlusturf = Random.Range(1, 6);
    }





}



