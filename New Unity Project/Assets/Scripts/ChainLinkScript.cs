using UnityEngine;
using System.Collections.Generic;

public class ChainLinkScript : MonoBehaviour {

    

    //reference to the tow truck
    public GameObject TowTruck;

    //list of cars added to truck
    public List<GameObject> cars;

    // Use this for initialization
    void Start()
    {
        //initalize the list
        cars = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        

        if (gameObject.CompareTag("Car"))
        {
            if (cars.Count <= 0)
            {
                TowTruck.AddComponent<Rigidbody2D>().hingeJoint.connectedBody = gameObject.rigidbody;

            }
        }
        Debug.Log("WE LINKED!!!!");
    }
}
