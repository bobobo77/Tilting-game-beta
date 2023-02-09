using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
//William Harvey
//Erik Buck
//CS3900
//An attempt at a tilting maze game. I tried to give a timer and teleporting pegs you could hit.
public class floorControls : MonoBehaviour
{
  
   
    private float speed = 10f;
    private Rigidbody ball;
   
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        ball = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //CAUTION!! The at rest position is perpendicular to the ground. Keep that in mind when playing.
        Vector3 tilt =  Vector3.zero;
        tilt.x = Input.acceleration.z;
       
        tilt.z = Input.acceleration.x;
       
        
        if (tilt.sqrMagnitude > 1)
        {
            tilt.Normalize();
        }
     
       ball.velocity = Vector3.MoveTowards(ball.velocity, tilt * speed, Time.deltaTime * speed);
        
      
    }
}
