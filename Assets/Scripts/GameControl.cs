using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	private GameObject target;
	private UIControl UIControl;
	private TouchControl touchControl;
	private PlayerControl playerControl;
	private int score;
	private int tempScore;
	private bool isTouchDevice;
	
	void Awake() {
		if (Application.platform == RuntimePlatform.Android || 
		    Application.platform == RuntimePlatform.IPhonePlayer) {
			isTouchDevice = true;
		} else {
			isTouchDevice = false;
		}
	}

	// Use this for initialization
	void Start() {
		this.touchControl = new TouchControl(isTouchDevice);
		this.playerControl = new PlayerControl(this);
		this.target = GameObject.FindGameObjectWithTag("Target");
		this.UIControl = this.GetComponent<UIControl>();
	}
	
	// Update is called once per frame
	void Update() {
		Vector3? position = this.touchControl.GetPosition();
		bool launch = this.touchControl.GetLaucnh();
		if (position != null) {
			Vector3 direction = new Vector3(position.Value.x, 0.5F, position.Value.z);
			this.target.transform.position = direction;
		}
		if (launch) {
			this.playerControl.move(this.target.transform.position);
		}
	}

	public void AddPoint() {
		this.tempScore++;
		this.UIControl.Orbs.text = this.tempScore.ToString();
	}

	public void CommitPoints() {
		this.score += this.tempScore;
	}
}
