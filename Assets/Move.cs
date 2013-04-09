using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
	float speed;
	float dist;
	Vector3 click;
	
	// Use this for initialization
	void Start() 
	{
		speed = 0.05F;
		click = transform.position;
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(Input.GetMouseButtonDown(0))
		{
            Vector3 mouse = Input.mousePosition;
            mouse.z = 32; 
			click = Camera.main.ScreenToWorldPoint(mouse);
			click = new Vector3(click.x, 1.0f, click.z);
		}
        transform.position = Vector3.Lerp(transform.position, click, speed);
	}
}
