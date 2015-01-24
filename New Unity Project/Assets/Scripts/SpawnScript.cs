using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public GameObject obj;
    public GameObject parent;
    public float spawnmin = 1f;
    public float spawnmax = 2f;
    // Use this for initialization
    void Start()
    {
        spawn();
    }

    void spawn()
    {
        GameObject myObj = (GameObject)(Instantiate(obj, transform.position, Quaternion.identity));
        myObj.transform.parent = parent.transform;
        Invoke("spawn", Random.Range(spawnmin, spawnmax));
    }
}
