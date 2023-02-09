using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//William Harvey
//Erik Buck
//CS3900
//An attempt at a tilting maze game. I tried to give a timer and teleporting pegs you could hit.
public class teleporter : MonoBehaviour
{
    public Rigidbody ball;
    public int ID;
    float delay = 0;
   
    void Update()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
    }
   public void OnTriggerEnter(Collider collider)
    {
        if ( delay <= 0)
        {
            foreach (teleporter tp in FindObjectsOfType<teleporter>())
            {
                //each red portal is linked
                if (tp.ID == ID && tp != this)
                {
                    tp.delay = 2;
                    
                    Vector3 Position = tp.gameObject.transform.position;
                    Position.z += 1;
                    Position.x += 1;
                    collider.gameObject.transform.position = Position;
                }
            }
        }
    }
}
