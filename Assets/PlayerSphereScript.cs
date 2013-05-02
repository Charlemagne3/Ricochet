using UnityEngine;
using System.Collections;

public class PlayerSphereScript : MonoBehaviour
{
	int collected;
    int moves;
	float speed;
	Vector3 moveTo;
    Vector3 previousPosition; // Variable to keep track of the playerSphere's previous position

	// Use this for initialization
	void Start() 
	{
		collected = 0;
		speed = 0.6F;
		rigidbody.constraints = RigidbodyConstraints.FreezePositionY; // to stop the y from changing
		moveTo = transform.position;
        previousPosition = moveTo;
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
            moveTo = Vector3.Reflect(previousPosition, collision.gameObject.transform.up);
            moveTo = new Vector3(moveTo.x, 1.0f, moveTo.z); // set y to 1
		}
		else if(collision.gameObject.tag.Equals("OrbOfLight"))
		{
			collected++;
			Destroy(collision.gameObject);
		}
    }

    // Used by the HUD to display how many orbs have been collected.
    public int Collected()
    {
        return collected;
    }

	// Used by the HUD to display how many moves have been made.
	public int Moves()
	{
		return moves;	
	}
}
