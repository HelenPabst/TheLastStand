using UnityEngine;
using System.Collections;

public class NarrationLvl3 : MonoBehaviour {

	public GameObject panel1;
	public AudioClip narrationA;
	public AudioSource audio;
	// Use this for initialization
	void Start () 
	{
		Invoke ("PlayClipOne",1.0f);
		Invoke ("NextLevel",35.0f);
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
		Application.LoadLevel("Level3-Temple");
	}
	public void OnClickSkip()
	{
		NextLevel ();
	}
}
