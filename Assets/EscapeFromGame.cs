﻿using UnityEngine;
using System.Collections;

public class EscapeFromGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
