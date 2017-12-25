using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickController : MonoBehaviour {

    public Sprite unselected;
    public Sprite selected;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void setSelected()
    {
        this.GetComponent<SpriteRenderer>().sprite = selected;
    }

    public void setUnselected()
    {
        this.GetComponent<SpriteRenderer>().sprite = unselected;
    }

}
