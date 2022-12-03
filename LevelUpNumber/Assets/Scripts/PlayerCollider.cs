using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollider : MonoBehaviour
{

    [SerializeField] CounterController CounterController;
    [SerializeField] GameManager GameManager;

    [HideInInspector] public static int collectedCube = 0;

    [HideInInspector] public bool isLastGateCome = false;

    private bool leftGateRotate = false, rightGateRotate = false;
    private Transform leftGateTransform, rightGateTransform;

    void Update()
    {
        cubeColliderResize();
        lastGatesSmoothRotate();
    }



    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Addition":
                CounterController.additionNumber(int.Parse(other.gameObject.GetComponent<TextMeshPro>().text));
                other.tag = "Untagged";

                Destroy(other.transform.parent.gameObject);

                break;
            case "Subtraction":
                CounterController.subtractionNumber(int.Parse(other.gameObject.GetComponent<TextMeshPro>().text));
                other.tag = "Untagged";

                Destroy(other.transform.parent.gameObject);

                break;
            case "Indecisive":
                collectedCube += 1;

                other.transform.parent.parent = transform;
                other.transform.parent.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + collectedCube);

                other.transform.eulerAngles = new Vector3(90, 0, 0);
                other.transform.localPosition = new Vector3(0, 0.0101f, 0);

                other.tag = "IndecisiveNumber";
                break;
            case "LastGatePoint":
                isLastGateCome = true;
                break;

            case "LastGateRight":
                int gateValueRight = int.Parse(other.GetComponent<TextMeshPro>().text);

                if (gateValueRight <= CounterController.number)
                {
                    rightGateTransform = other.transform.parent.parent;
                    rightGateRotate = true;
                }
                else
                {
                    GameManager.levelCompleted();
                }

                break;

            case "LastGateLeft":
                int gateValueLeft = int.Parse(other.GetComponent<TextMeshPro>().text);

                if (gateValueLeft <= CounterController.number)
                {
                    leftGateTransform = other.transform.parent.parent;
                    leftGateRotate = true;
                }
                else
                {
                    GameManager.levelCompleted();
                }

                break;



        }

    }



    void cubeColliderResize()       //for other cubes touches Indecisive cubes
    {
        gameObject.GetComponent<BoxCollider>().size = new Vector3(0.02f, 0.02f, 0.02f + (collectedCube * 0.02f));
        gameObject.GetComponent<BoxCollider>().center = new Vector3(0, 0, 0 + (collectedCube * 0.01f));
    }


    void lastGatesSmoothRotate()
    {
        if (rightGateRotate)
        {
            rightGateTransform.rotation = Quaternion.Lerp(rightGateTransform.rotation, Quaternion.Euler(0, 90, 0), 0.2f);

            if (rightGateTransform.eulerAngles.y > 85)
            {
                rightGateRotate = false;
            }
        }
        if (leftGateRotate)
        {
            leftGateTransform.rotation = Quaternion.Lerp(leftGateTransform.rotation, Quaternion.Euler(0, -90, 0), 0.2f);

            if (leftGateTransform.eulerAngles.y < -85)
            {
                leftGateRotate = false;
            }
        }
    }

}
