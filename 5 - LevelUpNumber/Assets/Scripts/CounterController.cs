using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterController : MonoBehaviour
{
    [SerializeField] GameManager GameManager;

    [SerializeField] private TextMeshPro numberText;


    [HideInInspector] public static int number;



    void Update()
    {
        if(number < 0)
        {
            GameManager.overflowGameOver();
        }
        else
        {
            updateNumber();

        }





    }




    public int additionNumber(int actionNumber)
    {
        number += actionNumber;

        return number;
    }

    public int subtractionNumber(int actionNumber)
    {
        number -= actionNumber;

        return number;
        
    }


    void updateNumber()
    {
        numberText.text = number.ToString();
    }

}
