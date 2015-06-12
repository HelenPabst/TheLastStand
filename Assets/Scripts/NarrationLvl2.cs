using UnityEngine;
using System.Collections;

public class NarrationLvl2 : MonoBehaviour {

	public GameObject panel1;
	public AudioClip narrationA;
	public AudioSource source;
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
		source.clip = narrationA;
		source.Play();
	}

	void NextLevel()
	{
		Application.LoadLevel("Level2-Forest");
	}
	public void OnClickSkip()
	{
		NextLevel ();
	}

}
