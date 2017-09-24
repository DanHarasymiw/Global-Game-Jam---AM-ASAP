using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour {
    public int level = 1;
    public float time = 60;
    public Font alarmClock;
    public Texture2D backgroundTexture;
    public GUIStyle instructionStyle;

    public Eating eating;
    public Dressing dressing;
    public Brushing brushing;

    bool keepObjectOnLevelLoaded = true;

    int[] games;

    int levelIndex = -1;


    public GameObject[] shampoo;
    public GameObject shampoo1, shampoo2, shampoo3, shampoo4;
    public int shampooIndex;

	void Start () {
        level = 0;
        DontDestroyOnLoad(gameObject);
        games = new int[6];

        games [0] = 3;
        games [1] = 4;
        games [2] = 5;
        games [3] = 6;
        games [4] = 7;
        games [5] = 8;

        shampoo = new GameObject[4];
        shampoo [0] = shampoo1;
        shampoo [1] = shampoo2;
        shampoo [2] = shampoo3;
        shampoo [3] = shampoo4;
        levelIndex = 100;
        loadNextLevel();

	}
	
	// Update is called once per frame
	void Update () {
        if (time < 0)
        {
            GameOver();
        }
        if (time > 60)
        {
            time = 60;
        }
	}

    public void loadNextLevel() {
        Debug.Log("ya ya did it m9 do the dew airhorn");
        if (Application.loadedLevel != 10)
            levelIndex++;
        if (levelIndex >= games.Length)
        {
            Debug.Log("WOOTS");
            levelIndex = 0;
            shuffleArray();
            time = 60;
            level++;
            shampooIndex = UnityEngine.Random.Range(0, 4);
            Debug.Log("LOAD LEVEL 9");
            Application.LoadLevel(10);
        }
        else
        {
            Debug.Log("TESTETESTESTESTEEST");
            //Application.LoadLevel(games[levelIndex]);
            Application.LoadLevel(4);
        }

    }

    void GameOver(){
        //game over stuff
        Debug.Log("YOU LOSE!!!!!");
        keepObjectOnLevelLoaded = false;
        Application.LoadLevel(9);
    }



    void OnGUI()
    {
        if (Application.loadedLevel != 10)
        {

            GUIStyle alarmStyle = new GUIStyle();
            alarmStyle.font = alarmClock;
            alarmStyle.fontSize = 50;
            alarmStyle.normal.textColor = new Color(0, 255, 0, 1);
            int hour = 7;

            int minutes = (int) (60 - Math.Round(time, 0));
            if (minutes >= 60)
            {
                hour++;
                minutes = 0;
            }
            string hourString = hour.ToString();
            string minutesString = (minutes < 10) ? ("0" + minutes.ToString()) : minutes.ToString(); 
            GUI.Label(new Rect(10, 10, 100, 20), hourString + ":" + minutesString, alarmStyle);

        }
    }

    void shuffleArray()
    {
        for (int i = 0; i < games.Length; i++)
        {
            int temp = games [i];
            int r = UnityEngine.Random.Range(i, games.Length);
            games [i] = games [r];
            games [r] = temp;
        }
    }

    void OnLevelWasLoaded(int level)
    {
        if (!keepObjectOnLevelLoaded)
        {
            Destroy(gameObject);
        }
    }

    
}
