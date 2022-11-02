using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    [SerializeField] private Animator PlayerAnimator;
    [SerializeField] private GameObject Player;

    public void ShootAnim()
    {

        PlayerAnimator.SetBool("shoot", true);
        Player.transform.rotation = Quaternion.Euler(Player.transform.rotation.eulerAngles.x, 30, Player.transform.rotation.eulerAngles.z);

    }

    public void ShootCoolAnim()
    {

        PlayerAnimator.SetBool("shoot", false);
        Player.transform.rotation = Quaternion.Euler(Player.transform.rotation.eulerAngles.x, 0, Player.transform.rotation.eulerAngles.z);

    }

    public void DieAnim()
    {

    }


}
