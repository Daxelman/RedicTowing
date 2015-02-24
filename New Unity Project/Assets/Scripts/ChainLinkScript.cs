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

        GameObject car = other.gameObject;
        HingeJoint2D hj;
        if (cars.Count <= 0)
        {
            hj = gameObject.AddComponent<HingeJoint2D>();     //add the hinge joint to the car
            hj.useLimits = true;        //limit the swing angle of the joint
            hj.anchor = new Vector3(0f, -.25f, 0f);
            hj.limits.min.Equals(-15.0f);   //min limit
            hj.limits.max.Equals(15.0f);    //max limit
            hj.connectedBody = car.GetComponent<Rigidbody2D>(); //add the car to to the hinge joint
            car.layer = gameObject.layer;
            cars.Add(car);  //add car to list
        }
        else
        {
            GameObject carJoint = cars[cars.Count - 1];
            hj = carJoint.AddComponent<HingeJoint2D>();
            hj.useLimits = true;        //limit the swing angle of the joint
            hj.anchor = new Vector3(0f, -.25f, 0f);
            hj.limits.min.Equals(-15.0f);   //min limit
            hj.limits.max.Equals(15.0f);    //max limit
            hj.connectedBody = car.GetComponent<Rigidbody2D>(); //add the car to to the hinge joint
            car.layer = gameObject.layer;
            cars.Add(car);  //add the car to the list
            Debug.Log("WE LINKED!!!!");
        }
        Debug.Log("WE LINKED!!!!");

        
    }
}
