using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g_yiyecekCollider : MonoBehaviour
{
    public float donusHizi = 70f;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "oyuncu")
        {
            Destroy(this.gameObject);
        }   
    }

    void Update()
    {
        transform.Rotate(0, donusHizi * Time.deltaTime, 0);
    }

}
