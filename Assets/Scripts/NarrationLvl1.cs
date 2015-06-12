using UnityEngine;
using System.Collections;

public class NarrationLvl1 : MonoBehaviour {


	public GameObject panel1, panel2;
	public AudioClip introA,introB, introC;
	public AudioSource source;
	// Use this for initialization
	void Start () 
	{
		Invoke ("PlayClipOne",1.0f);
		Invoke ("PlayClipTwo",20.0f);
		Invoke ("PlayClipThree",45.0f);
		Invoke ("NextLevel",69.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	void PlayClipOne()
	{
		source.clip = introA;
		source.Play();
	}
	void PlayClipTwo()
	{
		panel1.SetActive (false);
		panel2.SetActive (true);
		source.clip = introB;
		source.Play();
	}
	void PlayClipThree()
	{
		source.clip = introC;
		source.Play();
	}
	void NextLevel()
	{
		Application.LoadLevel("Level1-Village");
	}
	public void OnClickSkip()
	{
		NextLevel ();
	}
}
