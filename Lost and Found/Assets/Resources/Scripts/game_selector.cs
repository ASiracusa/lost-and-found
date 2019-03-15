using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class game_selector : MonoBehaviour {

	public GameObject Screens;

	[Header("Shared Information")]
	public int numofrounds;
	public int timelimit;
	public string mapid;
	public string difficulty;

	[Header("Page Management")]
	public int pagenumber;
	public int pagemin;
	public int pagemax;
	public bool sliding;

	// Use this for initialization
	void Start () {

		mapid = "unselected";

		pagenumber = 0;
		pagemin = 0;
		pagemax = 3;

		Screens = GameObject.Find ("TV/Screens").gameObject;
		print ("it do a thing!");

		GameObject.Find ("TV/Screens/Screen1/nextbutton").GetComponent<Button> ().onClick.AddListener (screenRightBuff);
		GameObject.Find ("TV/Screens/Screen2/backbutton").GetComponent<Button> ().onClick.AddListener (screenLeftBuff);
		GameObject.Find ("TV/Screens/Screen2/nextbutton").GetComponent<Button> ().onClick.AddListener (screenRightBuff);
		GameObject.Find ("TV/Screens/Screen3/backbutton").GetComponent<Button> ().onClick.AddListener (screenLeftBuff);
		GameObject.Find ("TV/Screens/Screen3/nextbutton").GetComponent<Button> ().onClick.AddListener (screenRightBuff);
		GameObject.Find ("TV/Screens/Screen4/backbutton").GetComponent<Button> ().onClick.AddListener (screenLeftBuff);
		GameObject.Find ("TV/Screens/Screen4/startbutton").GetComponent<Button> ().onClick.AddListener (startGame);

		//GameObject.Find ("TV/Screens/Screen3/startbutton")

	}
	
	// Update is called once per frame
	void Update () {



	}

	void screenLeftBuff () {
		StartCoroutine (screenLeft());
	}
		
	IEnumerator screenLeft () {

		print (Screens.gameObject.GetComponent<RectTransform> ().transform.position);
		print (new Vector3 (-50 * (pagenumber), 0, 0));

		if (pagenumber != pagemin && !sliding) {
			pagenumber -= 1;
			Screens.GetComponent<RectTransform>().transform.localPosition = new Vector3(-50 * pagenumber, 0, 0);
		}

		yield return null;
	}

	void screenRightBuff () {
		print ("djcsdlkcmsdklc");
		StartCoroutine (screenRight());
	}

	IEnumerator screenRight () {

		print (Screens.gameObject.transform.position);
		print (new Vector3(5.4f, 2, -5 * pagenumber));

		float starttime = Time.time;

		if (pagenumber != pagemax && !sliding) {
			pagenumber += 1;
			Screens.GetComponent<RectTransform>().transform.localPosition = new Vector3(-50 * pagenumber, 0, 0);
		}

		yield return null;

	}

	void startGame () {

		string[] difficulties = { "easy", "medium", "hard", "expert" };

		numofrounds = (int)GameObject.Find ("TV/Screens/Screen1/roundslider").GetComponent<Slider> ().value;
		timelimit = (int)GameObject.Find ("TV/Screens/Screen2/timeslider").GetComponent<Slider> ().value * 30;
		difficulty = difficulties[(int)GameObject.Find ("TV/Screens/Screen4/difficultyslider").GetComponent<Slider> ().value];

	}

	void selectMap (int id) {

		string[] mapids = { "forest", "ruins", "videolab" };
		mapid = mapids [id];

	}

}
