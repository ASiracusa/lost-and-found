using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class device_connector : MonoBehaviour {

	float screentransparency;

	public float screenwidth;
	public float screenheight;

	// Use this for initialization
	void Start () {

		screenwidth = GameObject.Find ("PlayerScreen").GetComponent<RectTransform> ().rect.width;
		screenheight = GameObject.Find ("PlayerScreen").GetComponent<RectTransform> ().rect.height;

		screentransparency = 0f;
		//player type 1=computer or seeker, player type 2 equals vr or "hide" zero is a null filler used to prevent wierd stuff
		PlayerPrefs.SetInt ("playertype", 0);
		StartCoroutine (checkForController());

	}
	
	// Update is called once per frame
	void Update () {
		
		if (PlayerPrefs.GetInt ("playertype") == 0) {
			if (Input.GetKey (KeyCode.Return)) {
				StartCoroutine (chooseComputer ());
			}
		}


	}

	void FixedUpdate () {
	}

	IEnumerator chooseComputer () {
		PlayerPrefs.SetInt ("playertype", 1);
		//GameObject.Find ("PlayerScreen/ControlSelector").SetActive (false);

		screentransparency = 0;
		while (screentransparency < 1f) {
			//makes animation more consistent
			yield return new WaitForSeconds (0.00000000000000000000000000000000000000000000000000000000000000000000005f);
			//loop var
			screentransparency += 0.04f;
			//moving and transparency
			GameObject.Find ("PlayerScreen/Computer").gameObject.transform.Translate (Time.deltaTime * 1.5f * 109.5f, 0, 0);
			//GameObject.Find ("PlayerScreen/Computer").gameObject.transform.Translate (Time.deltaTime * screenwidth / 2 * 0.5f);
			GameObject.Find ("PlayerScreen/ControlSelector").GetComponent<Image> ().color = new Color (255, 255, 255, -1 * (screentransparency * screentransparency - 1));
			GameObject.Find ("PlayerScreen/Headset").GetComponent<Image> ().color = new Color (255, 255, 255, -1 * (screentransparency * screentransparency - 1));
		}
		screentransparency = 1;
		yield return new WaitForSeconds (1.5f);
		screentransparency = 0;
		while (screentransparency < 1f) {
			yield return new WaitForSeconds (0.0000000000000000000000000000000000000000000000000000000000000000000005f);
			screentransparency += 0.04f;
			GameObject.Find ("PlayerScreen/Computer").GetComponent<Image> ().color = new Color (255, 255, 255, -1 * (screentransparency * screentransparency - 1));
			GameObject.Find ("PlayerScreen/Backdrop").GetComponent<Image> ().color = new Color (255, 255, 255, -1 * (screentransparency * screentransparency - 1));
		}
		screentransparency = 1;

		yield return null;
	}

	//checks controller types

	IEnumerator checkForController () {

		yield return new WaitForSeconds (3);

		//while (true) {
			//print(Input.GetJoystickNames ());
			/*if () {
				PlayerPrefs.SetInt ("playertype", 2);
			} else if (Input.GetKey (KeyCode.Return)) {
				PlayerPrefs.SetInt ("playertype", 1); 

			}*/
		//}

	}
}
