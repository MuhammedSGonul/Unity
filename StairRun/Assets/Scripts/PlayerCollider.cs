using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollider : MonoBehaviour
{

    [SerializeField] private BridgeManager BridgeManager;
    [SerializeField] GameManager GameManager;

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {

            case "BrickCluster1":
                BridgeManager.CollectBricks(BridgeManager.Type.Brick1);
                other.tag = "Untagged";
                Destroy(other.gameObject);
                break;

            case "BrickCluster2":
                BridgeManager.CollectBricks(BridgeManager.Type.Brick2);
                other.tag = "Untagged";
                Destroy(other.gameObject);
                break;

            case "BrickCluster3":
                BridgeManager.CollectBricks(BridgeManager.Type.Brick3);
                other.tag = "Untagged";
                Destroy(other.gameObject);
                break;

            case "Obstacle":
                if(BridgeManager.collectedBricks > 0)
                {
                    BridgeManager.BreakBricks();

                    gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.forward * 750);
                    gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 600);
                }
                else
                {
                    GameManager.GameOver();
                }
                
                break;

            case "FinishLine":
                GameManager.isFinished = true;
                break;
            case "Bonus":
                GameManager.isMove = false;
                GameManager.GameFinished(other.GetComponent<TextMeshPro>().text);
                break;
        }
    }



}
