using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour 
{
	
	string nextLevel;
	
	// Use this for initialization
	void Start() 
	{
		nextLevel = "n";
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(Input.GetKey(nextLevel)){
			Application.LoadLevel("Level 2");	
		}
	}
}
