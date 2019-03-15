using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {

	public GameObject p;
	public int playertype;

	[Header("PLAYERC Values")]
	//movement controls for player type 1
	public KeyCode buttonup;
	public KeyCode buttondown;
	public KeyCode buttonleft;
	public KeyCode buttonright;

	public float limithigh;
	public float limitlow;

	// Use this for initialization
	void Start () {
		p = this.gameObject;
		playertype = PlayerPrefs.GetInt ("playertype");

	}
	
	// Update is called once per frame
	void Update () {

		if (playertype == 1) {
			seekerMovement ();
		}

	}

	private void seekerMovement () {

		if (Input.GetKey (buttonup)) {
			p.transform.position = new Vector3 (p.transform.position.x, p.transform.position.y, p.transform.position.z + 0.05f);
		}
		if (Input.GetKey (buttondown)) {
			p.transform.position = new Vector3 (p.transform.position.x, p.transform.position.y, p.transform.position.z - 0.05f);
		}
		if (Input.GetKey (buttonleft)) {
			p.transform.position = new Vector3 (p.transform.position.x - 0.05f, p.transform.position.y, p.transform.position.z);
		}
		if (Input.GetKey (buttonright)) {
			p.transform.position = new Vector3 (p.transform.position.x + 0.05f, p.transform.position.y, p.transform.position.z);
		}

		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			p.transform.position = new Vector3 (p.transform.position.x, p.transform.position.y - 0.5f, p.transform.position.z);
		} else if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			p.transform.position = new Vector3 (p.transform.position.x, p.transform.position.y + 0.5f, p.transform.position.z);
		}

	}

}