using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {

	// Use this for initialization
    protected float initTimeLimit= 10.0f; //starting time limit
    private float cycle; //amount of times the timer has cycled
    protected float timeReduction = 1.0f; //multiply by the number of cycles to get the amount of time taken away for the next cycle
    public float timeLimit; //the time limit
    protected bool timerActive = true; //if the timer is active or not

    Text text;

    void Start()
    {
        timeLimit = initTimeLimit;
        text = GetComponent<Text>();
    }

	
	// Update is called once per frame
	void Update () {
            timeLimit -= Time.deltaTime;
            //Debug.Log(timeLimit);
            text.text = "Time: " + (timeLimit % 60).ToString("00");
            if (timeLimit <= 0)
            {
                cycle++; //time has cycled
                restartTimer();
            }
	}

    
    /// <summary>
    /// Resets the timer values
    /// </summary>
    void reset()
    {
        cycle = 0;
        timeLimit = initTimeLimit;
    }

    /// <summary>
    /// Restarts the timer when called. Lowers the time limit.
    /// </summary>
    void restartTimer()
    {
            if (initTimeLimit- cycle * timeReduction > 5)
            {
                //multiply the cycles by the reduction limit, if it's greater than 5 seconds, start the timer back up.
                timeLimit = (initTimeLimit - cycle * timeReduction) % 60;
            }
            else
            {
                //set the time limit to 5. hard mode activate
                timeLimit = 5.0f;
            }
        }
    }

