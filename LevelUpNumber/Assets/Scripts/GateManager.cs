using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GateManager : MonoBehaviour
{
    public enum Operation { Addition, Subtraction, Multiplication }
    public Operation gateOperation;


    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("IndecisiveNumber"))
        {
            TextMeshPro cubeValue = other.gameObject.GetComponent<TextMeshPro>();

            switch (gateOperation)
            {
                case Operation.Addition:
                    CounterController.number += int.Parse(cubeValue.text);
                    
                    break;

                case Operation.Subtraction:
                    CounterController.number -= int.Parse(cubeValue.text);

                    break;

                case Operation.Multiplication:
                    CounterController.number *= int.Parse(cubeValue.text);

                    break;
            }

            other.tag = "Untagged";
            Destroy(other.transform.parent.gameObject);
            PlayerCollider.collectedCube -= 1;

        }


    }



}