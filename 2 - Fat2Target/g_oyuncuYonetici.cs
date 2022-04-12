using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class g_oyuncuYonetici : MonoBehaviour
{
    public g_oyuncuHareket oyuncuHareketAyarlari;
    public g_oyuncuFirlatma oyuncuFirlatmaAyarlari;
    public g_oyunYoneticisi oyunAyarlari;

    public float boyutOrani = 0.20f;

    public static bool oyuncuFirlatmaDuzen = false;
    public static bool oyuncuXKilit = false;
    public static bool oyuncuRotasyonKilit = true;
    public static bool oyuncuHareketKilit = false;
    public static bool oyuncuDusmanaFirlatildi = false;
    public static bool kopruyuAcButon = false;      //static değerler oyunu yeniden başlattığında hala aynı kalıyor dikkat et
    public static bool oyuncuBonusaGecti = false;
    public static bool oyuncuBonusaFirlatildi = false;

    public GameObject damageParticle1, bombaParticle;
    public static int dusmanaVurmaAdim = 0;
    int dinamiteVurmaAdim = 0;

    //bool isgrounded = true;

    public Animator kameraAnim;

    int ilkOynanisKontrol;

    void Start()
    {
        ilkOynanisKontrol = PlayerPrefs.GetInt("ilkOynanis");
    }



    void OnTriggerEnter(Collider other)
    {


        switch (other.gameObject.tag)
        {

            case "buyut":

                titresim();
                this.gameObject.transform.localScale = this.gameObject.transform.localScale + new Vector3(boyutOrani, boyutOrani, boyutOrani);
                gameObject.GetComponent<Rigidbody>().mass += 100;

                break;


            case "kucult":

                titresim();
                this.gameObject.transform.localScale = this.gameObject.transform.localScale - new Vector3(boyutOrani, boyutOrani, boyutOrani);
                if (this.gameObject.transform.localScale.x < 1)
                {
                    this.gameObject.transform.localScale = new Vector3(1, 1, 1);

                }

                gameObject.GetComponent<Rigidbody>().mass -= 100;
                if (gameObject.GetComponent<Rigidbody>().mass < 1) gameObject.GetComponent<Rigidbody>().mass = 1;

                break;


            case "oyuncuFirlatmaDuzen":
                oyuncuFirlatmaDuzen = true;
                oyuncuHareketKilit = true;
                oyuncuRotasyonKilit = false;
                break;


            case "oyuncuFirlatmaNokta":

                oyuncuHareketAyarlari.oyuncuDurdurma();
                oyuncuHareketAyarlari.oyuncuFirlatmaAnim();
                oyuncuFirlatmaAyarlari.oyuncuyuDusmanaFirlat();
                oyuncuDusmanaFirlatildi = true;
                oyuncuXKilit = true;                        // ileriye zıplarken x 0 ekseninde kalacak
                break;


            case "dusman":

                if (dusmanaVurmaAdim == 0)
                {
                    RaycastHit dusmanaVurmaNokta;
                    if (Physics.Raycast(transform.position, transform.forward, out dusmanaVurmaNokta))
                    {
                        // Debug.Log("Point of contact: " + dusmanaVurmaNokta.point);

                        Vector3 damageParticlePoz = dusmanaVurmaNokta.point;

                        Instantiate(damageParticle1, damageParticlePoz, Quaternion.identity);
                    }

                    dusmanaVurmaAdim = 1;
                }
                oyuncuHareketKilit = false;

                break;


            case "kopruyuAc":

                kopruyuAcButon = true;

                break;




            case "engel":
                oyuncuHareketAyarlari.oyuncuDurdurma();


                if (ilkOynanisKontrol == 0)
                {
                    easterEggNumerator();
                }
                else
                {
                    oyuncuHareketAyarlari.oyuncuEngeleCarpmaAnim();
                }


                oyuncuHareketKilit = true;
                kameraAnim.SetBool("titret", true);
                titresim();
                break;

            case "testereTip1":
                oyuncuHareketAyarlari.oyuncuDurdurma();



                if (ilkOynanisKontrol == 0)
                {
                    easterEggNumerator();
                }
                else
                {
                    oyuncuHareketAyarlari.oyuncuEngeleCarpmaAnim();
                }


                oyuncuHareketKilit = true;
                kameraAnim.SetBool("titret", true);
                titresim();
                break;

            case "testereTip2":
                oyuncuHareketAyarlari.oyuncuDurdurma();



                if (ilkOynanisKontrol == 0)
                {
                    easterEggNumerator();
                }
                else
                {
                    oyuncuHareketAyarlari.oyuncuEngeleCarpmaAnim();
                }


                oyuncuHareketKilit = true;
                kameraAnim.SetBool("titret", true);
                titresim();
                break;

            case "dinamit":
                oyuncuHareketAyarlari.oyuncuDurdurma();
                kameraAnim.SetBool("titret", true);
                titresim();
                oyuncuHareketKilit = true;

                if (dinamiteVurmaAdim == 0)
                {
                    Vector3 bombaParticlePoz = this.gameObject.GetComponent<Transform>().position;
                    Instantiate(bombaParticle, new Vector3(bombaParticlePoz.x, bombaParticlePoz.y + 2f, bombaParticlePoz.z), Quaternion.identity);
                    dinamiteVurmaAdim = 1;
                }

                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 100, 0);

                if (ilkOynanisKontrol == 0)
                {
                    easterEggNumerator();
                }
                else
                {
                    oyunAyarlari.oyunBittiBasarisiz();
                }

                break;


            case "lazer":
                oyuncuHareketAyarlari.oyuncuDurdurma();

                if (ilkOynanisKontrol == 0)
                {
                    easterEggNumerator();
                }
                else
                {
                    oyuncuHareketAyarlari.oyuncuEngeleCarpmaAnim();
                }

                oyuncuHareketKilit = true;
                kameraAnim.SetBool("titret", true);
                titresim();
                break;

            case "yol":
                oyuncuHareketAyarlari.oyuncuDurdurma();

                if (ilkOynanisKontrol == 0)
                {
                    easterEggNumerator();
                }
                else
                {
                    oyuncuHareketAyarlari.oyuncuEngeleCarpmaAnim();
                }


                oyuncuHareketKilit = true;
                kameraAnim.SetBool("titret", true);
                titresim();
                break;

            case "engelDuvar":
                oyuncuHareketAyarlari.oyuncuDurdurma();


                if (ilkOynanisKontrol == 0)
                {
                    easterEggNumerator();
                }
                else
                {
                    oyuncuHareketAyarlari.oyuncuEngeleCarpmaAnim();
                }


                oyuncuHareketKilit = true;
                kameraAnim.SetBool("titret", true);
                titresim();
                break;

            case "rampa":
                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 25, 0);

                break;


        }
    }

    void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "bonusMiktar":
                string bonusMiktariYazi = other.gameObject.GetComponent<TMP_Text>().text;
                g_oyunYoneticisi.bonusMiktari = int.Parse(bonusMiktariYazi);
                
                break;
        }

    }

    void easterEggNumerator()
    {


        AudioSource directedbySound = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        directedbySound.Play();
        oyunAyarlari.oyunSonuBasarisizEasterEgg();

        transform.position = new Vector3(transform.position.x, 2, transform.position.z);

        //yield return new WaitForSeconds(0.5f);
        //yield return new WaitForSeconds(3);

    }


    void titresim()
    {
        int titresimModu = PlayerPrefs.GetInt("titresimDurumu");
        if (titresimModu == 0)
        {
            Handheld.Vibrate();
        }
        else
        {

        }
    }




    public void oyuncuEngelAnimBitis()
    {
        oyunAyarlari.oyunBittiBasarisiz();
    }


    void Update()
    {


        if (oyuncuRotasyonKilit == true)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (oyuncuXKilit == true)
        {
            this.gameObject.transform.position = new Vector3(0, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }


        Vector3 oyuncuPoz = this.gameObject.GetComponent<Transform>().transform.position;

        if (oyuncuPoz.y < 0f && oyuncuPoz.y > -2f)
        {
            oyuncuHareketKilit = true;
        }

        if (oyuncuPoz.y < -2 && oyuncuDusmanaFirlatildi == false)
        {
            if (ilkOynanisKontrol == 0)
            {
                easterEggNumerator();
            }
            else
            {
                oyunAyarlari.oyuncuYereDustu();
            }
        }


        if (oyuncuBonusaFirlatildi == true && this.gameObject.GetComponent<Rigidbody>().velocity.magnitude < 2)
        {
            oyunAyarlari.oyunBittiBasarili();
        }


    }






    /*
    void OnCollisionStay(Collision theCollision)            //yerde olup olmadığını test için
    {
        if (theCollision.gameObject.tag == "yol")
        {
            isgrounded = true;
        }
    }

    void OnCollisionExit(Collision theCollision)
    {

        isgrounded = false;
    }
    */
}
