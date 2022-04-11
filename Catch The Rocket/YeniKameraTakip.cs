using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YeniKameraTakip : MonoBehaviour
{

    private OyunYoneticisi oyunYonet;

    float speedMultiple = .05f;

    public static float speed;
    private Vector3 targetPosition;
    private float distance;

    public Transform target;

    //kodu başkasından buldum çoğu şeyi bilmiyorum

    public float startLimmit = -3.6f;


    private float timer;

    void Start()
    {
        timer = 0;
    }



    void LateUpdate()
    {


        distance = target.position.y - transform.position.y;

        if (target.position.y < startLimmit)
            return;

        if (distance > 0.05f)
        {
            targetPosition = new Vector3(0.2f, target.position.y + speed + 0.3f, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
            //lerp komutu smooth efektle kamerayı oraya götürüyormuş
        }
        else
        {
            targetPosition = new Vector3(0.2f, transform.position.y , transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
        }

        timer += Time.deltaTime;
        speed = (1 + (timer / 60)) * speedMultiple;
    }
}