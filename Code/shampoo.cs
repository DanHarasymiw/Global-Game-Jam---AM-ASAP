using UnityEngine;
using System.Collections;

public class shampoo : MonoBehaviour {

    public float penalty = 5;
    showerGame game;
    GameManager manager;
    public GameObject explosion;

    AudioSource failingSound;

    bool movedUp = false;


    void OnMouseDown()
    {
        if (gameObject.tag == "correct")
        {
            Debug.Log("next level");
            GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            game.loadNextLevel();
        }
        else
        {
            manager.time -= penalty;
            failingSound.Play();
            Destroy(gameObject);
        }
    }

    void OnMouseOver()
    {
        if (!movedUp)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            movedUp = true;
        }

    }

    void OnMouseExit()
    {
        if (movedUp)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            movedUp = false;
        }

    }

	// Use this for initialization
	void Start ()
    {
        game = GameObject.Find("showerGame").GetComponent<showerGame>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        failingSound = GameObject.Find("WrongSound").GetComponent<AudioSource>();
	}
}
