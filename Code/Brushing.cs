using UnityEngine;
using System.Collections;

public class Brushing : Minigame {
    public int numberOfGermsToKill = 10;
    public int numberOfGermsKilled = 0;
    GameObject[] spawners;
    public GameObject germ;

    public float timeBetweenSpawns = 60;
    public int amountToSpawnPerWave = 5;
    public float time;

    public Texture2D cursorTexture;
    private Vector2 hotSpot;
	// Use this for initialization
	void Start () {
        base.Start();
        hotSpot = new Vector2(cursorTexture.width / 10f, cursorTexture.height / 2f);
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.ForceSoftware);
        spawners = GameObject.FindGameObjectsWithTag("spawner");
        instructions = "Brush away the germs!";
        Debug.Log("brushing game");
        numberOfGermsKilled = 0;
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
        time -= Time.deltaTime;
        if (numberOfGermsKilled >= numberOfGermsToKill)
        {
            loadNextLevel();
        }

        if (time <= 0)
        {
            for (int i = 0; i < amountToSpawnPerWave; i++)
            {
                GameObject.Instantiate(germ, spawners [Random.Range(0, spawners.Length)].transform.position, Quaternion.identity);
            }
            time = timeBetweenSpawns;
        }

    }

    void OnGUI()
    {
        base.OnGUI();
    }
        
}
