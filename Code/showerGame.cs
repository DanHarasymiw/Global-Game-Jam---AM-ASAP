using UnityEngine;
using System.Collections;

public class showerGame : Minigame {
	// Use this for initialization
	void Start ()
    {
        base.Start();
        Debug.Log("index is " + manager.shampooIndex);
        int index = manager.shampooIndex;
        GameObject.Find("shampoo" + index).tag = "correct";
        instructions = "Select the correct shampoo!";
    }

    void Update ()
    {
        base.Update();
    }
	
	
}
