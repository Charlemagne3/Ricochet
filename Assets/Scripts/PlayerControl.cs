using UnityEngine;
using System.Collections;

public class PlayerControl
{
	private GameObject sphere;

	public PlayerControl() 
	{
		this.sphere = GameObject.FindGameObjectWithTag("Player");
	}

	public void move(Vector3 position) 
	{
		this.sphere.GetComponent<Rigidbody>().AddRelativeForce((position - this.sphere.transform.position) * 10);
	}
}