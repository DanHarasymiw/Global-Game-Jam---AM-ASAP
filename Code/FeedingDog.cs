using UnityEngine;
using System.Collections;

public class FeedingDog : Minigame {

    public GameObject foodBowl, foodBag, food;
    public GameObject[] targets;
    GameObject target;

    public int foodCollected = 0;
    public int foodNeeded = 10;
    public float bowlSpeed = 4;

    float resetTimer;

    public float timeBetweenGetTarget = 2;

    public float foodTimer;
    public float timeFoodDelay = 1;

    GameObject[] spawners;

    Transform spawnPoint;


    // Use this for initialization
    void Start () {
        base.Start();
        resetTimer = timeBetweenGetTarget;
        targets = GameObject.FindGameObjectsWithTag("target");
        target = targets[Random.Range(0, targets.Length)];
        spawnPoint = GameObject.Find("BagSpawnPoint").transform;
        foodBowl = GameObject.Find("Bowl");
        instructions = "Feed the dog!";
    }
	
	// Update is called once per frame
	void Update () {
        base.Update();
        if (foodCollected >= foodNeeded)
        {
            loadNextLevel();
        }

        resetTimer -= Time.deltaTime;
        if (resetTimer <= 0)
        {
            target = targets[Random.Range(0, targets.Length)];
            resetTimer = timeBetweenGetTarget;
        }

        foodTimer -= Time.deltaTime;
        if (foodTimer <= 0)
        {
            foodTimer = timeFoodDelay;
            GameObject.Instantiate(food, spawnPoint.position, Quaternion.identity);
        }
            
        float step = bowlSpeed * Time.deltaTime;
        foodBowl.transform.position = Vector2.MoveTowards(foodBowl.transform.position, target.transform.position, step);
    }

    void OnGUI()
    {
        base.OnGUI();
    }
}
