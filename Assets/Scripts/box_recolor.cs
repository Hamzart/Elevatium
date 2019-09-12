using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class box_recolor : MonoBehaviour {

	public string btn_recolor = "none";
	public Sprite[] colors;
	GameObject[] boxlist;



	public void setCOLOR(){

		if (btn_recolor=="none"){
			btn_recolor = "red";
			GetComponent<Image> ().sprite = colors [1];

		}
		else if (btn_recolor=="red"){
			btn_recolor = "green";
			GetComponent<Image> ().sprite = colors [3];

		}
		else if (btn_recolor=="green"){
			btn_recolor = "blue";
			GetComponent<Image> ().sprite = colors [2];

		}
		else if (btn_recolor=="blue"){
			btn_recolor = "none";
			GetComponent<Image> ().sprite = colors [0];

		}

		boxlist = GameObject.FindGameObjectsWithTag("box");

		foreach(GameObject OBJ in boxlist){

			//print (OBJ.name);
			OBJ.SendMessage ("ManageBox",0,SendMessageOptions.DontRequireReceiver);
			//OBJ.GetComponent<Box> ().ManageBox ();

		}
	}
}
