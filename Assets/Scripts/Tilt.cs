using UnityEngine;
using UnityEngine.Assertions;

public class Tilt : MonoBehaviour {
    
    public float maxTilt;
    public LimitVelocity limitVelocity;
    public Rigidbody2D tiltingRigidbody;
    
    private void Awake() {
        Assert.IsNotNull(limitVelocity);
        Assert.IsNotNull(tiltingRigidbody);
    }
    
    private void LateUpdate() {
        var tiltingFactor = tiltingRigidbody.velocity.magnitude / limitVelocity.MaximumSpeed;
        var direction = Mathf.Sign(tiltingRigidbody.velocity.x);
        
        var tilt = direction * Mathf.Lerp(tiltingFactor, 0, maxTilt);
        
        tiltingRigidbody.transform.rotation = Quaternion.Euler(0, 0, tilt);
    }
}

