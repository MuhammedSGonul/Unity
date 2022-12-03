using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g_dinamit : MonoBehaviour
{

    public float baslamaGecikmesi = 0;
    float t = 0;
    float baslangicPozY, bitisPozY;
    int ilerlemeYonu = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "oyuncu")
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        baslangicPozY = this.gameObject.transform.position.y;
        bitisPozY = baslangicPozY + 0.4f;
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
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.005f * Time.deltaTime * 100, this.gameObject.transform.position.z);

            if (this.gameObject.transform.position.y > bitisPozY)
            {
                ilerlemeYonu = 1;
            }
        }

        if (ilerlemeYonu == 1 && baslamaGecikmesi == 0)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 0.005f * Time.deltaTime * 100, this.gameObject.transform.position.z);

            if (this.gameObject.transform.position.y < baslangicPozY)
            {
                ilerlemeYonu = 0;
            }
        }

    }


}
