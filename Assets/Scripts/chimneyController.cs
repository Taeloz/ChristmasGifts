﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chimneyController : MonoBehaviour {

    public bool isGood;

    public bool counted;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
