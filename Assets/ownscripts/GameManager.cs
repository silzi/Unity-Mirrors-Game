using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public static GameManager Instance { get; set; } 

    public int playerColor = 0;

    public bool paused;

	private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;


        
    }

 


}
