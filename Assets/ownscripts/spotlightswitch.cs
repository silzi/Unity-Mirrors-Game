using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotlightswitch : MonoBehaviour {

    private Light Spotlight;

	// Use this for initialization
	void Start () {

        Spotlight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Space))
        {
            Spotlight.enabled = !false;
        }
	}
}
