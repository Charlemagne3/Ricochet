using UnityEngine;
using System.Collections;

public class PlayerSphereScript : MonoBehaviour
{
	private int collected;
    private int moves;
	private float speed;
	private Vector3 moveTo;
    private Vector3 previousPosition; // Variable to keep track of the playerSphere's previous position
	
	public int Collected 
	{
		get { return this.collected; }
		set { this.collected = value; }
	}
	
	// Use this for initialization
	public void Start() 
	{
		this.collected = 0;
		this.speed = 0.6F;
		this.rigidbody.constraints = RigidbodyConstraints.FreezePositionY; // to stop the y from changing
		this.moveTo = base.transform.position;
        this.previousPosition = this.moveTo;
	}
	
	// Update is called once per frame
	public void Update() 
	{
        // If the mouse button is down, and the playerSphere has not moved since last update,
        if (Input.GetMouseButtonDown(0) && base.transform.position == this.previousPosition)
		{
            RaycastHit hit;
            // Create a ray going towards the mouse's location
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // If the raycast of the ray collides with something (currently always collides with ground),
            // move to the collision point's x and z coordinates and increment moves.
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                this.moveTo = new Vector3(hit.point.x, 1.0f, hit.point.z);
                this.moves++;
            }
		}
        this.previousPosition = transform.position;
        base.transform.position = Vector3.MoveTowards(base.transform.position, this.moveTo, this.speed);
	}
	
	public void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.tag.Equals("ExteriorWall"))
	    {
            this.moveTo = base.transform.position;
		}
		else if (collision.gameObject.tag.Equals("InteriorWall"))
		{
            ContactPoint contact = collision.contacts[0];
            // Reflect still not working as intended, always reflects in the same direction,
            // no matter at which angle the ball collided with the wall.
            this.moveTo = Vector3.Reflect(base.transform.position, contact.normal);
            this.moveTo = new Vector3(this.moveTo.x, 1.0f, this.moveTo.z); // set y to 1
		}
		else if (collision.gameObject.tag.Equals("OrbOfLight"))
		{
			this.collected++;
			base.Destroy(collision.gameObject);
		}
    }

	// Used by the HUD to display how many moves have been made.
	public int Moves()
	{
		return this.moves;	
	}
}
