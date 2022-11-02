using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CubeManager : MonoBehaviour
{
    [SerializeField] private WeaponManager WeaponManager;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            int val = int.Parse(GetComponent<TextMeshPro>().text);
            val -= 1;
            WeaponManager.bulletAmount -= 1;

            GetComponent<TextMeshPro>().text = val.ToString();

            Destroy(other.gameObject);

        }    
    }
    


}