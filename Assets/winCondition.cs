using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//William Harvey
//Erik Buck
//CS3900
//An attempt at a tilting maze game. I tried to give a timer and teleporting pegs you could hit.
public class winCondition : MonoBehaviour
{
    
    public bool wincon;
    public Rigidbody ball;
    
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        wincon = false;
    }
    //only way I could think of to trigger the win
    public void OnTriggerEnter(Collider collider)
    {
        wincon = true;             
    }
}
