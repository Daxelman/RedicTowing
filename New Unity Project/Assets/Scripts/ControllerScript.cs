using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

    public Sprite leftTruck;
    public Sprite rightTruck;
    public Sprite forwardTruck;

    public int speed = 20;
	
	// Update is called once per frame
	void Update () {

        // accelerometer controls
        Vector3 dir = new Vector3(0, 0, 0);
        dir.x = Input.acceleration.x;

        if (dir.x > 0)
            GetComponent<SpriteRenderer>().sprite = leftTruck;
        if (dir.x < 0)
            GetComponent<SpriteRenderer>().sprite = rightTruck;

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        
        dir *= Time.deltaTime;
        


        // keyboard controls
        if (Input.GetKey(KeyCode.UpArrow)) // up
        {
            this.GetComponent<SpriteRenderer>().sprite = forwardTruck;
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow)) // down
        {
            this.GetComponent<SpriteRenderer>().sprite = forwardTruck;
            transform.Translate(0, -speed*Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // left
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            this.GetComponent<SpriteRenderer>().sprite = leftTruck;
        }
        if (Input.GetKey(KeyCode.RightArrow)) // right
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            this.GetComponent<SpriteRenderer>().sprite = rightTruck;
        }
        
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            this.GetComponent<SpriteRenderer>().sprite = forwardTruck;


	}
}
