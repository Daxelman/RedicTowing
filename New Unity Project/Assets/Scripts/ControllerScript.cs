using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

    public Sprite leftTruck;
    public Sprite rightTruck;
    public Sprite forwardTruck;
	
	// Update is called once per frame
	void Update () {

        // accelerometer controls
        // transform.Translate(Input.acceleration.x, Input.acceleration.y, 0);

        // keyboard controls
        if (Input.GetKey(KeyCode.UpArrow)) // up
        {
            this.GetComponent<SpriteRenderer>().sprite = forwardTruck;
            transform.Translate(0, 10 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow)) // down
        {
            this.GetComponent<SpriteRenderer>().sprite = forwardTruck;
            transform.Translate(0, -10*Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // left
        {
            transform.Translate(-10 * Time.deltaTime, 0, 0);
            this.GetComponent<SpriteRenderer>().sprite = leftTruck;
        }
        if (Input.GetKey(KeyCode.RightArrow)) // right
        {
            transform.Translate(10 * Time.deltaTime, 0, 0);
            this.GetComponent<SpriteRenderer>().sprite = rightTruck;
        }
        
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            this.GetComponent<SpriteRenderer>().sprite = forwardTruck;


	}
}
