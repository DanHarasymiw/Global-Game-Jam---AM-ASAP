using UnityEngine;
using System.Collections;

public class FindItGame : Minigame
{
    bool winner = false;
    Renderer ren;

    public GameObject explosion;

	void OnMouseDown()
    {
        if (ren.isVisible)
        {
            winner = true;
            GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            loadNextLevel();
        }
    }

    void Start()
    {
        base.Start();
        instructions = "Find the keys under the socks!";
        ren = GetComponent<Renderer>();
    }

    void Update()
    {
        base.Update();
    }
}

