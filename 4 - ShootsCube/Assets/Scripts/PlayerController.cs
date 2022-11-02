using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameManager GameManager;
 

    [SerializeField] public GameObject PlayerFollower;

    bool touched;
    int touchCounter = 0;
    float touchOriginX, playerOriginX, targetPlayerPosX, borderX;

    void Start()
    {
        borderX = PlayerFollower.transform.position.x;
    }


    void Update()
    {
        if (!GameManager.gameOver)
        {
            FakeTouch();
            DragMovement();
        }
    }

    void DragMovement()
    {
    
        if (touched && touchCounter == 0)
        {
            touchOriginX = Input.mousePosition.x;
            playerOriginX = PlayerFollower.transform.position.x;
            touchCounter = 1;
        }
        if (touched && touchCounter == 1)
        {
            targetPlayerPosX = playerOriginX + ((Input.mousePosition.x - touchOriginX) * 0.015f);        // sensitivity
        }
        else if (!touched)
        {
            touchCounter = 0;
        }

        if (targetPlayerPosX > borderX + 4f) targetPlayerPosX = borderX + 4f;
        if (targetPlayerPosX < borderX - 4f) targetPlayerPosX = borderX - 4f;

        PlayerFollower.transform.position = new Vector3(targetPlayerPosX, 0, PlayerFollower.transform.position.z + (0.8f * Time.deltaTime * 10));
        PlayerFollower.transform.rotation = Quaternion.Euler(0, 0, 0);



    }

    public void TouchDown()
    {

    }

    public void TouchUp()
    {

    }

    void FakeTouch()
    {
        if (Input.GetMouseButton(0))
        {
            touched = true;
        }
        else
        {
            touched = false;
        }
    }

}
