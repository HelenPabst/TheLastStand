using UnityEngine;
using System.Collections;

public class NarrationLvl2 : MonoBehaviour {

	public GameObject panel1;
	public AudioClip narrationA;
	public AudioSource audio;
	// Use this for initialization
	void Start () 
	{
		Invoke ("PlayClipOne",1.0f);
		Invoke ("NextLevel",30.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void PlayClipOne()
	{
		audio.clip = narrationA;
		audio.Play();
	}

	void NextLevel()
	{
		Application.LoadLevel("Level2-Forest");
	}
}
