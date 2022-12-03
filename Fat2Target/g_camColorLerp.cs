using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g_camColorLerp : MonoBehaviour
{
    private Camera cam;
    private float cycleSeconds = 100f; // set to say 0.5f to test




    void Start()
    {
        cam = GetComponent<Camera>();
    }

 
    void Update()
    {
        cam.backgroundColor = Color.HSVToRGB(
             Mathf.Repeat(Time.time / cycleSeconds, 1f),
             0.3f,     // set to a pleasing value. 0f to 1f
             0.7f);     // set to a pleasing value. 0f to 1f
    }
}
