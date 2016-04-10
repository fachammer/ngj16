using UnityEngine;
using System.Collections;

public class satellite_radarbeep_behavior : MonoBehaviour {

    private SpriteRenderer spr;
    private float a;

    // Use this for initialization
    void Start () {
        a = 1;
        spr = gameObject.GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {

        transform.localScale += new Vector3(0.05f,0.05f,0);
        //int x;
        //x = 100;
        //mat.color.a =0.5f;
        // gameObject.renderer.material.color.a;
        
        a -= 0.02f;
        //Debug.Log(a);
        spr.material.color = new Color(spr.material.color.r, spr.material.color.g, spr.material.color.b, a);
        if (a <= 0) {
            Destroy(gameObject);
        }

    }
}
