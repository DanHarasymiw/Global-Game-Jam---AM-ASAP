using UnityEngine;
using System.Collections;

public class DressingControls : MonoBehaviour {
    public float speed = 3;
    Dressing dressing;
	// Use this for initialization
	void Start () {
        dressing = GameObject.Find("DressingGame").GetComponent<Dressing>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        } 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("------------------COLLISION---------------");
        if (other.tag == "correctHat")
        {
            Destroy(other);
            dressing.putOnHat();
        }
        else if (other.tag == "correctShirt")
        {
            Destroy(other);
            dressing.putOnShirt();
        }
        else if (other.tag == "correctPants")
        {
            Destroy(other);
            dressing.putOnPants();
        }

    }

}
