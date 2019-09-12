using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_sign : MonoBehaviour {

	public string signDirection = "none";
	public Sprite[] images;
	GameObject[] boxlist;


	public void setDirection(){
		

	
		if (signDirection=="none"){
			signDirection = "left";
			GetComponent<Image> ().sprite = images [1];
			}
		else if (signDirection=="left"){
			signDirection = "right";
			GetComponent<Image> ().sprite = images [2];
		}
		else if (signDirection=="right"){
			signDirection = "back";
			GetComponent<Image> ().sprite = images [3];
		}
		else if (signDirection=="back"){
			signDirection = "none";
			GetComponent<Image> ().sprite = images [0];
		}

		//boxlist = GameObject.FindWithTag ("box");
		boxlist = GameObject.FindGameObjectsWithTag("box");

		foreach(GameObject OBJ in boxlist){

			//print (OBJ.name);
			OBJ.SendMessage ("ManageBox",0,SendMessageOptions.DontRequireReceiver);
			//OBJ.GetComponent<Box> ().ManageBox ();

		}
	}
}
