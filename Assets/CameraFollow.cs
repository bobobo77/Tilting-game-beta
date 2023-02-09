using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 cam_offset;
    public Transform ball;
    
    [Range(.01f, 1.0f)]
    public float Smoothfactor = 0.5f;
   
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        cam_offset = transform.position - ball.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = ball.transform.localPosition + cam_offset;

        Vector3 change = Vector3.Lerp(transform.position, newPos, Smoothfactor);
        transform.position = change;
        
    }
}
