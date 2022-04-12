using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dusmanKontrol : MonoBehaviour
{
    
    public static Vector3 deltaPozisyon;

    Vector3 deltaPozisyon;

    void Update()
    {

      GameObject oyuncu = GameObject.FindGameObjectWithTag("oyuncu");
      deltaPozisyon = transform.position - oyuncu.transform.position;




    }

}


public class ikiBoyutAtes : MonoBehaviour
{
    
    public static bool dusmanUyari; 
    public float algilamaMesafe = 30;
    float  radHesapla, aciHesapla;

    int isaretX, isaretZ;

    void Update()
    {

      float sensor = Mathf.Sqrt(Mathf.Abs(dusmanKontrol.deltaPozisyon.x * dusmanKontrol.deltaPozisyon.x) + Mathf.Abs(dusmanKontrol.deltaPozisyon.z * dusmanKontrol.deltaPozisyon.z))

      if(sensor < algilamaMesafe)
      {
        dusmanUyari = true;
      

      if(deltaPozisyon.x > 0 && deltaPozisyon.z > 0) {isaretX = 1.0f; isaretZ = 1.0f; }
      if(deltaPozisyon.x < 0 && deltaPozisyon.z > 0) {isaretX = -1.0f; isaretZ = 1.0f; }
      if(deltaPozisyon.x < 0 && deltaPozisyon.z < 0) {isaretX = -1.0f; isaretZ = -1.0f; }
      if(deltaPozisyon.x > 0 && deltaPozisyon.z < 0) {isaretX = 1.0f; isaretZ = -1.0f; }

      dereceHesapla(deltaPozisyon.x, deltaPozisyon.z);

      GameObject firlatilanTop = Instantiate(top, Oyuncu.transform.position, Quaternion.identity) as GameObject;

      firlatilanTop.GetComponent<Rigidbody>().AddForce(new Vector3(isaretX * Mathf.Cos(radHesapla), 0, isaretZ * Mathf.Sin(radHesapla)) * topFirlatmaHizi)

      }

    }



    void dereceHesapla(float a, float b)
    {

        //a : karşı kenar   b : komşu kenar   c : hipo
        float c = Mathf.Sqrt(a * a + b * b);


        radHesapla = Mathf.Acos(b / c);
        aciHesapla = Mathf.Acos(b / c) * Mathf.Rad2Deg;
        //Debug.Log("karsi kenar : " + a + "  komsu kenar : " + b + "  hipotenus : " + c + "  beta acisi : " + aciHesapla + "  radyan acisi : " + radHesapla);

        //                      I                   a² = b² + c² - 2.b.c.cosβ
        //                     /I                   2.b.c.cosβ = b² + c² - a²
        //                    / I                   cosβ = (b² + c² - a²) / 2.b.c 
        //                   /  I                   cosβ = (b² + a² + b² -a²) / 2.b.c
        //                c /   I a                 cosβ = 2b² / 2.b.c
        //                 /    I                   cosβ = b / c
        //                /     I                   arccos(cosβ) = arccos(b / c)
        //               /β_____I                   β = arccos(b / c)
        //                  b
        //                  


    }

}

}