using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallLevel : MonoBehaviour {

	public int stars;
	public Transform star1,star2,star3;
	public int level, world;
	public GameObject Manager;
	// Use this for initialization
	void Start () {

		star1 = transform.Find ("star1");
		star2 = transform.Find ("star2");
		star3 = transform.Find ("star3");

	}
	
	// Update is called once per frame
	public void StartLevel () {

        Manager.GetComponent<GameManager>().level = level;
        Manager.GetComponent<GameManager>().world = world;
        Manager.GetComponent<LevelLoader> ().StartLevel (level,world);
        GameObject.Find("LevelSelect").SetActive(false);

    }
	public void ManageStars()
	{
		
	}
}
