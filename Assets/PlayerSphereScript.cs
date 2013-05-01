using UnityEngine;
using System.Collections;

public class PlayerSphereScript : MonoBehaviour
{
	int collected;
    int moves;
	float speed;
	Vector3 moveTo;
    Vector3 previousPosition; // Variable to keep track of the playerSphere's previous position
    GUIStyle gameStyle;
	
	// Use this for initialization
	void Start() 
	{
		collected = 0;
		speed = 0.6F;
		moveTo = transform.position;
        previousPosition = moveTo;
        gameStyle = new GUIStyle();
        gameStyle.fontSize = 16;
        gameStyle.normal.textColor = Color.cyan;
	}
	
	// Update is called once per frame
	void Update() 
	{
        // If the mouse button is down, and the playerSphere has not moved since last update,
        if (Input.GetMouseButtonDown(0) && transform.position == previousPosition)
		{
            Vector3 mouse = Input.mousePosition;
            mouse.z = 32; 
			moveTo = Camera.main.ScreenToWorldPoint(mouse);
			moveTo = new Vector3(moveTo.x, 1.0f, moveTo.z);
            moves++;
		}
        previousPosition = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, moveTo, speed);
	}
	
	void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.tag.Equals("ExteriorWall"))
	    {
            moveTo = transform.position;
		}
		else if(collision.gameObject.tag.Equals("InteriorWall"))
		{
            moveTo = Vector3.Reflect(transform.position, collision.gameObject.transform.position);
            moveTo = new Vector3(moveTo.x, 1.0f, moveTo.z); // set y to 1
		}
		else if(collision.gameObject.tag.Equals("OrbOfLight"))
		{
			collected++;
			Destroy(collision.gameObject);
		}
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "SCORE: " + collected + "\nMOVES: " + moves, gameStyle);
    }

    public int Collected()
    {
        return collected;
    }
}
