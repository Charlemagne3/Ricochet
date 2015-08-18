using UnityEngine;
using System.Collections;

public class PlayerControl {

	private GameObject sphere;
	private GameControl control;

	public PlayerControl(GameControl control) {
		this.control = control;
		this.sphere = GameObject.FindGameObjectWithTag("Player");
		this.sphere.GetComponent<PlayerSphere>().SetPlayerControl(this);
	}

	public void move(Vector3 position) {
		if (this.sphere.GetComponent<Rigidbody>().velocity == Vector3.zero) {
			this.sphere.GetComponent<Rigidbody>().AddRelativeForce(Vector3.ClampMagnitude((position - this.sphere.transform.position) * 1000000, 1000));
		}
	}

	public void AddPoint() {
		this.control.AddPoint();
	}
}
