using UnityEngine;
using System.Collections;

// This script is contained by the "controller" object in level 1.
public class LoadLevel : MonoBehaviour 
{
    int currentLevel; // the current level
	int orbs; // the number of orbs of light initially on the level
    int par; // the par of the level
    GameObject playerSphere;
	
	// To stop the controller from being destroyed on load
	void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
	
	// Use this for initialization
	void Start() 
	{
		currentLevel = 1;
		orbs = 1;
        par = currentLevel + 2;
        playerSphere = GameObject.Find("PlayerSphere");
	}
	
	// Update is called once per frame
	void Update() 
	{
        // The playerSphere will be destroyed on each level load, so the following if statement
        // ensures that we always have a reference to the current level's playerSphere.
        if (playerSphere == null)
            playerSphere = GameObject.Find("PlayerSphere");
        // if all the orbs have been collected, set the current level to the next level,
        // increase the par, reset score to 0, increment orbs by 2 and load the next level.
		// The values for par and the number of orbs are off the top of my head, if our readme
		// has specific numbers, just adjust these values to reflect those.
		if (playerSphere.GetComponent<PlayerSphereScript>().Collected() == orbs){
            currentLevel++;
            par = par + 1;
            orbs = orbs + 2;
			// To allow this method to load a new scene, use File -> Build Settings
			// to add the scenes you have made to the list of levels.
			Application.LoadLevel("Level " + currentLevel);
		}
	}

    // Method used by HUD to acccess the par.
    public int Par() {
        return par;
    }
}
