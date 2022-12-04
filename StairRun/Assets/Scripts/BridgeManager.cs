using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    [SerializeField] PlayerController PlayerController;

    [SerializeField] private GameObject CloneObjectParent, Player;
    [SerializeField] private GameObject Brick1, Brick2, Brick3;
    GameObject InstantiateBrick;
    GameObject[,] cloneBrick;

    [HideInInspector] public static int collectedBricks = 0;

    [HideInInspector] public enum Type { Brick1, Brick2, Brick3 };


    Vector2 firstPressPos, currentPress;
    bool isCreateBridge = false;


    Vector3 firstPlayerPos;       //for creating bridge 
    bool isOffsetPos = false;

    void Start()
    {
        cloneBrick = new GameObject[100, 2];     //maximum 200 bricks capacity
    }

    void Update()
    {

        if (!GameManager.isFinished)
        {
            if (Input.GetMouseButtonDown(0))
            {
                firstPressPos.y = Input.mousePosition.y;
            }
            if (Input.GetMouseButton(0))
            {
                currentPress.y = Input.mousePosition.y;

                isCreateBridge = currentPress.y - (firstPressPos.y + 30) > 0 ? true : false;
            }
            if (!Input.GetMouseButton(0))
            {
                isCreateBridge = false;
            }
        }
        else
        {
            isCreateBridge = true;
        }
        



        if (isCreateBridge && isOffsetPos)
        {
            firstPlayerPos = Player.transform.position;
            isOffsetPos = false;
        }

        if (isCreateBridge && Player.transform.position.z - firstPlayerPos.z > 0.5f && collectedBricks > 0)
        {
            CreateBridge();
            isOffsetPos = true;
        }


    }


    public void CollectBricks(Type BrickType)
    {
        InstantiateBrick = BrickType == Type.Brick1 ? Brick1
            : BrickType == Type.Brick2 ? Brick2
            : BrickType == Type.Brick3 ? Brick3
            : InstantiateBrick;

        for (int i = 0; i < 3; i++)
        {
            collectedBricks += 1;
            Transform backpack = Player.transform.GetChild(0);

            cloneBrick[collectedBricks, 0] = Instantiate(InstantiateBrick, new Vector3(backpack.position.x - 0.28f, backpack.position.y + (collectedBricks * 0.25f), backpack.position.z), Quaternion.identity);
            cloneBrick[collectedBricks, 0].transform.parent = backpack;
            cloneBrick[collectedBricks, 1] = Instantiate(InstantiateBrick, new Vector3(backpack.position.x + 0.28f, backpack.position.y + (collectedBricks * 0.25f), backpack.position.z), Quaternion.identity);
            cloneBrick[collectedBricks, 1].transform.parent = backpack;
        }
    }

    public void BreakBricks()
    {
        for (int i = 0; i < 2; i++)
        {
            if (collectedBricks > 0)
            {
                cloneBrick[collectedBricks, 1].transform.parent = CloneObjectParent.transform;
                cloneBrick[collectedBricks, 1].AddComponent<BoxCollider>();
                cloneBrick[collectedBricks, 1].AddComponent<Rigidbody>();

                cloneBrick[collectedBricks, 1].GetComponent<Rigidbody>().AddForce(Vector3.right * Random.Range(90, 300));
                cloneBrick[collectedBricks, 1].GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(90, 300));


                cloneBrick[collectedBricks, 0].transform.parent = CloneObjectParent.transform;
                cloneBrick[collectedBricks, 0].AddComponent<BoxCollider>();
                cloneBrick[collectedBricks, 0].AddComponent<Rigidbody>();

                cloneBrick[collectedBricks, 0].GetComponent<Rigidbody>().AddForce(Vector3.left * Random.Range(90, 300));
                cloneBrick[collectedBricks, 0].GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(90, 300));


                collectedBricks -= 1;
            }
        }
    }

    void CreateBridge()
    {
        PlayerController.BridgeFeel();

        Transform brickFoot = Player.transform.GetChild(1);

        cloneBrick[collectedBricks, 0].transform.position = brickFoot.transform.position;
        cloneBrick[collectedBricks, 0].transform.parent = CloneObjectParent.transform;

        cloneBrick[collectedBricks, 1].transform.position = brickFoot.transform.position;
        cloneBrick[collectedBricks, 1].transform.parent = CloneObjectParent.transform;

        collectedBricks -= 1;


    }

}
