using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditsText : MonoBehaviour {
	

	public int speed = -18;
	public string level;
	public float runTime;
	public AudioSource audioSource;

	//cursor texture code
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	//a black image used for fading to black
	public Image fadeImage;
	//Speed at which the image fades out
	private float fadeSpeed = 1.0f;

	void Start()
	{
		//float screenHeightInInch =  Screen.height / Screen.dpi;
		//audioSource = Camera.main.transform.Find("Main Camera").GetComponent<AudioSource>();
		if(Application.isMobilePlatform )
		{
			//if(screenHeightInInch < 3.1)
			//{
				//keep phone from sleeping
				Screen.sleepTimeout = SleepTimeout.NeverSleep;
				//disable mouse image 
				Cursor.visible = false;
				//on mobile, reposition credit text
				//this.transform.position = this.transform.position + new Vector3(-100,0,0);
				//double its size
				//this.transform.localScale = this.transform.localScale *2;
				//speed it up to accomodate size change
				speed = speed * 2;
			//}
            /*
			else//for tablets
			{
				//keep phone from sleeping
				Screen.sleepTimeout = SleepTimeout.NeverSleep;
				//disable mouse image 
				Cursor.visible = false;
				//on mobile, reposition credit text
				this.transform.position = this.transform.position + new Vector3(50,0,0);
				//double its size
				//this.transform.localScale = this.transform.localScale *2;
				//speed it up to accomodate size change
				//speed = speed * 2;
			}*/
		}
		else
		{
			//set cursor texture

			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);

		}
		InvokeRepeating("creditTime", 0, 1);
		Invoke("creditMusic", 1.0f);
	}
	void Update () {
		//fade black out
		fadeImage.color = Color.Lerp(fadeImage.color, Color.clear, fadeSpeed * Time.deltaTime);
		//move text object
		this.transform.Translate (Vector3.up * Time.deltaTime * speed);
		if (runTime <= 0) 
		{
			Application.LoadLevel (level);
		}
		
	}
	
	void creditTime()
	{
		runTime -= 1;

		
	}
	void creditMusic()
	{
		audioSource.Play();
	}

	
	
}