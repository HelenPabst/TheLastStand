using UnityEngine;
using System.Collections;

public class NarrationLvl3 : MonoBehaviour {

	public GameObject panel1;
	public AudioClip narrationA;
	public AudioSource source;
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
		source.clip = narrationA;
		source.Play();
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
