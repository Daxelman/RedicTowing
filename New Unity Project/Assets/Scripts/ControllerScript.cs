using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {

        // accelerometer controls
        // transform.Translate(Input.acceleration.x, Input.acceleration.y, 0);

        // keyboard controls
        if (Input.GetKey(KeyCode.UpArrow)) // up
            transform.Translate(0, 10*Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.DownArrow)) // down
            transform.Translate(0, -10*Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.LeftArrow)) // left
            transform.Translate(-10*Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.RightArrow)) // right
            transform.Translate(10*Time.deltaTime, 0, 0);
	}
}
