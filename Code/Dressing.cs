using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dressing : Minigame {
    public GameObject explosion;
    public GameObject player;
    public GameObject displayHat;
    public GameObject displayShirt;
    public GameObject displayPants;

    public Transform hatPosition;
    public Transform shirtPosition;
    public Transform pantsPosition;

    public GameObject hat1, hat2, hat3, shirt1, shirt2, shirt3, pants1, pants2, pants3;

    public GameObject[] clothes;

    public bool wearingHat = false;
    public bool wearingShirt = false;
    public bool wearingPants = false;

    public float timeBetweenWaves = 3;
    public float timer = 0;

    GameObject[] spawners;

    int correctHatIndex;
    int correctShirtIndex;
    int correctPantsIndex;

	// Use this for initialization
	void Start () {
        base.Start();
        instructions = "Match the clothes on the left!";
        Debug.Log("Dressing game");
        player = GameObject.Find("Player");
        spawners = GameObject.FindGameObjectsWithTag("spawner");
        
        hatPosition = GameObject.Find("hatPosition").transform;
        shirtPosition = GameObject.Find("shirtPosition").transform;
        pantsPosition = GameObject.Find("pantsPosition").transform;

        clothes = new GameObject[9];
        clothes [0] = hat1;
        clothes [1] = hat2; 
        clothes [2] = hat3;

        clothes [3] = shirt1;
        clothes [4] = shirt2;
        clothes [5] = shirt3;

        clothes [6] = pants1;
        clothes [7] = pants2;
        clothes [8] = pants3;

        correctHatIndex = Random.Range(0, 3);
        correctShirtIndex = Random.Range(3, 6);
        correctPantsIndex = Random.Range(6, 9);

        GameObject hat = (GameObject)GameObject.Instantiate(clothes [correctHatIndex], displayHat.transform.position, Quaternion.identity);
        Destroy(hat.GetComponent<Rigidbody2D>());

        GameObject shirt = (GameObject)GameObject.Instantiate(clothes [correctShirtIndex], displayShirt.transform.position, Quaternion.identity);
        Destroy(shirt.GetComponent<Rigidbody2D>());

        GameObject pants = (GameObject)GameObject.Instantiate(clothes [correctPantsIndex], displayPants.transform.position, Quaternion.identity);
        Destroy(pants.GetComponent<Rigidbody2D>());

	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
        timer -= Time.deltaTime;

        if (wearingHat && wearingShirt && wearingPants)
        {
            loadNextLevel();
        }

        if (timer <= 0)
        {
            timer = timeBetweenWaves;

            int startIndex;
            int correctIndex;
            string correctTag;
            if (!wearingPants)
            {
                startIndex = 6;
                correctIndex = correctPantsIndex;
                correctTag = "correctPants";
            }
            else if (!wearingShirt)
            {
                startIndex = 3;
                correctIndex = correctShirtIndex;
                correctTag = "correctShirt";
            }
            else
            {
                startIndex = 0;
                correctIndex = correctHatIndex;
                correctTag = "correctHat";
            }


            List<int> clothesToSpawn = new List<int>();
            while (clothesToSpawn.Count < 3)
            {
                int randomNumber = Random.Range(startIndex, startIndex + 3);
                if (!clothesToSpawn.Contains(randomNumber))
                {
                    clothesToSpawn.Add(randomNumber);
                }
            }

            Debug.Log("The correct index is: " + correctIndex + "-----------------------------------------------------");
            for (int j = 0; j < spawners.Length; j++)
            {
                GameObject article = (GameObject) GameObject.Instantiate(clothes [clothesToSpawn [j]], spawners [j].transform.position, Quaternion.identity);
                if (clothesToSpawn [j] == correctIndex)
                {
                    article.tag = correctTag;
                }
            }


        }
	}

    public void putOnHat()
    {
        wearingHat = true;
        GameObject hat = (GameObject) GameObject.Instantiate(clothes [correctHatIndex], hatPosition.position, hatPosition.rotation);
        hat.transform.parent = player.transform;
        GameObject.Instantiate(explosion, hat.transform.position, Quaternion.identity);
        Destroy(hat.GetComponent<Rigidbody2D>());
    }

    public void putOnShirt()
    {
        wearingShirt = true;
        GameObject shirt = (GameObject) GameObject.Instantiate(clothes [correctShirtIndex], shirtPosition.position, shirtPosition.rotation);
        shirt.transform.parent = player.transform;
        GameObject.Instantiate(explosion, shirt.transform.position, Quaternion.identity);
        Destroy(shirt.GetComponent<Rigidbody2D>());
    }

    public void putOnPants()
    {
        wearingPants = true;
        GameObject pants = (GameObject) GameObject.Instantiate(clothes [correctPantsIndex], pantsPosition.position, pantsPosition.rotation);
        pants.transform.parent = player.transform;
        GameObject.Instantiate(explosion, pants.transform.position, Quaternion.identity);
        Destroy(pants.GetComponent<Rigidbody2D>());

    }
}
