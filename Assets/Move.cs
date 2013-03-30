using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour 
{
	float speed;
	Vector3 click;
	
	// Use this for initialization
	void Start() 
	{
		speed = 1.0F;
		click = transform.position;
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(Input.GetMouseButtonDown(0))
		{
			click = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			click = new Vector3(click.x, 1.0F, click.z);
		}
		transform.position = Vector3.Lerp(transform.position, click, speed);
	}
}
