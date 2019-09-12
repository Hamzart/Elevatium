using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public string levelname;
    public int level, world;
	public AudioClip[] myAudio;
	// Use this for initialization
	void Start () {
	levelname = SceneManager.GetActiveScene ().name;
        Camera.main.GetComponent<AudioSource>().clip = myAudio[0];
        level = GetComponent<LevelLoader>().levelNumberG;
        world = GetComponent<LevelLoader>().WorldNumberG;
    }


	public void Startwalking()
	{
		
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Character> ().startWalking ();

	}

	public void RestartLevel()
	{
        //SceneManager.LoadScene (levelname);
        GetComponent<LevelLoader>().StartLevel(level, world);
        print(level + "~~~~~~~~~~~~" + world);
	}


	public void EndLevel (bool isWin)
	{
		GameObject.Find ("GUI").gameObject.GetComponent<Animator> ().SetBool("isFinished",true);
		GameObject.Find ("GUI").gameObject.GetComponent<Animator> ().SetBool("isStarting",false);



		if (isWin)
		{
		Camera.main.GetComponent<AudioSource> ().clip = myAudio [1];
		Camera.main.GetComponent<AudioSource> ().Play(0);
		Camera.main.GetComponent<AudioSource> ().loop = false;
		
		
		}
		else
		{
			Camera.main.GetComponent<AudioSource> ().clip = myAudio [2];
			Camera.main.GetComponent<AudioSource> ().Play(0);
			Camera.main.GetComponent<AudioSource> ().loop = false;
			
		}
	}

}
