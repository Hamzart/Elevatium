using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour {

	public GameObject character;

	private void OnMouseDown(){
	
		character.GetComponent<Character> ().startWalking ();
		print ("box cliked -------------------- YES ");
	}
}
