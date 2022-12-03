using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KameraTakipR : MonoBehaviour
{

    public GameObject Kokpit;   
    private Vector3 orijin;
    Vector3 TiklamaBaslangic;


    void Start()
    {
 
        orijin = transform.position - Kokpit.transform.position;
    }


    void LateUpdate()
    {
       
        transform.position = Kokpit.transform.position + orijin;
    }


}