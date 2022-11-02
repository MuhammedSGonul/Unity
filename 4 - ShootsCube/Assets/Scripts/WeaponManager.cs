using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private AnimationManager AnimationManager;


    private Vector3 _offset;
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private TextMeshPro BulletAmountText;


    [HideInInspector] public int bulletAmount = 50;


    private int shootCount = 0;
    private float shootTime = 0.1f, nextShoot;
    private bool isDestroyed = false;

    private void Awake() => _offset = transform.position - PlayerTransform.position;


    void Update()
    {
        BulletAmountText.text = bulletAmount.ToString();


        this.transform.position = _offset + PlayerTransform.position;

        if (isDestroyed)
        {
            AnimationManager.ShootCoolAnim();
            shootCount = 0;
        }

    }

    void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "CubeValue":
                int shootAmount = int.Parse(other.GetComponent<TextMeshPro>().text);


                if ((shootAmount >= shootCount) && (Time.time > nextShoot))
                {
                    AnimationManager.ShootAnim();
                    shootCount += 1;
                    Shoot();
                    nextShoot = shootTime + Time.time;
                    isDestroyed = false;
                }
                if (shootAmount <= 0)
                {
                    Destroy(other.gameObject);
                    isDestroyed = true;
                }

                break;

        }
    }

    void OnTriggerExit(Collider other)
    {
        AnimationManager.ShootCoolAnim();
        shootCount = 0;
    }

    void Shoot()
    {
        GameObject shootedBullet = Instantiate(Bullet, PlayerTransform.position, Quaternion.identity);
        shootedBullet.GetComponent<Rigidbody>().velocity = Vector3.forward * 50;
    }


}
