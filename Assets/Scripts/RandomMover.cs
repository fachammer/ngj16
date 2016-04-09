using UnityEngine;
using UnityEngine.Assertions;

public class RandomMover : MonoBehaviour {
    
    public float minAppliedForce;
    public float maxAppliedForce;
    
    public Rigidbody2D movingObject;
    
    private float speed;
    
    private void Awake() {
        Assert.IsNotNull(movingObject);
    }
    
    private void Start() {
        speed = Random.Range(minAppliedForce, maxAppliedForce);
        var direction = Random.insideUnitCircle;
        
        movingObject.AddForce(direction * speed);
    }
}