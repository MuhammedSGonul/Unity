using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Variables


    private Vector3 _offset;
    [SerializeField] private Transform target;


    #endregion

    #region Unity callbacks

    private void Awake() => _offset = transform.position - target.position;

    void LateUpdate()
    {

        this.transform.position = _offset + target.position;

    }

    #endregion
}
