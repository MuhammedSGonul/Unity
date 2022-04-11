using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectDestroy : MonoBehaviour
{
    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
