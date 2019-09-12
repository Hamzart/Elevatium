using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour {
	public Material[] materials;
	public string BoxColor;
	public string redirection,recolor;
	public bool isActive = true;

	
	void Awake () {
		ManageBox ();
	}

	public void ManageBox()
	{
		// OREDER    0 start /1 gray/ 2 fall/ 3 teleport/ 4 rewind/ 5  red/ 6 green/ 7 blue/ 8 purple/ 9 shadowClone 
		if (BoxColor == "red") {

			//print("recolored "+ BoxColor);
			GetComponent<Renderer>().material = materials [5];
			redirection =  GameObject.Find ("RedS").GetComponent<button_sign> ().signDirection;
			recolor = GameObject.Find ("ColorRed").GetComponent<box_recolor> ().btn_recolor;


		}


		else if (BoxColor == "green") {
			GetComponent<Renderer>().material = materials [6];

			redirection = GameObject.Find ("GreenS").GetComponent<button_sign> ().signDirection;
			recolor = GameObject.Find ("ColorGreen").GetComponent<box_recolor> ().btn_recolor;
		}

		else if (BoxColor == "blue") {
			GetComponent<Renderer>().material = materials [7];

			redirection = GameObject.Find ("BlueS").GetComponent<button_sign> ().signDirection;
			recolor = GameObject.Find ("ColorBlue").GetComponent<box_recolor> ().btn_recolor;
		}

		else if (BoxColor == "gray") {
			GetComponent<Renderer>().material = materials [1];
			redirection = "none";

		}
		else if (BoxColor == "teleport") {
			
			GetComponent<Renderer>().material = materials [3];
			redirection = "teleport";


		}
		else if (BoxColor == "clone") {
			GetComponent<Renderer>().material = materials [9];

			redirection = "clone";


		}
		else if (BoxColor == "rewind") {

			GetComponent<Renderer>().material = materials [4];

			redirection = "rewind";


		}
		else if (BoxColor == "fall") {
			GetComponent<Renderer>().material = materials [2];

			redirection = "fall";


		}

		else if (BoxColor == "end") {
			GetComponent<Renderer>().material = materials [8];


			redirection = "finish";


		}

		else if (BoxColor == "start") {
			GetComponent<Renderer>().material = materials [0];

			redirection = "start";


		}



	}

	public void Fall()
	{
			
		if(isActive)
		StartCoroutine (FallBlock (transform.position,transform.position+ new Vector3(0,-1,0),1f));
	}

	public IEnumerator FallBlock(Vector3 position,Vector3 endPosition,float duration)
	{	
		Transform shadow = transform.GetChild (0);

		float timeRemainign = duration;
		while (timeRemainign > 0) {
			timeRemainign -= Time.deltaTime;
			transform.position = Vector3.Lerp (position, endPosition, Mathf.InverseLerp (duration, 0, timeRemainign));
			shadow.transform.position = new Vector3 (transform.position.x, -1.9f, transform.position.z);

			yield return null;
		}
		transform.position = endPosition;
		isActive = false;
		}
		
}
