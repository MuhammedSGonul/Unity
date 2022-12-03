using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g_colorLerp : MonoBehaviour
{
    MeshRenderer cubeMeshRenderer;
    [SerializeField] [Range(0f, 1f)] float lerpTime;
    [SerializeField] Color[] myColors;

    int colorIndex = 0;
    float t = 0f;
    int len;
    
    void Start()
    {
        cubeMeshRenderer = GetComponent<MeshRenderer>();
        len = myColors.Length;
    }

    
    void Update()
    {
        cubeMeshRenderer.material.color = Color.Lerp(cubeMeshRenderer.material.color, myColors[colorIndex], lerpTime * Time.deltaTime);
        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        if (t > 0.9f)
        {
            t = 0;
            colorIndex++;
            colorIndex = (colorIndex >= myColors.Length) ? 0 : colorIndex;
        }
        
    }
}
