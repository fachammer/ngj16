using UnityEngine;
using System.Collections;

public class BounceShake : MonoBehaviour {

    private CameraShake _cameraShake;

    // Use this for initialization
    void Start () {
        _cameraShake = Camera.main.GetComponent<CameraShake>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        _cameraShake.StartShake = true;
    }
}
