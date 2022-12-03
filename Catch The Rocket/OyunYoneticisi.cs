using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunYoneticisi : MonoBehaviour
{

    public GameObject colArkaplan, geceArkaplan, dagArkaplan, yesilArkaplan;
    public GameObject CanvasDurdurma;
    public GameObject CanvasKaybettin;
    public GameObject CanvasOyunici;
    public GameObject MenuLogo;
    public GameObject YonTuslari;

    public GameObject MeteorUyari;

    public AudioSource roketSesi;
    public AudioSource tirmanmaSesi;
    public AudioSource oyunMuzigi;

    int sesCheck;
    int sesCheck2;
    int sesCheck3;

    int oyunBittiSayac;


    public Transform Karakter;
    public Transform Kamera;

    public Text skorText;                           //skor burada gösteriliyor
    public GameObject skorBaslik;

    string RandomRoketIsmi;

    static int AnaMenuyeDon = 0;
    public static int arkaPlanRandom;

    public static int sesVerisi;

    int networkVerisi;


    int muziKapama;
    int sesKapama;

    float guncelSkor;


    public static int CanvasDurum;

    Scene SuankiSahne;

    

    //burada anlamayacak pek birşey yok

    void Awake()
    {
        oyunMuzigi.GetComponent<AudioSource>().Pause();
        tirmanmaSesi.GetComponent<AudioSource>().Pause();
        roketSesi.GetComponent<AudioSource>().Pause();
        guncelSkor = 0;


        arkaPlanRandom = Random.Range(1, 4);

        if (arkaPlanRandom == 1)
        {
            colArkaplan.SetActive(true);
        }
        if (arkaPlanRandom == 2)
        {
            geceArkaplan.SetActive(true);
        }
        if (arkaPlanRandom == 3)
        {
            dagArkaplan.SetActive(true);
        }
        if (arkaPlanRandom == 4)
        {
            yesilArkaplan.SetActive(true);
        }

    }


    void Start()
    {




        YonTuslari.SetActive(true);
        CanvasDurdurma.SetActive(false);
        CanvasKaybettin.SetActive(false);
        CanvasOyunici.SetActive(true);
        skorBaslik.SetActive(false);
        Scene SuankiSahne = SceneManager.GetActiveScene();
        Time.timeScale = 1;
        CanvasDurum = 0;

    }


    void FixedUpdate()
    {
        int anaMenuKontrol = AnaMenu.AnaMenuyeDonBasildi;           //bu da önemli static sayesinde oldu buda. öteki scriptte bunun başına public static yazdm
        
        int oyunBittiTestMeteor = PlayerPrefs.GetInt("oyunBitti");
        networkVerisi = PlayerPrefs.GetInt("networkBekleniyor");

        if(anaMenuKontrol == 0)
        {
            guncelSkor = YuksekSkor.skor;
        }


        if ((Karakter.transform.position.y + 1.3f < Kamera.transform.position.y || Karakter.transform.position.x > Kamera.transform.position.x + 0.5f || Karakter.transform.position.x < Kamera.transform.position.x - 0.5f) && CanvasDurdurma.activeSelf == false && anaMenuKontrol == 0)
        {
            OyunBitti();                    //burada işte karakter kamera dışına çıkarsa ölüyor
        }                                   //1.3f de hata payı gibi birşey




        if (oyunBittiTestMeteor == 1)               //Meteora çarpıp oyun bitti
        {
            OyunBitti();
            PlayerPrefs.SetInt("oyunBitti", 0);
        }

        skorText.text = string.Format("{0:#0.00}", guncelSkor);




        muziKapama = PlayerPrefs.GetInt("MuzikDurum");   // 1 Kapalı 0 Acik
        sesKapama = PlayerPrefs.GetInt("SesDurum");

        if (sesVerisi == 0 && sesCheck == 0)                                 ///Oyun ici SFX ler merdiven tırmanma vb
        {
            tirmanmaSesi.GetComponent<AudioSource>().Play();
            sesCheck = 1;
        }
        if (sesVerisi == 1 && sesCheck == 1)
        {
            tirmanmaSesi.GetComponent<AudioSource>().Pause();
            sesCheck = 0;
        }                                                               ///


  

        if (muziKapama == 1)
        {
            oyunMuzigi.GetComponent<AudioSource>().Pause();
            sesCheck2 = 0;
        }
        if (muziKapama == 0 && sesCheck2 == 0)
        {
            oyunMuzigi.GetComponent<AudioSource>().Play();
            sesCheck2 = 1;
        }


        if (sesKapama == 1)
        {
            tirmanmaSesi.GetComponent<AudioSource>().Pause();
            roketSesi.GetComponent<AudioSource>().Pause();
            sesCheck3 = 0;
        }
        if (sesKapama == 0 && sesCheck3 == 0)
        {
            tirmanmaSesi.GetComponent<AudioSource>().Play();
            roketSesi.GetComponent<AudioSource>().Play();
            sesCheck3 = 1;
        }




        oyunBittiSayac = PlayerPrefs.GetInt("ReklamIcinOyunBitti");

        if(oyunBittiSayac == 4)
        {
            ReklamYerlestirme.oyunArasiReklamGoster();
            PlayerPrefs.SetInt("ReklamIcinOyunBitti", 0);
        }

 
    }



    public void OyunBitti()
    {
        CanvasDurum = 1;
        CanvasKaybettin.SetActive(true);
        YonTuslari.SetActive(false);
        MeteorUyari.SetActive(false);
        MenuLogo.SetActive(false);
        skorBaslik.SetActive(true);
        PlayerPrefs.SetFloat("SonOyundakiSkor", guncelSkor);

        oyunBittiSayac = PlayerPrefs.GetInt("ReklamIcinOyunBitti");
        oyunBittiSayac++;
        PlayerPrefs.SetInt("ReklamIcinOyunBitti", oyunBittiSayac);
        

        Time.timeScale = 0;



    }
    public void YenidenBaslat()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("oyunBitti", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        CanvasDurum = 0;
    }

    public void OyunDurdurma()
    {
        
        YonTuslari.SetActive(false);
        MenuLogo.SetActive(false);
        skorBaslik.SetActive(false);
        CanvasDurdurma.SetActive(true);

        CanvasDurum = 1;

        tirmanmaSesi.GetComponent<AudioSource>().Pause();

        Time.timeScale = 0;



    }

    public void OyunDevam()
    {

        Time.timeScale = 1;
        MenuLogo.SetActive(true);
        CanvasDurdurma.SetActive(false);
        YonTuslari.SetActive(true);
        skorBaslik.SetActive(true);
        CanvasDurum = 0;

       

        
    }






}
