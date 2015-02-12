using UnityEngine;
using System.Collections.Generic;

public class ChainLinkScript : MonoBehaviour {

 
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

        
        if (cars.Count <= 0)
        {
            cars.Add(other.gameObject);
            HingeJoint2D hj = this.gameObject.AddComponent<HingeJoint2D>();
            this.gameObject.hingeJoint.connectedBody = other.gameObject.GetComponent<Rigidbody>();
            this.gameObject.hingeJoint.useLimits = true;
            this.gameObject.hingeJoint.limits.min.Equals(-15.0f);
            this.gameObject.hingeJoint.limits.max.Equals(15.0f);
        }
        else
        {
            cars.Add(other.gameObject);
            /*HingeJoint2D hj = cars[cars.Capacity].gameObject.AddComponent<HingeJoint2D>();
            cars[cars.Capacity].gameObject.hingeJoint.connectedBody = other.gameObject.GetComponent<Rigidbody>();
            cars[cars.Capacity].gameObject.hingeJoint.useLimits = true;
            cars[cars.Capacity].gameObject.hingeJoint.limits.min.Equals(-15.0f);
            cars[cars.Capacity].gameObject.hingeJoint.limits.max.Equals(15.0f);
             */
            Debug.Log("WE LINKED!!!!");
        }
        Debug.Log("WE LINKED!!!!");

        
    }
}
