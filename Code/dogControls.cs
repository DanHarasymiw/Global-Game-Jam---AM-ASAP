using UnityEngine;
using System.Collections;

public class dogControls : MonoBehaviour
{
    public float speed = 2;
    FeedingDog feedingDog;
    // Use this for initialization
    void Start()
    {
        feedingDog = GameObject.Find("FeedingDog").GetComponent<FeedingDog>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
