using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderManager : MonoBehaviour
{

    [HideInInspector] public bool crashed = false, pickedUp = false, dropOut = false;
    [SerializeField] GameObject Player, Scooter, PlayerArea;

    [SerializeField] DeliveryManager deliveryManager;

    public Vector3 location;

    public void OnDrawGizmos()
    {
        var collider = GetComponent<Collider>();

        if (!collider)
        {
            return; // nothing to do without a collider
        }

        Vector3 closestPoint = collider.ClosestPoint(location);

        Gizmos.DrawSphere(location, 0.1f);
        Gizmos.DrawWireSphere(closestPoint, 0.1f);
    }


    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "CarClone":
                crashed = true;

                Player.transform.parent = PlayerArea.transform;
                Scooter.transform.parent = PlayerArea.transform;

                if (!Scooter.GetComponent<Rigidbody>())
                {
                    Scooter.AddComponent<Rigidbody>();
                    Scooter.GetComponent<Rigidbody>().mass = 30;
                }

                if (!Player.GetComponent<Rigidbody>())
                {
                    Player.AddComponent<Rigidbody>();
                    Player.GetComponent<Rigidbody>().mass = 80;
                }


                break;

            case "HumanClone":
                crashed = true;

                Player.transform.parent = PlayerArea.transform;
                Scooter.transform.parent = PlayerArea.transform;

                if (!Scooter.GetComponent<Rigidbody>())
                {
                    Scooter.AddComponent<Rigidbody>();
                    Scooter.GetComponent<Rigidbody>().mass = 30;
                }

                if (!Player.GetComponent<Rigidbody>())
                {
                    Player.AddComponent<Rigidbody>();
                    Player.GetComponent<Rigidbody>().mass = 80;
                }
                break;

            case "Obstacle_OpenBridge":
                crashed = true;

                Player.transform.parent = PlayerArea.transform;
                Scooter.transform.parent = PlayerArea.transform;

                if (!Scooter.GetComponent<Rigidbody>())
                {
                    Scooter.AddComponent<Rigidbody>();
                    Scooter.GetComponent<Rigidbody>().mass = 30;
                }

                if (!Player.GetComponent<Rigidbody>())
                {
                    Player.AddComponent<Rigidbody>();
                    Player.GetComponent<Rigidbody>().mass = 80;
                }

                break;

            case "Obstacle_Train":
                crashed = true;

                Player.transform.parent = PlayerArea.transform;
                Scooter.transform.parent = PlayerArea.transform;

                if (!Scooter.GetComponent<Rigidbody>())
                {
                    Scooter.AddComponent<Rigidbody>();
                    Scooter.GetComponent<Rigidbody>().mass = 30;
                }

                if (!Player.GetComponent<Rigidbody>())
                {
                    Player.AddComponent<Rigidbody>();
                    Player.GetComponent<Rigidbody>().mass = 80;
                }

                break;

            case "PickUpPoint":
                Vibration.Vibrate(50);
                pickedUp = true;
                break;

            case "DropPoint":
                Vibration.Vibrate(50);
                dropOut = true;
                break;
        }

    }


    void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "DropPoint":
                dropOut = false;
                other.tag = "Untagged";
                break;
        }    
    }


}
