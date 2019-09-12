using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidePanel : MonoBehaviour {

	public bool ActiveOnSart = false;
	public GameObject panel;
	// Use this for initialization

	// Update is called once per frame
	public void Panel () {
		panel.GetComponent<Animator>().SetBool ("isHidden", ActiveOnSart);
		//panel.SetActive (ActiveOnSart);
		ActiveOnSart = !ActiveOnSart;
	}

	public void HideThePanel () {
		panel.GetComponent<Animator>().SetBool ("isHidden",true);
		//panel.SetActive (ActiveOnSart);
		ActiveOnSart = false;
		
}
}
