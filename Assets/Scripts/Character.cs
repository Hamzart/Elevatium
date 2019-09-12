using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	GameObject[] boxlist;

	public GameObject myClone;
	public float yRotation = 90.0f;
	public float speed = 1.6f;
	bool colorBox = false;
	Vector3 myPos,boxPos;
	private int hight;
	bool isWalking = false;
	List<string> colors = new List<string>{ "red", "blue", "green", "fall", "end", "clone", "rewind", "teleport" };
	//List<string> recolors = new List<string>{ "red", "blue", "green"};

	
	// Update is called once per frame
	void Update () {
			//transform.Rotate (0, GameObject.Find ("LevelBuilder").GetComponent<LevelBuilder> ().playerOrientation, 0);
		if (isWalking) {
			
			transform.Translate (Vector3.forward * Time.deltaTime * speed, Space.Self);

		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Clone") {

			Instantiate (myClone, other.transform.position, new Quaternion (0, transform.rotation.y + 180, 0, 0));
			print ("Clone");

		} 
		else if (other.tag == "box") {
			if (other.GetComponent<Box> ().BoxColor == "fall") {
				other.GetComponent<Box> ().Fall ();
				print ("DO FALL PLZ");
			}
		}
	}

	void OnTriggerEnter(Collider other){

	
		//print ("Entered a new Box");

		if (other.tag == "box") {

			//print(other.transform.position);
			//print ("mypos "+transform.position);


			if (colors.Contains(other.GetComponent<Box>().BoxColor)){

			//	print("colored Box");
				//print (other.GetComponent<Box> ().BoxColor);
				colorBox = true;
				//transform.Rotate (0, 90, 0);
			}
			else 
			{
				//print("GRAY Box");
				colorBox = false;


			}
		}



		else if(other.tag =="Water")
		{
			print ("tou are DEAD"); 
			GameObject.Find ("GameManager").SendMessage ("EndLevel",false,SendMessageOptions.DontRequireReceiver);



		}


	
	}


	void OnTriggerStay(Collider other){

	

		 

		 if (other.tag == "box") {

			if (colorBox == true) {
				//print ("COLOR BOX is " + colorBox);


				myPos = transform.position;
				boxPos = other.transform.position;
				//print ( Vector2.Distance (new Vector2 (myPos.x, myPos.z), new Vector2 (boxPos.x, boxPos.z)));




				if ((Vector2.Distance (new Vector2 (myPos.x, myPos.z), new Vector2 (boxPos.x, boxPos.z))) < 0.1f) {

					transform.position = new Vector3 (boxPos.x, transform.localPosition.y, boxPos.z);


					//	print ("DID IT");
			
					//print (other.GetComponent<Box> ().redirection);


			
					if (other.GetComponent<Box> ().redirection == "right") {

						print ("----ROTAT RIGHT----"); 

						this.transform.Rotate (0, 90, 0, Space.Self);

					} else if (other.GetComponent<Box> ().redirection == "left") {

						print ("----ROTAT LEFT----"); 

						this.transform.Rotate (0, -90, 0, Space.Self);
					} else if (other.GetComponent<Box> ().redirection == "back") {

						print ("----REVERSE----"); 

						this.transform.Rotate (0, 180, 0, Space.Self);
					} else if (other.GetComponent<Box> ().redirection == "finish") {

						print ("----END----"); 

						isWalking = false;
						GameObject.Find ("GameManager").SendMessage ("EndLevel", true, SendMessageOptions.DontRequireReceiver);


					}
						else if (other.GetComponent<Box> ().redirection == "fall") {
						print ("BLOCK WILL FALL");

					} else {

						print ("----STOP----"); 

						isWalking = false;
					}

					if (colors.Contains (other.GetComponent<Box> ().recolor)) {

						other.GetComponent<Box> ().BoxColor = other.GetComponent<Box> ().recolor;
						boxlist = GameObject.FindGameObjectsWithTag ("box");

						foreach (GameObject OBJ in boxlist) {

							//print (OBJ.name);
							OBJ.SendMessage ("ManageBox", 0, SendMessageOptions.DontRequireReceiver);
							//OBJ.GetComponent<Box> ().ManageBox ();

						}
					}

			

					colorBox = false;
				}
			}

		}
	}


	public void startWalking(){
		isWalking = true;
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag=="Stairs") {


			if  (transform.rotation != other.transform.rotation)
			{
				print ("blocked by stairs");
				isWalking = false;
				GameObject.Find ("GameManager").SendMessage ("EndLevel", true, SendMessageOptions.DontRequireReceiver);

			}
		}
	}
}
