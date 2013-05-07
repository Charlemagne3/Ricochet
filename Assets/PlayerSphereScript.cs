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
            RaycastHit hit;
            // Create a ray going towards the mouse's location
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // If the raycast of the ray collides with something (currently always collides with ground),
            // move to the collision point's x and z coordinates and increment moves.
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                moveTo = new Vector3(hit.point.x, 1.0f, hit.point.z);
                moves++;
            }
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
            ContactPoint contact = collision.contacts[0];
            // Reflect still not working as intended, always reflects in the same direction,
            // no matter at which angle the ball collided with the wall.
            moveTo = Vector3.Reflect(transform.position, contact.normal);
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
