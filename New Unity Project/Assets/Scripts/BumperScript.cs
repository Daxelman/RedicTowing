using UnityEngine;
using System.Collections;

public class BumperScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
		Debug.Log("WE'RE COLLIDING!!!!");
		
        if (gameObject.CompareTag("Car"))
            Destroy(other.gameObject.transform.parent.gameObject);
        else
            Destroy(other.gameObject);
    }
}
