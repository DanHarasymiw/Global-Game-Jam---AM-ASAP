using UnityEngine;
using System.Collections;

public class DragItem : MonoBehaviour
{
    private bool spinning = false;
	private bool dragging = false;
	private float distance;
    private Vector2 LastPos;
    public Vector2 speed = Vector2.zero;
    Rigidbody2D rb;
    public Camera cam;
    public Transform target;
    private Vector3 lastMousePos = Vector3.zero;
    public GameObject explosion;

    void OnMouseDown()
	{
        distance = Vector2.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}

	void OnMouseUp()
	{
		dragging = false;
    }

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update ()
	{
        if (dragging) 
		{
            if (gameObject.name == "doge")
            {
                GetComponent<AudioSource>().Play();
            }
            spinning = true;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Vector2 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
            speed = Input.mousePosition - lastMousePos;

        }
        Vector2 viewPos = cam.WorldToViewportPoint(target.position);
        if (viewPos.x > 1F || viewPos.x < 0F || viewPos.y > 1F || viewPos.y < 0F)
        {
            GameObject.Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (spinning)
        {
            rb.rotation += 5f;
        }

        lastMousePos = Input.mousePosition;
    }

    void FixedUpdate()
    {
        
        if (speed.x > 5 || speed.y > 5 || speed.x < -5 || speed.y < -5)
        {
            rb.velocity = (rb.position - LastPos) / Time.deltaTime;

            LastPos = rb.position;

        }
        else
            rb.velocity = Vector2.zero;
    }
}

