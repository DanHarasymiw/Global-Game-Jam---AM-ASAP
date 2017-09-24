using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Level loaded");
        Application.LoadLevel(2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
