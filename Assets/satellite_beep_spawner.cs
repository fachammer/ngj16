using UnityEngine;
using System.Collections;

public class satellite_beep_spawner : MonoBehaviour {

    public GameObject beep;
    private float currentTime;
    public float spawnDelay;
    private GameObject followObject;
    private GameObject bleep;
    public bool chasing;

	// Use this for initialization
	void Start () {
        chasing = false;
        currentTime = Time.time;
        followObject = transform.parent.gameObject.transform.Find("Satellite Mesh").transform.Find("followObject").gameObject;
    }

    // Update is called once per frame
    void Update() {

        transform.position = followObject.transform.position;

        if (chasing == false)
        {
            if (currentTime + spawnDelay <= Time.time)
            {
                //GameObject bleep;
                bleep = Instantiate(beep, transform.position, Quaternion.identity) as GameObject;

                currentTime = Time.time;
            }
        }

        if (bleep) { 
        bleep.transform.position = followObject.transform.position;
    }
    }

}
