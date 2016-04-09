using UnityEngine;
using System.Collections;

public class StunPlayer : MonoBehaviour {

    float StunVelocityTreshold = 16.0f;
    public float StunTime = 3.0f;

    private Rigidbody2D _rigidBody;
    private Controlls _controlls;

    // Use this for initialization
    void Start () {
        _rigidBody = GetComponent<Rigidbody2D>();
        _controlls = GetComponent<Controlls>();
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void Stun()
    {
        _controlls.ControlsEnabled = false;
        Invoke("Unstun", StunTime);
    }

    void Unstun()
    {
        _controlls.ControlsEnabled = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == 9)//ufo
        {
            float velocity = _rigidBody.velocity.magnitude;
            float otherVelocity = other.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            float veldif = velocity - otherVelocity;

            if(veldif > StunVelocityTreshold)
            {
                print(this.gameObject.name + ":i am faster so take that, veldif" + veldif);
                other.gameObject.GetComponent<StunPlayer>().Stun();
            }
            else
            {
                //print(veldif+ " - nah, too slow");
            }
        }

    }
}
