using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject truck;       //reference of the player object
    private int currentNumCars;      //number of cars attached to the tow truck
    private int previousNumCars = 0;     //number of cars attached to the tow truck during the last update

    private const int BASE_CAMERA_ORTHO_SIZE = 5;

    // Update is called once per frame
	void Update () {

        currentNumCars = truck.GetComponent<ChainLinkScript>().cars.Count;

        if (currentNumCars >= 3)
        {
            if (previousNumCars < currentNumCars) //if cars where added last time
                camera.orthographicSize++;
            if (previousNumCars > currentNumCars)
                camera.orthographicSize--;
        }

        previousNumCars = currentNumCars;

        currentNumCars = 0;
       
	}
}
