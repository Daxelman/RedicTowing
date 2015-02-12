using UnityEngine;
using System.Collections;

public class BumperScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
		//Debug.Log("WE'RE COLLIDING!!!!");
        if(!other.gameObject.CompareTag("Player"))
            Destroy(other.gameObject);
           
    }
}
