using UnityEngine;
using System.Collections;

public class Controlls : MonoBehaviour
{
    public enum PlayerNo {ONE, TWO, THREE, FOUR };
    public PlayerNo PlayerNumber = PlayerNo.ONE;

    public float Speed = 100.0f;
    public float MaximumSpeed = 5.0f;
    public bool LimitingSpeed;//flag whether we currently limit the speed or not
    public float ThrustIncrement = 0.01f;
    public Vector2 ThrustForce;

    private Vector2 _thrustForce;
    private Rigidbody2D _rigidBody;
    private float _thrust = 0.0f;

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float RightY = 0.0f;
        float RightX = 0.0f;

        if(PlayerNumber == PlayerNo.ONE)
        {
            if(Input.GetKey(KeyCode.A))
                RightX = -1.0f;
            if(Input.GetKey(KeyCode.D))
                RightX = 1.0f;

            if(Input.GetKey(KeyCode.W))
                RightY = -1.0f;
            if(Input.GetKey(KeyCode.S))
                RightY = 1.0f;
        }
        else if(PlayerNumber == PlayerNo.TWO)
        {
            if(Input.GetKey(KeyCode.LeftArrow))
                RightX = -1.0f;
            if(Input.GetKey(KeyCode.RightArrow))
                RightX = 1.0f;

            if(Input.GetKey(KeyCode.UpArrow))
                RightY = -1.0f;
            if(Input.GetKey(KeyCode.DownArrow))
                RightY = 1.0f;
        }
        

        Vector2 inputAxis = new Vector2(RightX, -RightY);

        if(System.Math.Abs(inputAxis.magnitude) > 0.0f)
        {
            _thrust += ThrustIncrement;
            if(_thrust > 1.0f) _thrust = 1.0f;
        }
        else
        {
            _thrust = 0.0f;
        }

        _thrustForce = inputAxis * _thrust * Speed;

        ThrustForce = _thrustForce;
    }

    void FixedUpdate()
    {
        _rigidBody.AddRelativeForce(_thrustForce);

        //limit velocity
        float speed = Vector3.Magnitude (_rigidBody.velocity);
        if(speed > MaximumSpeed)
        {
            //print("S"+speed+" ms:"+MaximumSpeed);
            LimitingSpeed = true;
            //float brakeSpeed = speed - MaximumSpeed;  // calculate the speed decrease

            //Vector3 normalisedVelocity = _rigidBody.velocity.normalized;
            //Vector3 brakeVelocity = normalisedVelocity * brakeSpeed;  // make the brake Vector3 value

            _rigidBody.velocity = Vector3.ClampMagnitude(_rigidBody.velocity, MaximumSpeed);

            //_rigidBody.AddForce(-brakeVelocity);  // apply opposing brake force
        }
        else
        {
            LimitingSpeed = false;
        }

    }
}
