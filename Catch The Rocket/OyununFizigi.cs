using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OyununFizigi : MonoBehaviour
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
    public Transform olusturmaNoktasi;
    //bu yüzden public ekledim publicin içine de boş bir sprite attım


    private Rigidbody2D rb; // karakterimizin rigidbodysi



    private bool tirmanmaDurumu = true;         //bunun true olması sayesinde ilk başlarken rokete tırmanır şekilde başlıyor buna da baya kafa yorduydum meğerse burdaymuş sorun. tm eyw
    private bool ziplayabilmeDurumu = false;

    float uzaklikx = 0.85f;

    public static float uzaklikY = 2.7f;    //

    float ortaNokta = 0.2f;

    float sagdakiXNoktasi = 0.7369f;
    float soldakiXNoktasi = -0.325f;

    public static float soldakiYNoktasi = 15.396f;                     //
    float sagdakiYNoktasi = soldakiYNoktasi + (uzaklikY / 2);           //

    float olusturmaNoktasiY = soldakiYNoktasi + ((3 * uzaklikY) / 4);       //

    int a;
    int b;
    int c = 0;
    int d = 0;
    public static int e;
    int ziplamaSayaci = 0;
    int coinsayac;

    float olusturmaSayaci = (8f / 3f);        //
    int roketIlkSayac = 2;              //
    int roketIkinciSayac = 3;               //


    public GameObject R1;
    public GameObject R2;
    public GameObject R3;
    public GameObject R4;
    public GameObject R5;
    public static GameObject clone;


    void Awake()
    {
        //clone = (GameObject)Instantiate(R1, new Vector2(soldakiXNoktasi + 1, soldakiYNoktasi + (roketIlkSayac * uzaklikY)), Quaternion.identity);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.8f;
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




        if (Karakter.transform.position.y > olusturmaNoktasi.transform.position.y)
        {


            int roketOlusture = Random.Range(1, 6);     //1-10 arası roket modellerimizden rastgele birisini seçmesi için Random.Range komutunu kullandık
            int roketOlusturf = Random.Range(1, 6);
            int roketOlusturg = Random.Range(1, 6);
            int roketOlusturh = Random.Range(1, 6);

            switch (roketOlusture)               /////////SIRA SIRA ROKET OLUŞTURMA 
            {
                case 1:
                    //Instantiate(R1, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketIlkSayac * uzaklikY)), Quaternion.identity);
                    clone = (GameObject)Instantiate(R1, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketIlkSayac * uzaklikY)), Quaternion.identity);
                    break;

                case 2:
                    //Instantiate(R2, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketIlkSayac * uzaklikY)), Quaternion.identity);
                    clone = (GameObject)Instantiate(R2, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketIlkSayac * uzaklikY)), Quaternion.identity);
                    break;

                case 3:
                    //Instantiate(R3, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketIlkSayac * uzaklikY)), Quaternion.identity);
                    clone = (GameObject)Instantiate(R3, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketIlkSayac * uzaklikY)), Quaternion.identity);
                    break;

                case 4:
                    //Instantiate(R4, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketIlkSayac * uzaklikY)), Quaternion.identity);
                    clone = (GameObject)Instantiate(R4, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketIlkSayac * uzaklikY)), Quaternion.identity);
                    break;

                case 5:
                    //Instantiate(R5, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketIlkSayac * uzaklikY)), Quaternion.identity);
                    clone = (GameObject)Instantiate(R5, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketIlkSayac * uzaklikY)), Quaternion.identity);
                    break;

            }

            switch (roketOlusturf)
            {
                case 1:
                    GameObject R1Klonf = Instantiate(R1, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (roketIlkSayac * uzaklikY)), Quaternion.identity);
                    R1Klonf.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    roketIlkSayac = roketIlkSayac + 2;
                    break;

                case 2:
                    GameObject R2Klonf = Instantiate(R2, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (roketIlkSayac * uzaklikY)), Quaternion.identity);
                    R2Klonf.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    roketIlkSayac = roketIlkSayac + 2;
                    break;

                case 3:
                    GameObject R3Klonf = Instantiate(R3, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (roketIlkSayac * uzaklikY)), Quaternion.identity);
                    R3Klonf.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    roketIlkSayac = roketIlkSayac + 2;
                    break;

                case 4:
                    GameObject R4Klonf = Instantiate(R4, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (roketIlkSayac * uzaklikY)), Quaternion.identity);
                    R4Klonf.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    roketIlkSayac = roketIlkSayac + 2;
                    break;

                case 5:
                    GameObject R5Klonf = Instantiate(R5, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (roketIlkSayac * uzaklikY)), Quaternion.identity);
                    R5Klonf.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    roketIlkSayac = roketIlkSayac + 2;
                    break;
            }


            switch (roketOlusturg)               /////////SIRA SIRA ROKET OLUŞTURMA 
            {
                case 1:
                    Instantiate(R1, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketIkinciSayac * uzaklikY)), Quaternion.identity);
                    break;

                case 2:
                    Instantiate(R2, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketIkinciSayac * uzaklikY)), Quaternion.identity);
                    break;

                case 3:
                    Instantiate(R3, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketIkinciSayac * uzaklikY)), Quaternion.identity);
                    break;

                case 4:
                    Instantiate(R4, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketIkinciSayac * uzaklikY)), Quaternion.identity);
                    break;

                case 5:
                    Instantiate(R5, new Vector2(soldakiXNoktasi, soldakiYNoktasi + (roketIkinciSayac * uzaklikY)), Quaternion.identity);
                    break;
            }

            switch (roketOlusturh)               /////////SIRA SIRA ROKET OLUŞTURMA 
            {
                case 1:
                    GameObject R1Klonh = Instantiate(R1, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (roketIkinciSayac * uzaklikY)), Quaternion.identity);
                    R1Klonh.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    roketIkinciSayac = roketIkinciSayac + 2;
                    break;

                case 2:
                    GameObject R2Klonh = Instantiate(R2, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (roketIkinciSayac * uzaklikY)), Quaternion.identity);
                    R2Klonh.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    roketIkinciSayac = roketIkinciSayac + 2;
                    break;

                case 3:
                    GameObject R3Klonh = Instantiate(R3, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (roketIkinciSayac * uzaklikY)), Quaternion.identity);
                    R3Klonh.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    roketIkinciSayac = roketIkinciSayac + 2;
                    break;

                case 4:
                    GameObject R4Klonh = Instantiate(R4, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (roketIkinciSayac * uzaklikY)), Quaternion.identity);
                    R4Klonh.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    roketIkinciSayac = roketIkinciSayac + 2;
                    break;

                case 5:
                    GameObject R5Klonh = Instantiate(R5, new Vector2(sagdakiXNoktasi, sagdakiYNoktasi + (roketIkinciSayac * uzaklikY)), Quaternion.identity);
                    R5Klonh.transform.localScale = new Vector3(-0.3798615f, 0.3798615f, 0.3798615f);
                    roketIkinciSayac = roketIkinciSayac + 2;
                    break;
            }


            olusturmaNoktasi.transform.position = new Vector2(0, olusturmaNoktasiY + (olusturmaSayaci * ((3 * uzaklikY) / 4)));
            olusturmaSayaci += (8f / 3f);


        }



        if (Input.GetKeyDown(KeyCode.Space)) ///bu şekilde objelerı imha edecez
        {
            Destroy(clone);
        }




        KameraShakeIcin.SetFloat("KameraShake", 0f);

        coinsayac = PlayerPrefs.GetInt("coinDegeri");
        int karakterNo = PlayerPrefs.GetInt("secilenKarakterNo");

        Karakter.rotation = Quaternion.Euler(0, 0, 0);  // bu komut sayesinde karakterimiz hiç bir şekilde yamulup ters düşmeyecek
        rb.gravityScale = 0.8f; // komutlar dışında her ne zaman olursa olsun yerçekimi olaccak komudu bu olmazsa zıplarken uçuyoruz galiba
                                // bi nedenden ötürü ekledim ama hatırlamıyorum

        Animasyoncu.enabled = true;


        if ((Input.GetKeyDown(KeyCode.RightArrow) || b == 1) && Karakter.transform.position.x < ortaNokta)                                                 ////SAĞA SOLA GİTME KOMUTLARI
        {   // burada eğer sağ butona basarsak sağa gitmesini sağlayan komutlar var
            rb.velocity = new Vector2(speed, rb.velocity.y);
            Karakter.localScale = new Vector3(0.07059001f, 0.07059001f, 0.07059001f);// bak bu kod önemli olabilir senin için bu kod sağa sola dönmeni sağlıyor
            ziplayabilmeDurumu = true;
        }

        if ((Input.GetKeyDown(KeyCode.LeftArrow) || b == 2 )&& Karakter.transform.position.x > ortaNokta)
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
}



