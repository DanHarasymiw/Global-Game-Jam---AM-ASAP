using UnityEngine;
using System.Collections;

public class food : MonoBehaviour {
    public float fallSpeed;
    // Use this for initialization
    void Start () {

    }
   
    // Update is called once per frame
    void Update () {
        Vector2 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.x > 1F || viewPos.x < 0F || viewPos.y > 1F || viewPos.y < 0F)
        {
            Destroy(gameObject);
        }
    }
}
