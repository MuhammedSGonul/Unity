using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterHareket : MonoBehaviour
{
    int a = 0;  //Yatay düzlemde hareketleri belirlememiz için global bir değişken tanımladık 

    public Rigidbody2D karakterRigid;
    public Transform Karakter;
    public Transform Kamera;
    public Animator yurumeAnimatoru;


    public float karakterHareketHizi = 1f;


    void Start()
    {
        
    }

    
    void Update()
    {
        hareketCheck();
        merdivenInmeCheck();
    }



    void hareketCheck()
    {
        if(a == 1)      //Saga gitme
        {
            karakterRigid.velocity = new Vector2(karakterHareketHizi, karakterRigid.velocity.y);    // aslında x ekseninde hareket ediyor ancak nedensizce velocity.x de karakter yukarı doğru çıkıyordu
            Karakter.localScale = new Vector3(1.844814f, 1.844814f, 1.844814f);             //ekran yan olduğu için olabilir belki
            yurumeAnimatoru.SetFloat("YurumeAnim", 1.0f);
        }

        if(a == 2)      //Sola gitme
        {
            karakterRigid.velocity = new Vector2(-karakterHareketHizi, karakterRigid.velocity.y);
            Karakter.localScale = new Vector3(-1.844814f, 1.844814f, 1.844814f);
            yurumeAnimatoru.SetFloat("YurumeAnim", 1.0f);
        }

        if(a == 0)      //Butonları bıraktıktan sonra durması
        {
            karakterRigid.velocity = new Vector2(0f, karakterRigid.velocity.y);
            yurumeAnimatoru.SetFloat("YurumeAnim", 0.0f);
        }


            
        Karakter.rotation = Quaternion.Euler(0, 0, 0);

    }

    void merdivenInmeCheck()
    {
        if(ObjeAlgilama.sahneNo == 2 && Karakter.transform.position.x < -59.3f)   
        {
            Karakter.transform.position = new Vector3(-64.69f, -9.84f, 0);
            Kamera.transform.position = new Vector3(-74.1f, -12.59f, -10f);
            ObjeAlgilama.sahneNo = 4;
        }

        if (ObjeAlgilama.sahneNo == 4 && Karakter.transform.position.x > -63.8f)
        {
            Karakter.transform.position = new Vector3(-58.78f, -1.07f, 0);
            Kamera.transform.position = new Vector3(-50.5f, 0, -10f);
            ObjeAlgilama.sahneNo = 2;
        }

    }




    public void sagaGitme()
    {
        a = 1;
        
    }

    public void solaGitme()
    {
        a = 2;
    }

    public void yataydaDurma()
    {
        a = 0;
    }

}
