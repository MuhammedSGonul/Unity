using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform Player;
    Animator PlayerAnimator;

    public static float speed = 1;

    private void Start()
    {
        PlayerAnimator = Player.GetComponent<Animator>();
        speed = 0;
    }

    void Update()
    {

        if (GameManager.isMove)
        {
            PlayerAnimator.SetBool("isStarted", true);
            MovementAhead();
        }
        else
        {
            PlayerAnimator.SetBool("isStarted", false);
        }

        LockPlayerRotation();

    }

    void MovementAhead()
    {
        Player.transform.position = new Vector3(0, Player.transform.position.y, Player.transform.position.z + Time.deltaTime * speed * 10);
    }

    void LockPlayerRotation()
    {
        Player.transform.rotation = Quaternion.Euler(0, 0, 0);
    }


    public void BridgeFeel()
    {
        Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 12, 0);
    }
}
