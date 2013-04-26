using UnityEngine;
using System.Collections;

public class PlayerSphereScript : MonoBehaviour
{
	int collected;
	float speed;
	Vector3 moveTo;
	
	// Use this for initialization
	void Start() 
	{
		collected = 0;
		speed = 0.6F;
		moveTo = transform.position;
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(Input.GetMouseButtonDown(0))
		{
            Vector3 mouse = Input.mousePosition;
            mouse.z = 32; 
			moveTo = Camera.main.ScreenToWorldPoint(mouse);
			moveTo = new Vector3(moveTo.x, 1.0f, moveTo.z);
		}
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
			
		}
		else if(collision.gameObject.tag.Equals("OrbOfLight"))
		{
			collected++;
			Destroy(collision.gameObject);
		}
    }
}
