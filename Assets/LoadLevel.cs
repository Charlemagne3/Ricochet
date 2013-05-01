using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour 
{
    int currentLevel;
    GameObject playerSphere;
	
	// Use this for initialization
	void Start() 
	{
		currentLevel = 1;
        playerSphere = GameObject.Find("PlayerSphere");
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(playerSphere.GetComponent<PlayerSphereScript>().Collected() == 1){
            currentLevel++;
			Application.LoadLevel("Level " + currentLevel);	
		}
	}
}
