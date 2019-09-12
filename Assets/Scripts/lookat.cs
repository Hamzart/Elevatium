using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour {

	//public Transform focuspoint;
	//public GameObject panel;
	Vector3 center = new Vector3(0,0,0);
	//float count = 0f;

	public GameObject[] boxes;
	
	// Use this for initialization
	void Start () {
		 
	}
	
	// Update is called once per frame
	public void Recenter () {

		boxes = GameObject.FindGameObjectsWithTag ("box");
		for(int i = 0;i< boxes.Length;i++){
		//	print (i);
			center = center + boxes[i].transform.position;
		}

		center = center / boxes.Length;
	//	print (center);

		//if (!panel.activeSelf) {
		transform.position = center;
		//}
			//else {

			//	transform.LookAt (focuspoint);
			//}
	}
}
