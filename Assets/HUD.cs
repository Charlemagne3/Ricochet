using UnityEngine;
using System.Collections;

// This script is contained by the "controller" object in level 1.
public class HUD : MonoBehaviour
{
    private GUIStyle gameStyle;
	private GameObject playerSphere;
	
	// Use this for initialization
	public void Start() 
	{
        this.gameStyle = new GUIStyle();
        this.gameStyle.fontSize = 16;
        this.gameStyle.normal.textColor = Color.cyan;
		this.playerSphere = GameObject.Find("PlayerSphere");
	}
	
	// Method which displays the HUD to the screen.
    public void OnGUI()
    {
		// Check to see if the playerSphere has been destroyed. Only necessary when changing levels.
		// Probably not the most efficient way, replace this later.
		if (this.playerSphere == null)
		{
			this.playerSphere = GameObject.Find("PlayerSphere");
		}
        // Write the player's score, moves, and par to the screen
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), 
			"SCORE: " + playerSphere.GetComponent<PlayerSphereScript>().Collected +
			"\nMOVES: " + playerSphere.GetComponent<PlayerSphereScript>().Moves() +
            "\nPAR: " + transform.gameObject.GetComponent<LoadLevel>().Par(), gameStyle);
    }
}