using UnityEngine;
using System.Collections;

public class Bowl : MonoBehaviour {

    FeedingDog feedingdog;
    public GameObject explosion;

	// Use this for initialization
	void Start () {
        feedingdog = GameObject.Find("FeedingDog").GetComponent<FeedingDog>();

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("FOOD PELLET YAHOOWOO");
        if (other.tag == "food")
        {
            GameObject food = (GameObject) GameObject.Instantiate(explosion, new Vector3(transform.position.x, transform.position.y + 1, 5), Quaternion.identity);
            Destroy(other.gameObject);
            feedingdog.foodCollected++;
        }
    }

}
