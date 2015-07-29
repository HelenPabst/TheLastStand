using UnityEngine;
using System.Collections;

public class NarrationLvl3 : MonoBehaviour {

	public GameObject panel1;
	public AudioClip narrationA;
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
