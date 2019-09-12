using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {
	public float timeBetweenBlocks;
	public TextAsset[] xmlfile;
	public GameObject Player;
	public GameObject[] levelAssets;

	XDocument xmlDoc;
	IEnumerable<XElement> levels,worlds;

	public float playerDirection;
	public int levelNumberG,WorldNumberG;
	public string[] worldsnames;
	int posX,posy;
	bool star;
	string color;

	public List<string> destructibleObjectsTags = new List<string>{ "box", "Stairs", "Clone","Player","PlayerClone"};
	public GameObject cameraController;
	void Start ()
	{
		cameraController =  GameObject.Find ("CM vcam1");

		//StartLevel (levelNumberG,WorldNumberG);
	}

	public void StartLevel (int level, int world)
	{
		
		cameraController.SetActive (true);
		GameObject.Find ("GUI").gameObject.GetComponent<Animator> ().SetBool("isRestarted",true);
		GameObject.Find ("GUI").gameObject.GetComponent<Animator> ().SetBool("isStarting",true);
		GameObject.Find ("WhiteScreen").gameObject.GetComponent<Animator> ().SetBool ("isHidden",false);

		DestructAll ();
		LoadXML (level,world);
		
	}

	public void DestructAll()
	{


		GameObject[] mylist;

		mylist = GameObject.FindObjectsOfType<GameObject>();

		foreach(GameObject Obj in mylist)
		{
			if (Obj.activeInHierarchy)
			{
				if (destructibleObjectsTags.Contains ( Obj.tag))
				{
					Destroy (Obj);

				}
			}
		}




	}

	public void LoadXML(int levelNumber,int WorldNumber)

	{
		GameObject.Find ("WorldNumber").GetComponent<Text> ().text = worldsnames[WorldNumber-1];
		GameObject.Find ("LevelNumber").GetComponent<Text> ().text = levelNumber.ToString ();
		
		//XmlDocument xmlDoc = new XmlDocument ();
		//print (worldFiles [0].text);
		xmlDoc = XDocument.Parse (xmlfile[WorldNumber-1].text);
		//worlds = xmlDoc.Descendants ("world").Elements ();
		//worlds = xmlDoc.Descendants( "world").Elements ();
		levels = xmlDoc.Descendants( "level").Elements ();

		StartCoroutine (Buildblocks(levelNumber,WorldNumber));



		//

	}

	IEnumerator Buildblocks ( int levelNumber,int WorldNumber)
	{
        

    foreach (var item in levels)
	{
			if (item.Parent.Parent.Attribute ("number").Value == WorldNumber.ToString () & item.Parent.Attribute ("number").Value == levelNumber.ToString ()) {
				//print (item.Name + " "+ item.Attribute("color").Value);
				if (item.Name == "Box") {
					CreateBox (item.Attribute ("color").Value, item.Attribute ("posx").Value, item.Attribute ("posy").Value, item.Attribute ("star").Value);

					yield return new WaitForSeconds (timeBetweenBlocks);
				}
				else if (item.Name == "Quote")
				{
					GameObject.Find ("Quote").GetComponent<Text> ().text = item.Value;

				}

				else if (item.Name == "Staires")
				{
					CreateStaires (int.Parse(item.Attribute ("direction").Value), int.Parse (item.Attribute ("posx").Value), int.Parse (item.Attribute ("posy").Value));
				}

				else if (item.Name == "Clone")
				{
					CreateClone (int.Parse (item.Attribute ("posx").Value), int.Parse (item.Attribute ("posy").Value));

				}
			}


	}
		yield return new WaitForSeconds (1f);
		cameraController.SetActive (false);
		GameObject.Find ("WhiteScreen").gameObject.GetComponent<Animator> ().SetBool ("isHidden",true);
		yield return new WaitForSeconds (GameObject.Find ("WhiteScreen").gameObject.GetComponent<Animator> ().runtimeAnimatorController.animationClips[0].length);
		print (GameObject.Find ("WhiteScreen").gameObject.GetComponent<Animator> ().runtimeAnimatorController.animationClips[0].length);
		GameObject.Find ("GUI").gameObject.GetComponent<Animator> ().SetBool("isFinished",false);
		GameObject.Find ("GUI").gameObject.GetComponent<Animator> ().SetBool("isRestarted",false);

		GameObject.Find ("GUI").gameObject.GetComponent<Animator> ().SetBool("isStarting",true);
       
        Camera.main.GetComponent<AudioSource>().Play(0);
        Camera.main.GetComponent<AudioSource>().loop = true;



    }


	public void CreateBox(string xmlcolor, string posx ,string posy ,string star)
	{
		GameObject myBox, myplayer;
		string mycolor;
		int myX, myY;
		bool hasStar;

		if (star == "yes") {
			hasStar = true;
		} else {
			hasStar = false;
		}
		mycolor = xmlcolor;
		myX = int.Parse (posx);
		myY = int.Parse (posy);

		//print ("A " + mycolor + "[BOX] with position of " + myX + "," + myY + "and it has star = " + hasStar);
			myBox = Instantiate (levelAssets [0], new Vector3 (myX, 0, myY), Quaternion.identity);
			myBox.gameObject.GetComponent<Box> ().BoxColor = mycolor;
			myBox.gameObject.GetComponent<Box> ().ManageBox ();

			if (mycolor == "start") {
				myplayer = Instantiate (Player, new Vector3 (myX, 1, myX), Quaternion.identity);
				myplayer.transform.Rotate (0, playerDirection, 0);
			}


        //GameObject.FindGameObjectWithTag("TargetGroup").SendMessage ("FocusCamera", 0, SendMessageOptions.DontRequireReceiver);
        GameObject.Find("TargetGroup").GetComponent<lookat>().Recenter();
    }


	public void CreateStaires(int direction, int posx ,int posy)
	{
		Instantiate (levelAssets [1], new Vector3 (posx, 0, posy), new Quaternion(0,direction,0,0));


	}

	public void CreateClone(int posx ,int posy)
	{
		Instantiate (levelAssets [2], new Vector3 (posx, 0, posy), Quaternion.identity);


	}

}
