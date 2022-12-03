using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g_dusmanCollider : MonoBehaviour
{
    public static bool dusmanYerde = false;

    void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "zemin":
                dusmanYerde = true;
                break;

        }    
    }

    void OnTriggerExit(Collider other)
    {
        dusmanYerde = false;
    }

 

}
