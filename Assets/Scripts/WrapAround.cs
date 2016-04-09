using UnityEngine;
using System.Collections;

public class WrapAround : MonoBehaviour
{

    public float TeleportationMargin;

    private GameObject _destination;

    // Use this for initialization
    void Start()
    {

        if (this.gameObject.name == "LeftEdge")
            _destination = GameObject.Find("RightEdge");
        else if (this.gameObject.name == "RightEdge")
            _destination = GameObject.Find("LeftEdge");
        else if (this.gameObject.name == "TopEdge")
            _destination = GameObject.Find("BottomEdge");
        else if (this.gameObject.name == "BottomEdge")
            _destination = GameObject.Find("TopEdge");
        else
            Debug.LogWarning("bad name for the edges");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Teleport(other.gameObject);
    }

    void Teleport(GameObject gameObject)
    {
        TeleportationMargin = Vector3.Scale(gameObject.GetComponent<CircleCollider2D>().bounds.size, gameObject.transform.localScale).magnitude;
        if (this.gameObject.name == "LeftEdge" || this.gameObject.name == "RightEdge")
        {
            float newX = _destination.transform.position.x;
            newX += (this.gameObject.name == "LeftEdge") ? -TeleportationMargin : TeleportationMargin;
            gameObject.transform.position = new Vector3(newX, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (this.gameObject.name == "TopEdge" || this.gameObject.name == "BottomEdge")
        {
            float newY = _destination.transform.position.y;
            newY += (this.gameObject.name == "TopEdge") ? TeleportationMargin : -TeleportationMargin;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, newY, gameObject.transform.position.z);
        }
        else
            Debug.LogWarning("bad name for the edges");
    }
}
