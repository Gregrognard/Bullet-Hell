using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera Camera = Camera.main;
        float cameraHeight = Camera.orthographicSize * 2f;
        float cameraWidth = cameraHeight * Camera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
