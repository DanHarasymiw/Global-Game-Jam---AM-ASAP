using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
    public float waitTime = 5;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        waitTime -= Time.deltaTime;

        if (waitTime < 0)
        {
            Application.LoadLevel(1);
        }
	}
}
