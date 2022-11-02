using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);    
    }






}
