using UnityEngine;
using System.Collections;

public class DeathFloor : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<AudioSource>().Play();
        Destroy(other);
    }
}
