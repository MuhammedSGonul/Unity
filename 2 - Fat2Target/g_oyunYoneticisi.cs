using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class g_oyunYoneticisi : MonoBehaviour
{
    public g_oyuncuHareket oyuncuAyarlari;
    public g_oyuncuFirlatma oyuncuFirlatmaAyarlari;

    public static int oyunSonuCoin;

    public GameObject winParticle1, winParticle2, dusmanDestroyParticle;

    public GameObject powerBar3D;

    public GameObject oyunSonuBasariliPanel, oyunSonuBasarisizPanel, oyunSonuEasterEggBasarisizPanel, powerBarPanel, oyunEsnasiPanel;
    public GameObject titresimAktifImg, titresimPasifImg;

    public Transform dusman;

    Vector3 dusmanOld;


    float t = 0;


    int adim = 0;

    public static bool powerBarPanelAktif = false;


    public static bool oyunBaslatildiStatic = false;            //levellere kaldığı yerden devam etmesi olayından ötürü sürekli sahne yüklememesi için


    public static int bonusMiktari;



   

    void Awake()
    {
        int bolumSayisi = PlayerPrefs.GetInt("bolumSayisi");
        if (bolumSayisi > 3) { bolumSayisi = 0; PlayerPrefs.SetInt("bolumSayisi", 0); }         //2 bölümde bir sahne değiştirip tema değişmesini sağlıoyr
        //Debug.Log(bolumSayisi);


        if (bolumSayisi >= 0 && bolumSayisi <= 1)
        {
            PlayerPrefs.SetInt("sahneNo", 0);
        }
        else
        {
            PlayerPrefs.SetInt("sahneNo", 1);
        }

        int sahneNo = PlayerPrefs.GetInt("sahneNo");


        if(SceneManager.GetActiveScene().buildIndex == 0 && sahneNo == 1)
        {
            SceneManager.LoadScene(1);
        }
        
        if(SceneManager.GetActiveScene().buildIndex == 1 && sahneNo == 0)
        {
            SceneManager.LoadScene(0);
        }
        

        
        
    }



    public void oyunuBaslat()   //baslat butonuna bağlı
    {
        oyuncuAyarlari.oyunuBaslat();

        dusmanOld = new Vector3(dusman.position.x, dusman.position.y, dusman.position.z);

    }

    public void titresimModDegistir()
    {
        int titresimModu = PlayerPrefs.GetInt("titresimDurumu");
        if (titresimModu == 0)
        {
            PlayerPrefs.SetInt("titresimDurumu", 1);
        }
        else
        {
            PlayerPrefs.SetInt("titresimDurumu", 0);
        }
    }



    void Update()
    {
        titresimGuncelle();
        Application.targetFrameRate = 60;

        

        


        if (g_oyuncuYonetici.dusmanaVurmaAdim == 1 && adim == 0)
        {

            t += Time.deltaTime;

            if (t > 2)
            {
                if (g_dusmanCollider.dusmanYerde == false)
                {
                    oyunBittiBasarisiz();
                    adim = 1;
                }

                if (g_dusmanCollider.dusmanYerde == true)
                {
                    Destroy(dusman.gameObject);
                    dusmanYokOlmaEfekt();           // dusman yok olduktan sonra particlelar çıkacak
                    g_oyuncuYonetici.oyuncuBonusaGecti = true;
                    adim = 1;
                }

            }



        }


        if (g_kameraHareket.kameraHedefeGitti == true && adim == 1)
        {

            Time.timeScale = 0f;
            //powerBarPanel.SetActive(true);
            powerBarPanelAktif = true;

            Vector3 oyuncuPoz = GameObject.FindGameObjectWithTag("oyuncu").GetComponent<Transform>().position;

            powerBar3D.SetActive(true);
            powerBar3D.transform.position = new Vector3(0, oyuncuPoz.y + 15, dusmanOld.z+10);

            adim = 2;
        }

        if (adim == 2 && powerBarPanelAktif == false)
        {
            Time.timeScale = 1f;
            //powerBarPanel.SetActive(false);
            powerBar3D.SetActive(false);

            oyuncuFirlatmaAyarlari.oyuncuBonusFirlatma();
            adim = 3;
        }


    }


    void titresimGuncelle()
    {
        int titresimModu = PlayerPrefs.GetInt("titresimDurumu");
        if (titresimModu == 0)
        {
            titresimAktifImg.SetActive(true);
            titresimPasifImg.SetActive(false);
        }
        else
        {
            titresimAktifImg.SetActive(false);
            titresimPasifImg.SetActive(true);
        }
    }


    public void oyunBittiBasarili()
    {
        Time.timeScale = 0;
        oyunSonuBasariliPanel.SetActive(true);
        oyunEsnasiPanel.SetActive(false);
        coinHesapla();
        //PlayerPrefs.SetInt("sahneNo", SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void oyunBittiBasarisiz()
    {
        StartCoroutine(oyunSonuBasarisizGecis());
    }

    public void yeniSahneAc()
    {


        int ilkOynanisKontrol = PlayerPrefs.GetInt("ilkOynanis");

        if (ilkOynanisKontrol == 0)
        {
            PlayerPrefs.SetInt("ilkOynanis", 1);
        }

        int anaSkor = PlayerPrefs.GetInt("anaSkor");
        PlayerPrefs.SetInt("anaSkor", anaSkor + bonusMiktari);


        Time.timeScale = 1.0f;
        g_oyuncuYonetici.dusmanaVurmaAdim = 0;
        g_oyuncuYonetici.oyuncuBonusaGecti = false;
        g_oyuncuYonetici.oyuncuFirlatmaDuzen = false;
        g_oyuncuYonetici.oyuncuHareketKilit = false;
        g_oyuncuYonetici.oyuncuXKilit = false;           //static değerleri yeniden ilk değerlerine döndürüyorum
        g_oyuncuYonetici.kopruyuAcButon = false;
        g_oyuncuYonetici.oyuncuDusmanaFirlatildi = false;
        g_oyuncuYonetici.oyuncuBonusaFirlatildi = false;
        g_dusmanCollider.dusmanYerde = false;
        g_kameraHareket.kameraHedefeGitti = false;
        g_oyunYoneticisi.powerBarPanelAktif = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void bolumArttir()
    {
        int bolumSayi = PlayerPrefs.GetInt("bolumSayisi");
        PlayerPrefs.SetInt("bolumSayisi", bolumSayi + 1);
    }


    public void sahneyiYenidenAc()
    {


        int ilkOynanisKontrol = PlayerPrefs.GetInt("ilkOynanis");

        if (ilkOynanisKontrol == 0)
        {
            PlayerPrefs.SetInt("ilkOynanis", 1);
        }

        int anaSkor = PlayerPrefs.GetInt("anaSkor");
        PlayerPrefs.SetInt("anaSkor", anaSkor + bonusMiktari);


        Time.timeScale = 1.0f;
        g_oyuncuYonetici.dusmanaVurmaAdim = 0;
        g_oyuncuYonetici.oyuncuBonusaGecti = false;
        g_oyuncuYonetici.oyuncuFirlatmaDuzen = false;
        g_oyuncuYonetici.oyuncuHareketKilit = false;
        g_oyuncuYonetici.oyuncuXKilit = false;           //static değerleri yeniden ilk değerlerine döndürüyorum
        g_oyuncuYonetici.kopruyuAcButon = false;
        g_oyuncuYonetici.oyuncuDusmanaFirlatildi = false;
        g_oyuncuYonetici.oyuncuBonusaFirlatildi = false;
        g_dusmanCollider.dusmanYerde = false;
        g_kameraHareket.kameraHedefeGitti = false;
        g_oyunYoneticisi.powerBarPanelAktif = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }

    public void oyuncuYereDustu()       //aşağı düştüğü zaman
    {
        oyuncuAyarlari.oyuncuDurdurma();
        oyunBittiBasarisiz();
    }


    IEnumerator oyunSonuBasarisizGecis()
    {
        yield return new WaitForSeconds(1);
        oyunSonuBasarisizPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void oyunSonuBasarisizEasterEgg()
    {
        oyunSonuEasterEggBasarisizPanel.SetActive(true);
        Time.timeScale = 0;
    }




    void coinHesapla()
    {




        TMP_Text coinText = GameObject.FindGameObjectWithTag("UI_basariliPanel_coin").gameObject.GetComponent<TMP_Text>();
        coinText.text = bonusMiktari.ToString();

        if (adim == 3)
        {
            int anaCoin = PlayerPrefs.GetInt("anaCoinMiktar");
            PlayerPrefs.SetInt("anaCoinMiktar", anaCoin + bonusMiktari);
            adim = 4;
        }

    }


    void dusmanYokOlmaEfekt()
    {
        Instantiate(dusmanDestroyParticle, new Vector3(dusman.transform.position.x, dusman.transform.position.y + 1, dusman.transform.position.z + 1), Quaternion.identity);
        Instantiate(dusmanDestroyParticle, new Vector3(dusman.transform.position.x, dusman.transform.position.y + 1, dusman.transform.position.z + 1), Quaternion.identity);
        Instantiate(dusmanDestroyParticle, dusman.transform.position, Quaternion.identity);
        Instantiate(dusmanDestroyParticle, dusman.transform.position, Quaternion.identity);
        Instantiate(dusmanDestroyParticle, dusman.transform.position, Quaternion.identity);
        Instantiate(dusmanDestroyParticle, dusman.transform.position, Quaternion.identity);
        Instantiate(dusmanDestroyParticle, dusman.transform.position, Quaternion.identity);
        Instantiate(dusmanDestroyParticle, dusman.transform.position, Quaternion.identity);
        Instantiate(dusmanDestroyParticle, new Vector3(dusman.transform.position.x, dusman.transform.position.y + 1, dusman.transform.position.z - 1), Quaternion.identity);
        Instantiate(dusmanDestroyParticle, new Vector3(dusman.transform.position.x, dusman.transform.position.y + 1, dusman.transform.position.z - 1), Quaternion.identity);
    }

    public void globalDegiskenleriSifirla()
    {
        PlayerPrefs.DeleteAll();
    }




}
