using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private Transform target;

    private void Awake() => offset = transform.position - target.position;

    void LateUpdate()
    {
        this.transform.position = offset + target.position;
    }

}