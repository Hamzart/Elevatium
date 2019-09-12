using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {

	public string world,level;
	public GameObject Player;
	public float playerOrientation;
	public GameObject[] levelAssets;
	// Use this for initialization
	void Start () {
		LoadLevel ();
	}
	

	public void LoadLevel()
	{
		GameObject myBox,myplayer;
		for (int x=0;x<5;x++)
		{
			for (int y = 0; y < 5; y++) 
			{
				myBox = Instantiate (levelAssets [0], new Vector3 (x, 0, y), Quaternion.identity);

				if (x == 0 & y == 0) {

					myBox.gameObject.GetComponent<Box> ().BoxColor = "start";
					myBox.gameObject.GetComponent<Box> ().ManageBox ();
					myplayer = Instantiate (Player, new Vector3 (x, 1, y),Quaternion.identity);
					myplayer.transform.Rotate (0,playerOrientation,0);
				}

				if (x == 4 & y == 4) {

					myBox.gameObject.GetComponent<Box> ().BoxColor = "end";
					myBox.gameObject.GetComponent<Box> ().ManageBox ();
				}

				if (x == 0 & y == 4) {

					myBox.gameObject.GetComponent<Box> ().BoxColor = "red";
					myBox.gameObject.GetComponent<Box> ().ManageBox ();
				}

				if (x == 2 & y == 2) {

					Destroy (myBox);
				}
			}
		}
		//GameObject.FindGameObjectWithTag("TargetGroup").SendMessage ("FocusCamera", 0, SendMessageOptions.DontRequireReceiver);
        GameObject.Find("TargetGroup").GetComponent<lookat>().Recenter();
    }
}
