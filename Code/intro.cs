using UnityEngine;
using System.Collections;

public class intro : MonoBehaviour {
    float time = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        if (time < 0)
        {
            Application.LoadLevel(1);
        }

        if (Input.anyKey)
        {
            Application.LoadLevel(1);
        }

	}
}
