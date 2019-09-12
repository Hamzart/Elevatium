using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClone : MonoBehaviour {

	GameObject[] boxlist;

	public float yRotation = 90.0f;
	public float speed = 1.6f;
	bool colorBox = false;
	Vector3 myPos,boxPos;
	private int hight;
	List<string> colors = new List<string>{ "red", "blue", "green", "fall", "end", "clone", "rewind", "teleport" };
//	List<string> recolors = new List<string>{ "red", "blue", "green"};



	void Update () {

			transform.Translate (Vector3.forward * Time.deltaTime * speed, Space.Self);

	}


	void OnTriggerExit(Collider other)
	{
		
 			if (other.tag == "box") {
			if (other.GetComponent<Box> ().BoxColor == "fall") {
				other.GetComponent<Box> ().Fall ();
				print ("DO FALL PLZ");
			}
		}
	}


	void OnTriggerEnter(Collider other){

		if (other.tag == "box") {

			if (colors.Contains(other.GetComponent<Box>().BoxColor)){

				colorBox = true;
			}
			else 
			{
				colorBox = false;


			}
		}

		if (other.tag == "Water") {

			Destroy (this.gameObject);
		}

	}


	void OnTriggerStay(Collider other){

	

		 if (other.tag == "Clone") {


				print ("in Clone Clone");
		}

		else if (other.tag == "box") {

			if (colorBox == true) {

				myPos = transform.position;
				boxPos = other.transform.position;

				if ((Vector2.Distance (new Vector2 (myPos.x, myPos.z), new Vector2 (boxPos.x, boxPos.z))) < 0.1f) {

					transform.position = new Vector3 (boxPos.x, transform.localPosition.y, boxPos.z);

					if (other.GetComponent<Box> ().redirection == "right") {

						print ("----CLONE ROTAT RIGHT----"); 

						this.transform.Rotate (0, 90, 0, Space.Self);

					} else if (other.GetComponent<Box> ().redirection == "left") {

						print ("----CLONE ROTAT LEFT----"); 

						this.transform.Rotate (0, -90, 0, Space.Self);
					} else if (other.GetComponent<Box> ().redirection == "back") {

						print ("----CLONE REVERSE----"); 

						this.transform.Rotate (0, 180, 0, Space.Self);
					} else if (other.GetComponent<Box> ().redirection == "finish") {

						print ("----CLONE END----"); 

					} 

					else if (other.GetComponent<Box> ().redirection == "fall") {
						print ("BLOCK WILL FALL");

					}

					else {

						print ("----CLONE STOP----"); 

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
					Destroy (this.gameObject);
				}
			}

		}
	}




	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag=="Stairs") {


			if  (transform.rotation != other.transform.rotation)
			{
				Destroy (this.gameObject);

			}
		}
	}
}
