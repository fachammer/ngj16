using UnityEngine;
using System.Collections;

public class LimitVelocity : MonoBehaviour {

    public float MaximumSpeed = 5.0f;
    public bool LimitingSpeed;//flag whether we currently limit the speed or not

    private Rigidbody2D _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //limit velocity
        float speed = Vector3.Magnitude (_rigidBody.velocity);
        if(speed > MaximumSpeed)
        {
            LimitingSpeed = true;
            _rigidBody.velocity = Vector3.ClampMagnitude(_rigidBody.velocity, MaximumSpeed);
        }
        else
        {
            LimitingSpeed = false;
        }

    }
}
