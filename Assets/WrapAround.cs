using UnityEngine;
using System.Collections;

public class WrapAround : MonoBehaviour {

    public float TeleportationMargin = 3.0f;

    private GameObject _destination;


	// Use this for initialization
	void Start () {
        if(this.gameObject.name == "LeftEdge")
            _destination = GameObject.Find("RightEdge");
        else if(this.gameObject.name == "RightEdge")
            _destination = GameObject.Find("LeftEdge");
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
        print(this.gameObject.name);
        TeleportationMargin = gameObject.GetComponent<CircleCollider2D>().bounds.size.magnitude;
        print("tm"+TeleportationMargin);
        if(this.gameObject.name == "LeftEdge" || this.gameObject.name == "RightEdge")
        {
            float newX = _destination.transform.position.x;
            print("ö"+newX);
            newX += (this.gameObject.name == "LeftEdge") ? -TeleportationMargin : TeleportationMargin;
            print("n"+newX);
            gameObject.transform.position = new Vector3(newX, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if(this.gameObject.name == "TopEdge" || this.gameObject.name == "BottomEdge")
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, _destination.transform.position.y, gameObject.transform.position.z);
        else
            Debug.LogWarning("bad name for the edges");
    }
}
