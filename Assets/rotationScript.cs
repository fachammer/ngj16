using UnityEngine;
using System.Collections;

public class rotationScript : MonoBehaviour {

    public float speed;
    private float x;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        x = Random.Range(0.0f, 1.0f);

		transform.Rotate (new Vector3(speed+ Random.Range(0.0f, 1.0f), speed + Random.Range(0.0f, 1.0f), speed + Random.Range(0.0f, 1.0f)));
	
	}
}
