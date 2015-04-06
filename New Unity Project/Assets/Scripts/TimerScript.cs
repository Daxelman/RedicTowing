using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {

	// Use this for initialization
    private const float INIT_TIME_LIMIT = 15.0f; //starting time limit
    private float cycle; //amount of times the timer has cycled
    protected float timeReduction = .7f; //multiply by the number of cycles to get the amount of time taken away for the next cycle
    public float timeLimit = INIT_TIME_LIMIT; //the time limit
    protected bool timerActive = true; //if the timer is active or not

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

	
	// Update is called once per frame
	void Update () {
            timeLimit -= Time.deltaTime;
            Debug.Log(timeLimit);
            text.text = "Time: " + timeLimit;
            if (timeLimit <= 0)
            {
                cycle++; //time has cycled
                timerActive = false;
                restartTimer();
            }
	}

    
    /// <summary>
    /// Resets the timer values
    /// </summary>
    void reset()
    {
        cycle = 0;
        timeLimit = INIT_TIME_LIMIT;
        timerActive = true;
    }

    /// <summary>
    /// Restarts the timer when called. Lowers the time limit.
    /// </summary>
    void restartTimer()
    {
        if (!timerActive) //timer has been set off
        {
            if (INIT_TIME_LIMIT - cycle * timeReduction > 5)
            {
                //multiply the cycles by the reduction limit, if it's greater than 5 seconds, start the timer back up.
                timeLimit = INIT_TIME_LIMIT - cycle * timeReduction;
            }
            else
            {
                //set the time limit to 5. hard mode activate
                timeLimit = 5.0f;
            }
        }

        timerActive = true;
    }
}
