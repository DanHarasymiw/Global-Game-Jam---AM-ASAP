using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Diary : Minigame {
    public float timer = 3;
    public float alarmDelay = 1f;
    public float alarmFade = 0.5f;
    public float alarmTimer;
    SpriteRenderer alarmSprite;
	// Use this for initialization
	void Start () {
        base.Start();
        GameObject.Instantiate(manager.shampoo [manager.shampooIndex], GameObject.Find("ShampooPosition").transform.position, Quaternion.identity);
        GameObject.Find("Day").GetComponent<Text>().text = "Day " + manager.level;
        timer = 3;
        alarmTimer = alarmDelay;
        alarmSprite = GameObject.Find("time").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
        manager.time += Time.deltaTime;
        timer -= Time.deltaTime;
        alarmTimer -= Time.deltaTime;

        if (timer < 0)
        {
            Debug.Log("ERROR---------------------------");
            loadNextLevel();
        }

        if (alarmTimer < 0)
        {
            alarmTimer = alarmDelay;
        }
        else if (alarmTimer < alarmFade)
        {
            alarmSprite.enabled = false;
        }
        else
        {
            alarmSprite.enabled = true;
        }

	}
}
