using UnityEngine;
using System.Linq;
using System.Collections.Generic;

/// <summery>
/// Parallax scrolling script that should be assigned to a layer
/// </summery>
public class ScrollingScript : MonoBehaviour {

	//scrolling speed
    public Vector2 speed = new Vector2(10, 10);

    //direction
    public Vector2 direction = new Vector2(-1, 0);

    //apply movement to camera
    public bool isLinkedToCamera = false;

    //enable infinite scrolling
    public bool isLooping = false;

    //list of children with a renderer
    private List<Transform> backgroundPart;

    void Start()
    {
        //infinite background only
        if (isLooping)
        {
            //get all the children of the layer with a renderer
            backgroundPart = new List<Transform>();
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                
                //add only the visible children
                if (child.GetComponent<Renderer>() != null)
                {
                    backgroundPart.Add(child);
                }
            }
        }

        //sort by position
        /*
         * Note: get the children from the top to the bottom
         * we would need to add a few condtition to handel
         * all the possible scrolling conditions
         */

        backgroundPart = backgroundPart.OrderBy( t => t.position.y).ToList();
    }

    void Update()
    {
        // Movement
        Vector3 movement = new Vector3(
          speed.x * direction.x,
          speed.y * direction.y,
          0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        // Move the camera
        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }

        // 4 - Loop
        if (isLooping)
        {
            // Get the first object.
            // The list is ordered from left (x position) to right.
            Transform firstChild = backgroundPart.FirstOrDefault();

            if (firstChild != null)
            {
                // Check if the child is already (partly) before the camera.
                // We test the position first because the IsVisibleFrom
                // method is a bit heavier to execute.
                if (firstChild.position.y < Camera.main.transform.position.y)
                {
                    // If the child is already on the left of the camera,
                    // we test if it's completely outside and needs to be
                    // recycled.
                    if (firstChild.GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
                    {
                        // Get the last child position.
                        Transform lastChild = backgroundPart.LastOrDefault();
                        Vector3 lastPosition = lastChild.transform.position;
                        Vector3 lastSize = (lastChild.GetComponent<Renderer>().bounds.max - lastChild.GetComponent<Renderer>().bounds.min);

                        // Set the position of the recyled one to be AFTER
                        // the last child.
                        // Note: Only work for horizontal scrolling currently.
                        firstChild.position = new Vector3(firstChild.position.x, lastPosition.y + lastSize.y, firstChild.position.z);

                        // Set the recycled child to the last position
                        // of the backgroundPart list.
                        backgroundPart.Remove(firstChild);
                        backgroundPart.Add(firstChild);
                    }
                }
            }
        }
    }
    

}
