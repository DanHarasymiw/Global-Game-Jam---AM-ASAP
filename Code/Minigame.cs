using UnityEngine;
using System.Collections;

public class Minigame : MonoBehaviour {
    public GameManager manager;
    public int level;
    public float instructionTime = 5;
    public string instructions;
    bool soundPlaying = false;
    float nextLevelTimer = 1;
    bool loadNext = false;
    public Texture2D controls;

	public virtual void Start () {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Debug.Log("Start");
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        level = manager.level;
        nextLevelTimer = 2;
	}
	
	// Update is called once per frame
	public virtual void Update () {
        float timeToSubtract = Time.deltaTime * (level * 0.1f + 1);
        manager.time -= timeToSubtract;

        if (loadNext)
        {
            nextLevelTimer -= Time.deltaTime;
            manager.time += Time.deltaTime;
            if (nextLevelTimer < 0)
            {
                manager.loadNextLevel();
            }

        }
	}

    public virtual void loadNextLevel()
    {
        Debug.Log("sdlkjhsdjlkfsdf");
        loadNext = true;
        if (Application.loadedLevel != 10)
        {
            if (!soundPlaying)
            {
                soundPlaying = true;
                manager.gameObject.GetComponent<AudioSource>().Play();
            }

        }

         
    }

    public void OnGUI()
    {
        if (Application.loadedLevel != 10)
        {
            instructionTime -= Time.deltaTime;
            if (instructionTime > 0)
            {
                manager.instructionStyle.alignment = TextAnchor.UpperCenter;
                manager.instructionStyle.normal.textColor = Color.blue;

                GUI.DrawTexture(new Rect(0, 53, Screen.width, 75), manager.backgroundTexture);
                GUI.Label(new Rect(Screen.width / 2 - 50, 53, 100, 50), instructions, manager.instructionStyle);
                GUI.DrawTexture(new Rect(Screen.width - 75, 60, 60, 50), controls);
            }
        }

    }
}
