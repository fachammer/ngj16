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
    public float BoostAmount = 100.0f;
    public float Drag = 0.85f;

    private Vector2 _thrustForce;
    private Rigidbody2D _rigidBody;
    private float _thrust = 0.0f;

    private LimitVelocity _limitVelocity;
    private bool _boosted = false;
    private bool _temporalBoost = false;

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _limitVelocity = GetComponent<LimitVelocity>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!ControlsEnabled)
            return;

        float RightY = 0.0f;
        float RightX = 0.0f;

        //swap wsad/xbox with boost button
        if(PlayerNumber == PlayerNo.WSAD)
        {
            if(Input.GetButton("Fire1"))
                PlayerNumber = PlayerNo.XBOX;

        }else if(PlayerNumber == PlayerNo.XBOX)
        {
            if(Input.GetKey(KeyCode.E))
                PlayerNumber = PlayerNo.WSAD;
        }

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

            if(Input.GetKey(KeyCode.E))
                Boost();
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

            if(Input.GetKey(KeyCode.RightControl))
                Boost();
        }
        else if(PlayerNumber == PlayerNo.XBOX)
        {
            RightX = Input.GetAxis("Horizontal");
            RightY = Input.GetAxis("Vertical");
            RightY = -RightY;

            if(Input.GetButton("Fire1"))
                Boost();

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

            if(Input.GetKey(KeyCode.Keypad6))
                Boost();
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

    void Boost()
    {
        if(_boosted)
            return;

        print("boost");
        _boosted = true;

        _limitVelocity.enabled = false;
        _temporalBoost = true;

        Invoke("CancelBoost", 2.0f);
    }

    void CancelBoost()
    {
        _limitVelocity.enabled = true;
        _boosted = false;
        _rigidBody.drag = Drag;
    }

    void FixedUpdate()
    {
        _rigidBody.AddRelativeForce(_thrustForce);

        if(_temporalBoost)
        {
            Vector2 boostForce = _thrustForce.normalized * BoostAmount;
            _rigidBody.AddRelativeForce(boostForce, ForceMode2D.Impulse);
            _temporalBoost = false;
            _rigidBody.drag = Drag * 10.0f;
        }
    }
}
