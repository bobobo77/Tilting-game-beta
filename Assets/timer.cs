using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

//William Harvey
//Erik Buck
//CS3900
//An attempt at a tilting maze game. I tried to give a timer and teleporting pegs you could hit.
public class timer : MonoBehaviour
{
    public float timeRemaining = 60;
    public bool lose;
    public Text countdown;
    public Text DisplayResult;
    public Image displayResultColor;
    private Rigidbody ball;
    public Button pressMe;
    public Text pressMeText;
    private bool pausing = true;
    public Button reset;
    public winCondition wins;
    public void start()
    {
        
        lose = false;
       
        ball = GetComponent<Rigidbody>();
        pressMe.onClick.AddListener(TimeStop);
        reset.onClick.AddListener(restart);
        
        countdown.text = timeRemaining.ToString("F2");

    }
    public void Update()
    {

        if (timeRemaining > 0)
        {

            timeRemaining -= Time.deltaTime;
            countdown.text = timeRemaining.ToString("F2");
            if(wins.wincon == true)
            {
                DisplayResult.text = "You Win!! Good job!";
                displayResultColor.color = new Color(77, 208, 225, 100);
                countdown.text = "0:00";
                Time.timeScale = 0;
                pressMe.interactable = false;
            }

        }
        else if (timeRemaining <= 0)
        {
            lose = true;
            DisplayResult.text = "You lose, too bad!";
            displayResultColor.color = new Color(255, 0, 0, 100);
            countdown.text = "0:00";
            Time.timeScale = 0;



        }

    }
    public void TimeStop()
    {
        pausing = !pausing;
        if (pausing == true && timeRemaining < 60)
        {
            DisplayResult.text = "Tilt your device to get to the end of the maze!";
            displayResultColor.color = new Color(163, 228, 150, 100);
            Time.timeScale = 0;
            pressMe.image.color = new Color(0, 255, 0, 100);
            pressMeText.text = "Start";
        }
        if ((timeRemaining >= 60) && pausing == true)
        {
            DisplayResult.text = "Tilt-a-Maze";
            displayResultColor.color = new Color(204, 255, 0, 100);
            Time.timeScale = 0;
            pressMe.image.color = new Color(0, 255, 0, 100);
            pressMeText.text = "Start";
        }
        if (pausing == false)
        {
            DisplayResult.text = "";
            displayResultColor.color = new Color(163, 228, 150, 0);
            Time.timeScale = 1;
            pressMe.image.color = new Color(255, 0, 0, 100);
            pressMeText.text = "pause";
        }
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
