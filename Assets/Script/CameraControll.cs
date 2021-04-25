using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {
	private Vector3 offSet;

	public GameObject player;

	// Use this for initialization
	void Start () {
		offSet = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offSet;
		if (Input.GetKey (KeyCode.A)) {
			transform.RotateAround (player.transform.position,new Vector3(0,1,0), -3);
		} else if (Input.GetKey (KeyCode.D)) {
			transform.RotateAround (player.transform.position, new Vector3(0,1,0), 3);
		}
	}	
}
