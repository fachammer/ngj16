using UnityEngine;
using System.Collections;

public class collisionScript : MonoBehaviour {

    public GameObject satellite;

    public RandomMover rndm;
    public satellite_beep_spawner spwn;
    public rotationScript rotScript;

	// Use this for initialization
	void Start () {

        /*
        satellite = transform.parent.gameObject.transform.Find("satelliteParent").transform.Find("satellite Mesh").gameObject;
        rndm = satellite.GetComponent<RandomMover>();
        spwn = satellite.GetComponent<satellite_beep_spawner>();
        */
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "player") {
            
        }
    }
}
