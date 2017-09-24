using UnityEngine;
using System.Collections;

public class Eating : Minigame {

    public int foodEaten = 0;
    public int amountOfFoodToEat = 10;
    int keyToPress;
    float penalty = 5;
    float timeEaten = 0;
    float waitTime = 0.5f;
    public GameObject explosion;

    public float alphaColor = 0;
    public float fadeInRate = 0.1f;

    public AudioSource sound;
    public AudioSource failingSound;
    bool keyGenerated = false;

	// Use this for initialization
	void Start ()
    {
        base.Start();
        Debug.Log("Eating game");
        instructions = "Press the key! Eat the food!";
        amountOfFoodToEat = GameObject.FindGameObjectsWithTag("food").Length;
        keyToPress = getNewKey();
        sound = GameObject.Find("Sound").GetComponent<AudioSource>();
        failingSound = GameObject.Find("WrongSound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
    public override void Update ()
    {
        base.Update();
        if (foodEaten >= amountOfFoodToEat)
        {
            Debug.Log("HERP A FUCKING DERP");
            Debug.Log("DANK MEMES");
            base.loadNextLevel();
        }
        if (!keyGenerated && timeEaten - waitTime >= manager.time)
        {
            keyGenerated = true;
            timeEaten = -1;
        } 
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (Input.GetKeyUp("" + i))
                {
                    if (i != keyToPress)
                    {
                        manager.time -= penalty;
                        failingSound.Play();
                    }
                    else
                    {
                        foodEaten++;
                        if (foodEaten < amountOfFoodToEat)
                        {
                            keyToPress = getNewKey();
                            alphaColor = 0;
                        } 
                        else
                        {
                            keyToPress = -1;
                        }

                        GameObject food = GameObject.FindGameObjectsWithTag("food") [0];
                        sound.Play();
                        GameObject.Instantiate(explosion, food.transform.position, Quaternion.identity);
                        Destroy(food);
                        timeEaten = manager.time;
                    }
                }
            }
        }

        alphaColor = Mathf.MoveTowards(alphaColor, 1, fadeInRate);
           
	}

    int getNewKey()
    {
        return Random.Range(0, 9);
    }

    void OnGUI()
    {
        base.OnGUI();

        manager.instructionStyle.alignment = TextAnchor.UpperCenter;
        manager.instructionStyle.normal.textColor = Color.white;
        Color color = new Color(255, 255, 255, alphaColor);
        manager.instructionStyle.normal.textColor = color;
        string keyString = keyToPress >= 0 ? keyToPress.ToString() : "";
        GUI.Label(new Rect(Screen.width / 2 - 400, Screen.height / 2 + 100, 100, 50), keyString, manager.instructionStyle); 

    }
    

}
