using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelSelector : MonoBehaviour {

	public Text worldtext;
	public GameObject prev,next;
	public int currentworld;
	public GameObject[] frames;
	// Use this for initialization
	void Start () {
		Refresh ("+");
	}
	
	// Update is called once per frame
	public void Refresh (string sign) {

		if(sign=="+")
		{
			currentworld++;
		}
		else{
			currentworld--;
		}
		foreach(GameObject Go in frames)
		{
			Go.GetComponent<CallLevel> ().ManageStars ();
			Go.GetComponent<CallLevel> ().world =currentworld;

		}

		if(currentworld>1)
		{
			prev.GetComponent<Button> ().interactable=true;
		}
		else
		{
			prev.GetComponent<Button> ().interactable=false;
		}
		if(currentworld<9)
		{
			next.GetComponent<Button> ().interactable=true;
		}
		else
		{
			next.GetComponent<Button> ().interactable=false;
		}

		worldtext.text = GameObject.Find ("GameManager").gameObject.GetComponent<LevelLoader> ().worldsnames [currentworld - 1];



	}
}
