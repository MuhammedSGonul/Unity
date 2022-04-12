using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g_kameraShake : MonoBehaviour
{

    Animator kameraAnim;

    void Start()
    {
        kameraAnim = this.gameObject.GetComponent<Animator>();
    }


    void shakeDurdur()
    {
        kameraAnim.SetBool("titret", false);
        //Time.timeScale = 0;
    }



}
