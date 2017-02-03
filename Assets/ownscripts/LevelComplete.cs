using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelComplete : MonoBehaviour {

    public GameObject winWindow;

    void Start()
    {
        winWindow.SetActive(false);
    }
	
	private void OnTriggerEnter()
    {
        winWindow.SetActive(!winWindow.activeSelf);
    }
}
