using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NarrationLvl1 : MonoBehaviour {


	//public GameObject panel1, panel2;
	public AudioClip introA,introB, introC;
	public AudioSource source;

	//cursor texture code
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	public GameObject loadPanel;
	public GameObject loadIcon;

	public int currentText = 0;
	public Text text1,text2,text3;
	public Button skipButton;
	public Text skipText;
	Color skipDefaultColor;
	//Speed at which the image fades out
	private float fadeSpeed = 1.5f;

	// Use this for initialization
	void Start () 
	{

		//make all text invisible at start
		text1.color = Color.clear;
		text2.color = Color.clear;
		text3.color = Color.clear;
		skipDefaultColor = skipButton.image.color;
		skipButton.image.color = Color.clear;
		skipText.color = Color.clear;
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
		Invoke ("OnClickSkip",69.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(loadPanel.activeSelf == true)
		{
			loadIcon.transform.Rotate (0,0,50*Time.deltaTime); //rotates 50 degrees per second around z axis
		}

		//text fading
		switch(currentText)
		{
		case 1:
			text1.color = Color.Lerp(text1.color, Color.black, fadeSpeed * Time.deltaTime);
			skipButton.image.color = Color.Lerp(skipButton.image.color, skipDefaultColor, fadeSpeed * Time.deltaTime);
			skipText.color = Color.Lerp(text1.color, Color.black, fadeSpeed * Time.deltaTime);
			break;
		case 2:
			text1.color = Color.Lerp(text1.color, Color.clear, fadeSpeed * Time.deltaTime);
			text2.color = Color.Lerp(text2.color, Color.black, fadeSpeed * Time.deltaTime);

			break;
		case 3:
			text2.color = Color.Lerp(text2.color, Color.clear, fadeSpeed * Time.deltaTime);
			text3.color = Color.Lerp(text3.color, Color.black, fadeSpeed * Time.deltaTime);
			break;
		default:
			break;
		}

		
	}
	void PlayClipOne()
	{
		currentText = 1;
		//FadeTextIn ();
		source.clip = introA;
		source.Play();
	}
	void PlayClipTwo()
	{
		currentText = 2;
		source.clip = introB;
		source.Play();
	}
	void PlayClipThree()
	{
		currentText = 3;
		source.clip = introC;
		source.Play();
	}
	void NextLevel()
	{
		Application.LoadLevel("Level1-Village");
	}
	public void OnClickSkip()
	{
		currentText = 0;
		text1.color = Color.clear;
		text2.color = Color.clear;
		text3.color = Color.clear;
		loadPanel.SetActive(true);
		source.Stop ();
		Invoke ("NextLevel", 2.0f);

	}


}
