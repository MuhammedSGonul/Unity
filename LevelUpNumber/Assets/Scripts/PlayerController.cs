using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    [SerializeField] PlayerCollider PlayerCollider;

    [SerializeField] public GameObject PlayerFollower;

    bool touched;
    int touchCounter = 0;
    float touchOriginX, playerOriginX, targetPlayerPosX, borderX, firstYPos;

    [HideInInspector] public float speed = 0.8f;


    void Start()
    {
        borderX = PlayerFollower.transform.position.x;
        firstYPos = PlayerFollower.transform.position.y;
    }


    void Update()
    {
        if (!GameManager.isGameOver && !PlayerCollider.isLastGateCome)
        {
            FakeTouch();
            DragMovement();
        }
        else if (!GameManager.isGameOver && PlayerCollider.isLastGateCome)
        {
            goCenterStraight();
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

        if (targetPlayerPosX > borderX + 3f) targetPlayerPosX = borderX + 3f;
        if (targetPlayerPosX < borderX - 3f) targetPlayerPosX = borderX - 3f;


        PlayerFollower.transform.position = new Vector3(targetPlayerPosX, firstYPos, PlayerFollower.transform.position.z + (speed * Time.deltaTime * 10));
        PlayerFollower.transform.rotation = Quaternion.Euler(0, 0, 0);


    }

    void goCenterStraight()
    {
        PlayerFollower.transform.position = new Vector3(0, firstYPos, PlayerFollower.transform.position.z + (speed * Time.deltaTime * 10));
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
