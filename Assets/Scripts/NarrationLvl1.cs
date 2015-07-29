using UnityEngine;
using System.Collections;

public class NarrationLvl1 : MonoBehaviour {


	public GameObject panel1, panel2;
	public AudioClip introA,introB, introC;
	public AudioSource source;

	//cursor texture code
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	// Use this for initialization
	void Start () 
	{
		if (Application.isMobilePlatform) 
		{
			//keep phone from sleeping
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
			//disable mouse image 
			Cursor.visible = false;
		} 
		else
		{
			//set cursor texture
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		}
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
