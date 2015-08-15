using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TouchControl {	
	private bool isTouchDevice;
	
	public TouchControl (bool isTouchDevice) {	
		this.isTouchDevice = isTouchDevice;
	}
	
	// Update is called once per frame
	public Vector3? GetPosition()
	{
		Vector3? vec3 = null;
		if (isTouchDevice)
        {
			vec3 = Input.touches.FirstOrDefault().position;
        }
        else if (Input.GetMouseButton(0))
        {
			vec3 = Input.mousePosition;
        }
		if (vec3 != null) 
		{
			Vector3 touch = (Vector3)vec3;
			// Get the world point for the touch
			vec3 = Camera.main.ScreenToWorldPoint(new Vector3 (touch.x, touch.y, 100));
		} 
		return vec3;
	}

	public bool GetLaucnh() {
		return Input.GetMouseButton(1);
	}
}