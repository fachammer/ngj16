using UnityEngine;
using System.Collections;

public class Controlls : MonoBehaviour
{
    public bool ControlsEnabled = true;
    public enum PlayerNo {WSAD, ARROWS, XBOX, NUM };
    public PlayerNo PlayerNumber = PlayerNo.WSAD;

    public float Speed = 100.0f;
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
        if(!ControlsEnabled)
            return;

        float RightY = 0.0f;
        float RightX = 0.0f;

        if(PlayerNumber == PlayerNo.WSAD)
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
        else if(PlayerNumber == PlayerNo.ARROWS)
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
        else if(PlayerNumber == PlayerNo.XBOX)
        {
            RightX = Input.GetAxis("Horizontal");
            RightY = Input.GetAxis("Vertical");
            RightY = -RightY;
        }else if(PlayerNumber == PlayerNo.NUM)
        {
            if(Input.GetKey(KeyCode.Keypad1))
                RightX = -1.0f;
            if(Input.GetKey(KeyCode.Keypad3))
                RightX = 1.0f;

            if(Input.GetKey(KeyCode.Keypad5))
                RightY = -1.0f;
            if(Input.GetKey(KeyCode.Keypad2))
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
    }
}
