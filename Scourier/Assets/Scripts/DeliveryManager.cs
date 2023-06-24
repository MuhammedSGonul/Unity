using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] PlayerColliderManager playerCollider;


    [SerializeField] private GameObject PickUpPoint, Employer, Package, PlayerFollower;
    [SerializeField] private GameObject[] Customer;
    private GameObject[] Packages;


    private bool pickedUp, dropOut, isAnimated = false;
    private int customerNo = 0;

    void Start()
    {
        Packages = new GameObject[Customer.Length];
        for (int i = 0; i < Customer.Length; i++)
        {
            Customer[i].GetComponent<Animator>().SetTrigger("waving");
            Packages[i] = Instantiate(Package, Package.transform.position, Quaternion.identity);
        }

        Employer.GetComponent<Animator>().SetTrigger("waving");

    }


    void Update()
    {
        pickedUp = playerCollider.pickedUp;
        dropOut = playerCollider.dropOut;

        if (pickedUp && !Employer.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            Employer.GetComponent<Animator>().SetTrigger("idle");

            for (int i = 0; i < Customer.Length; i++)
            {
                Packages[i].transform.parent = PlayerFollower.transform;
                Packages[i].transform.localPosition = new Vector3(0, 1 + i * 0.15f, -0.8f);
            }

        }

        if (dropOut && !isAnimated && customerNo < Customer.Length)
        {
            Customer[customerNo].GetComponent<Animator>().SetTrigger("idle");
            Destroy(Packages[Customer.Length - customerNo -1]);
            customerNo = customerNo + 1;
            isAnimated = true;
        }

        if (!dropOut)
        {
            isAnimated = false;
        }


    }




}
