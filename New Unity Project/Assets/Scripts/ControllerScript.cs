using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

    public Sprite leftTruck;
    public Sprite rightTruck;
    public Sprite forwardTruck;
	
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
            GetComponent<SpriteRenderer>().sprite = forwardTruck;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.DownArrow)) // down
        {
            GetComponent<SpriteRenderer>().sprite = forwardTruck;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1), ForceMode2D.Impulse);
            
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // left
        { 
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
            GetComponent<SpriteRenderer>().sprite = leftTruck;
        }
        if (Input.GetKey(KeyCode.RightArrow)) // right
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
            GetComponent<SpriteRenderer>().sprite = rightTruck;
        }
        
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            GetComponent<SpriteRenderer>().sprite = forwardTruck;


	}
}
