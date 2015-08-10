using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NarrationLvl2 : MonoBehaviour {

	public GameObject panel1;
	public AudioClip narrationA;
	public AudioSource source;

	//cursor texture code
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	public GameObject loadPanel;
	public GameObject loadIcon;

	public int currentText = 0;
	public Text text1, text2;
	//Speed at which the image fades out
	private float fadeSpeed = 1.5f;

	// Use this for initialization
	void Start () 
	{
		text1.color = Color.clear;
		text2.color = Color.clear;
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
		Invoke ("SwitchText",17.0f);
		Invoke ("OnClickSkip",30.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(loadPanel.activeSelf == true)
		{
			loadIcon.transform.Rotate (0,0,50*Time.deltaTime); //rotates 50 degrees per second around z axis
		}

		switch(currentText)
		{
		case 1:
			text1.color = Color.Lerp(text1.color, Color.black, fadeSpeed * Time.deltaTime);
			break;
		case 2:
			text1.color = Color.Lerp(text1.color, Color.clear, fadeSpeed * Time.deltaTime);
			text2.color = Color.Lerp(text2.color, Color.black, fadeSpeed * Time.deltaTime);
			
			break;
		default:
			break;
		}
	}
	void PlayClipOne()
	{
		currentText = 1;
		source.clip = narrationA;
		source.Play();
	}
	void SwitchText()
	{
		currentText = 2;
	}
	void NextLevel()
	{
		Application.LoadLevel("Level2-Forest");
	}
	public void OnClickSkip()
	{
		currentText = 0;
		text1.color = Color.clear;
		text2.color = Color.clear;
		loadPanel.SetActive(true);
		source.Stop ();
		Invoke ("NextLevel", 2.0f);
	}

}
