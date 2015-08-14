using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	private TouchControl touchControl;
	private PlayerControl playerControl;
	private bool isTouchDevice;

	void Awake () 
	{
		if (Application.platform == RuntimePlatform.Android || 
		    Application.platform == RuntimePlatform.IPhonePlayer) {
			isTouchDevice = true;
		}
		else 
		{
			isTouchDevice = false;
		}
	}

	// Use this for initialization
	void Start () 
	{
		this.touchControl = new TouchControl(isTouchDevice);
		this.playerControl = new PlayerControl();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3? position = this.touchControl.GetPosition();
		if (position != null) 
		{
			Vector3 direction = new Vector3(position.Value.x, 0.5F, position.Value.z);
			this.playerControl.move(direction);
			print(direction);
		}
	}
}
