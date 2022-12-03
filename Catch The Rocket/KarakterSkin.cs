using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KarakterSkin : MonoBehaviour
{
    public Sprite Mami, Emirhan, Hasan, Eren, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15;
    int karakterNo;
    int u;
    public Animator anim;
    


    void Awake()
    {
        anim.enabled = false;

        int karakterNo = PlayerPrefs.GetInt("secilenKarakterNo");

        switch (karakterNo)
        {
            case 0:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Eren;
                break;
            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Eren;
                break;
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Emirhan;
                break;
            case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Hasan;
                break;
            case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Mami;
                break;
            case 5:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K5;
                break;
            case 6:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K6;
                break;
            case 7:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K7;
                break;
            case 8:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K8;
                break;
            case 9:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K9;
                break;
            case 10:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K10;
                break;
            case 11:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K11;
                break;
            case 12:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K12;
                break;
            case 13:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K13;
                break;
            case 14:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K14;
                break;
            case 15:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K15;
                break;

        }
        
    }


    public void animac()
    {
        anim.enabled = true;
    }
    public void animkapa()
    {
        anim.enabled = false;
    }


    void Update()
    {
        int karakterNo = PlayerPrefs.GetInt("secilenKarakterNo");

        switch (karakterNo)
        {
            case 0:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Eren;
                break;
            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Eren;
                break;
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Emirhan;
                break;
            case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Hasan;
                break;
            case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Mami;
                break;
            case 5:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K5;
                break;
            case 6:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K6;
                break;
            case 7:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K7;
                break;
            case 8:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K8;
                break;
            case 9:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K9;
                break;
            case 10:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K10;
                break;
            case 11:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K11;
                break;
            case 12:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K12;
                break;
            case 13:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K13;
                break;
            case 14:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K14;
                break;
            case 15:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = K15;
                break;
        }



    }





}
