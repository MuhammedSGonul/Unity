using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaplanHareketEtme : MonoBehaviour
{
    public float suruklenmeHizi;
    public Renderer rend;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.mainTextureOffset += new Vector2(suruklenmeHizi * Time.deltaTime, suruklenmeHizi * Time.deltaTime);
    }
}
