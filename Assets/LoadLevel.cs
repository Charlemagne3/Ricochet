using UnityEngine;
using System.Collections;

// This script is contained by the "controller" object in level 1.
public class LoadLevel : MonoBehaviour 
{
    private int currentLevel; // the current level
	private int orbs; // the number of orbs of light initially on the level
    private int par; // the par of the level
    private GameObject playerSphere;
	
	// To stop the controller from being destroyed on load
	public void Awake() 
	{
        base.DontDestroyOnLoad(transform.gameObject);
    }
	
	// Use this for initialization
	public void Start() 
	{
		this.currentLevel = 1;
		this.orbs = 3;
        this.par = 3;
        this.playerSphere = GameObject.Find("PlayerSphere");
	}
	
	// Update is called once per frame
	public void Update() 
	{
        // The playerSphere will be destroyed on each level load, so the following if statement
        // ensures that we always have a reference to the current level's playerSphere.
        if (this.playerSphere == null)
		{
            this.playerSphere = GameObject.Find("PlayerSphere");
		}
        // if all the orbs have been collected, set the current level to the next level,
        // increase the par, reset score to 0, increment orbs by 2 and load the next level.
		// The values for par and the number of orbs are off the top of my head, if our readme
		// has specific numbers, just adjust these values to reflect those.
		if (this.playerSphere.GetComponent<PlayerSphereScript>().Collected == this.orbs)
		{
            this.currentLevel++;
			this.playerSphere.GetComponent<PlayerSphereScript>().Collected = 0;
			// To allow this method to load a new scene, use File -> Build Settings
			// to add the scenes you have made to the list of levels.
			Application.LoadLevel("Level " + this.currentLevel);
		}
	}

    // Method used by HUD to acccess the par.
    public int Par() 
	{
        return this.par;
    }
}
