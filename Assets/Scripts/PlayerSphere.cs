using UnityEngine;
using System.Collections;

public class PlayerSphere : MonoBehaviour {

	private PlayerControl control;

	public void SetPlayerControl(PlayerControl control)	{
		this.control = control;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.gameObject.tag == "ExteriorWall") {
			this.GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Orb") {
			Destroy(collider.gameObject);
			this.control.AddPoint();
		}
	}
}
