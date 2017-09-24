using UnityEngine;
using System.Collections;

public class Clothes : MonoBehaviour {
    public float fallSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
	}
}
