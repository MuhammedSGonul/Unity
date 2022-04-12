using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g_lazer : MonoBehaviour
{
    //köprüleri negatif x ekseninde başlat

    float t, sonPozX, baslangicPozisyonuX;
    public float lazerIlerlemeHizi = 0.01f;
    public float baslamaGecikmesi = 0;
    int ilerlemeYonu = 0;


    void Start()
    {
        baslangicPozisyonuX = this.gameObject.transform.position.x;
        sonPozX = -baslangicPozisyonuX;

    }


    void Update()
    {


        if (baslamaGecikmesi > 0)
        {
            t += Time.deltaTime;    //zaman frame 'i 0.2 arttığı için baslama gecikmesini 0.2 olarak girme 


            if (t > baslamaGecikmesi)
            {
                baslamaGecikmesi = 0;
                t = 0;

            }
        }


        if (ilerlemeYonu == 0 && baslamaGecikmesi == 0)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + lazerIlerlemeHizi * Time.deltaTime * 100, this.gameObject.transform.position.y, this.gameObject.transform.position.z);

            if (this.gameObject.transform.position.x > sonPozX)
            {
                ilerlemeYonu = 1;
            }
        }

        if (ilerlemeYonu == 1 && baslamaGecikmesi == 0)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - lazerIlerlemeHizi * Time.deltaTime * 100, this.gameObject.transform.position.y, this.gameObject.transform.position.z);

            if (this.gameObject.transform.position.x < baslangicPozisyonuX)
            {
                ilerlemeYonu = 0;
            }
        }

    }





}

