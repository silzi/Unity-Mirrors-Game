using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float speed;
	
	
	void OnTriggerStay ()
    {

       
        transform.Rotate(new Vector3(0, 1, 0) * speed);
	}
}
