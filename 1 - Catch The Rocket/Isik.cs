using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isik : MonoBehaviour
{

    public Light atmosferIsigi;
    public Transform Karakter;
    public Transform isikAzaltma;
    public Light roketIsigi1, roketIsigi2, roketIsigi3, roketIsigi4, roketIsigi5, roketIsigi6, roketIsigi7, roketIsigi8, roketIsigi9, roketIsigi10;
    int arkaPlanTest;

    void Start()
    { 
    arkaPlanTest = OyunYoneticisi.arkaPlanRandom;


        if (Karakter.transform.position.y > isikAzaltma.transform.position.y && (arkaPlanTest == 1 || arkaPlanTest == 3 || arkaPlanTest == 4))
        {
            atmosferIsigi.GetComponent<Light>().intensity = atmosferIsigi.GetComponent<Light>().intensity - 0.1f;
            isikAzaltma.transform.position = new Vector2(0.2f, isikAzaltma.transform.position.y + 0.7f);

            roketIsigi1.GetComponent<Light>().intensity = roketIsigi1.GetComponent<Light>().intensity + 0.1f;
            roketIsigi2.GetComponent<Light>().intensity = roketIsigi2.GetComponent<Light>().intensity + 0.1f;
            roketIsigi3.GetComponent<Light>().intensity = roketIsigi3.GetComponent<Light>().intensity + 0.1f;
            roketIsigi4.GetComponent<Light>().intensity = roketIsigi4.GetComponent<Light>().intensity + 0.1f;
            roketIsigi5.GetComponent<Light>().intensity = roketIsigi5.GetComponent<Light>().intensity + 0.1f;
            roketIsigi6.GetComponent<Light>().intensity = roketIsigi6.GetComponent<Light>().intensity + 0.1f;
            roketIsigi7.GetComponent<Light>().intensity = roketIsigi7.GetComponent<Light>().intensity + 0.1f;
            roketIsigi8.GetComponent<Light>().intensity = roketIsigi8.GetComponent<Light>().intensity + 0.1f;
            roketIsigi9.GetComponent<Light>().intensity = roketIsigi9.GetComponent<Light>().intensity + 0.1f;
            roketIsigi10.GetComponent<Light>().intensity = roketIsigi10.GetComponent<Light>().intensity + 0.1f;


            if (roketIsigi1.GetComponent<Light>().intensity > 1.3f && roketIsigi2.GetComponent<Light>().intensity > 1.3f && roketIsigi3.GetComponent<Light>().intensity > 1.3f && roketIsigi4.GetComponent<Light>().intensity > 1.3f &&
                roketIsigi5.GetComponent<Light>().intensity > 1.3f && roketIsigi6.GetComponent<Light>().intensity > 1.3f &&
                roketIsigi7.GetComponent<Light>().intensity > 1.3f && roketIsigi8.GetComponent<Light>().intensity > 1.3f && 
                roketIsigi9.GetComponent<Light>().intensity > 1.3f && roketIsigi10.GetComponent<Light>().intensity > 1.3f)
            {
                roketIsigi1.GetComponent<Light>().intensity = 1.3f;
                roketIsigi2.GetComponent<Light>().intensity = 1.3f;
                roketIsigi3.GetComponent<Light>().intensity = 1.3f;
                roketIsigi4.GetComponent<Light>().intensity = 1.3f;
                roketIsigi5.GetComponent<Light>().intensity = 1.3f;
                roketIsigi6.GetComponent<Light>().intensity = 1.3f;
                roketIsigi7.GetComponent<Light>().intensity = 1.3f;
                roketIsigi8.GetComponent<Light>().intensity = 1.3f;
                roketIsigi9.GetComponent<Light>().intensity = 1.3f;
                roketIsigi10.GetComponent<Light>().intensity = 1.3f;

            }


            if (atmosferIsigi.GetComponent<Light>().intensity< 0)
            {
                atmosferIsigi.GetComponent<Light>().intensity = 0f;
            }
        }

        if (arkaPlanTest == 2)  // eğer gece ise
        {
                roketIsigi1.GetComponent<Light>().intensity = 1.3f;
                roketIsigi2.GetComponent<Light>().intensity = 1.3f;
                roketIsigi3.GetComponent<Light>().intensity = 1.3f;
                roketIsigi4.GetComponent<Light>().intensity = 1.3f;
                roketIsigi5.GetComponent<Light>().intensity = 1.3f;
                roketIsigi6.GetComponent<Light>().intensity = 1.3f;
                roketIsigi7.GetComponent<Light>().intensity = 1.3f;
                roketIsigi8.GetComponent<Light>().intensity = 1.3f;
                roketIsigi9.GetComponent<Light>().intensity = 1.3f;
                roketIsigi10.GetComponent<Light>().intensity = 1.3f;
                atmosferIsigi.GetComponent<Light>().intensity = 0f;
        }



    }
        
    

    
    void Update()
    {
        arkaPlanTest = OyunYoneticisi.arkaPlanRandom;


        if (Karakter.transform.position.y > isikAzaltma.transform.position.y && (arkaPlanTest == 1 || arkaPlanTest == 3 || arkaPlanTest == 4))
        {
            atmosferIsigi.GetComponent<Light>().intensity = atmosferIsigi.GetComponent<Light>().intensity - 0.1f;
            isikAzaltma.transform.position = new Vector2 (0.2f, isikAzaltma.transform.position.y + 0.7f);

            roketIsigi1.GetComponent<Light>().intensity = roketIsigi1.GetComponent<Light>().intensity + 0.1f;
            roketIsigi2.GetComponent<Light>().intensity = roketIsigi2.GetComponent<Light>().intensity + 0.1f;
            roketIsigi3.GetComponent<Light>().intensity = roketIsigi3.GetComponent<Light>().intensity + 0.1f;
            roketIsigi4.GetComponent<Light>().intensity = roketIsigi4.GetComponent<Light>().intensity + 0.1f;
            roketIsigi5.GetComponent<Light>().intensity = roketIsigi5.GetComponent<Light>().intensity + 0.1f;
            roketIsigi6.GetComponent<Light>().intensity = roketIsigi6.GetComponent<Light>().intensity + 0.1f;
            roketIsigi7.GetComponent<Light>().intensity = roketIsigi7.GetComponent<Light>().intensity + 0.1f;
            roketIsigi8.GetComponent<Light>().intensity = roketIsigi8.GetComponent<Light>().intensity + 0.1f;
            roketIsigi9.GetComponent<Light>().intensity = roketIsigi9.GetComponent<Light>().intensity + 0.1f;
            roketIsigi10.GetComponent<Light>().intensity = roketIsigi10.GetComponent<Light>().intensity + 0.1f;


            if (roketIsigi1.GetComponent<Light>().intensity > 1.3f && roketIsigi2.GetComponent<Light>().intensity > 1.3f && roketIsigi3.GetComponent<Light>().intensity > 1.3f && roketIsigi4.GetComponent<Light>().intensity > 1.3f &&
                roketIsigi5.GetComponent<Light>().intensity > 1.3f && roketIsigi6.GetComponent<Light>().intensity > 1.3f &&
                roketIsigi7.GetComponent<Light>().intensity > 1.3f && roketIsigi8.GetComponent<Light>().intensity > 1.3f && 
                roketIsigi9.GetComponent<Light>().intensity > 1.3f && roketIsigi10.GetComponent<Light>().intensity > 1.3f)
            {
                roketIsigi1.GetComponent<Light>().intensity = 1.3f;
                roketIsigi2.GetComponent<Light>().intensity = 1.3f;
                roketIsigi3.GetComponent<Light>().intensity = 1.3f;
                roketIsigi4.GetComponent<Light>().intensity = 1.3f;
                roketIsigi5.GetComponent<Light>().intensity = 1.3f;
                roketIsigi6.GetComponent<Light>().intensity = 1.3f;
                roketIsigi7.GetComponent<Light>().intensity = 1.3f;
                roketIsigi8.GetComponent<Light>().intensity = 1.3f;
                roketIsigi9.GetComponent<Light>().intensity = 1.3f;
                roketIsigi10.GetComponent<Light>().intensity = 1.3f;

            }


            if (atmosferIsigi.GetComponent<Light>().intensity < 0)
            {
                atmosferIsigi.GetComponent<Light>().intensity = 0f;
            }
        }

        if (arkaPlanTest == 2)  // eğer gece ise
        {
                roketIsigi1.GetComponent<Light>().intensity = 1.3f;
                roketIsigi2.GetComponent<Light>().intensity = 1.3f;
                roketIsigi3.GetComponent<Light>().intensity = 1.3f;
                roketIsigi4.GetComponent<Light>().intensity = 1.3f;
                roketIsigi5.GetComponent<Light>().intensity = 1.3f;
                roketIsigi6.GetComponent<Light>().intensity = 1.3f;
                roketIsigi7.GetComponent<Light>().intensity = 1.3f;
                roketIsigi8.GetComponent<Light>().intensity = 1.3f;
                roketIsigi9.GetComponent<Light>().intensity = 1.3f;
                roketIsigi10.GetComponent<Light>().intensity = 1.3f;
                atmosferIsigi.GetComponent<Light>().intensity = 0f;
        }



    }
}
