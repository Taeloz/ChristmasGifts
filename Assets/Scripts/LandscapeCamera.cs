using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeCamera : MonoBehaviour
{
    float originalWidth = 1920.0f;
    float originalHeight = 1080.0f;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Camera>().aspect = (originalWidth / originalHeight) * (Screen.width / Screen.height);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
