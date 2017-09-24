using UnityEngine;
using System.Collections;

public class Germs : MonoBehaviour {


    public float timeToLive = 60;
    public float penalty = 5;
    public float maxAmountToSpawn = 20;
    public GameObject explosion;
    public GameManager manager;
    public int health = 5;
    public AudioSource soundAudioSource;
    Brushing brushing;
    bool isBrushing = false;

    void Start () {
        brushing = GameObject.Find("BrushingGame").GetComponent<Brushing>();
        float angle = Random.Range(0, 359);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
        soundAudioSource = GameObject.Find("Sound").GetComponent<AudioSource>(); 
	}
	
	// Update is called once per frame
	void Update () {
        timeToLive -= Time.deltaTime;

        if (timeToLive <= 0)
        {
            brushing.manager.time -= penalty;
            Destroy(gameObject);
        }
	}

    void OnMouseOver()
    {
        if (!isBrushing)
        {
            isBrushing = true;
            health--;
            if (!GetComponent<AudioSource>().isPlaying)
                GetComponent<AudioSource>().Play();
            if (health <= 0)
            {
                brushing.numberOfGermsKilled++;
                GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
                soundAudioSource.Play();
                Destroy(gameObject);
            }

        }
    }

    void OnMouseExit()
    {
        isBrushing = false;
    }
}
