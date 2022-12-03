using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderManager : MonoBehaviour
{

    [SerializeField] private GameManager GameManager;




    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "CubeValue":
                GameManager.GameOver();
                break;
            case "Wall":
                GameManager.GameOver();
                break;
        }    
    }

}
