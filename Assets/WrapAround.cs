using UnityEngine;
using System.Collections;

public class WrapAround : MonoBehaviour {

    private GameObject _destination;

	// Use this for initialization
	void Start () {
        _destination = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "UFO")
        {
            Teleport(other.gameObject);
        }
    }

    void Teleport(GameObject gameObject)
    {
        if(this.gameObject.name == "LeftEdge" || this.gameObject.name == "RightEdge")
            gameObject.transform.position = new Vector3(_destination.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        else if(this.gameObject.name == "TopEdge" || this.gameObject.name == "BottomEdge")
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, _destination.transform.position.y, gameObject.transform.position.z);
        else
            Debug.LogWarning("bad name for the edges");
    }
}
