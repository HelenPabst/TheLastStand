using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TempEnding : MonoBehaviour {

	public GameObject cutscene;
	public GameObject[] fires = new GameObject[3];
	public int fireIndex = 0;
	public float speed = -18;
	public string level;
	public float runTime;
	public float scrollEnd;
	public AudioSource audioSource;

	//cursor texture code
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	//a black image used for fading to black
	public Image fadeImage;
	//Speed at which the image fades out
	private float fadeSpeed = 1.5f;


	// Use this for initialization
	void Start () 
	{
		//fadeImage = gameObject.GetComponent<Image>();
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
		Invoke("FadeOutMusic", 26.0f);
		Invoke("Ignite", 9.0f);
		Invoke("Ignite", 14.0f);
		Invoke("Ignite", 21.0f);
		InvokeRepeating("FadeToBlack", 23.0f, 0.05f);
		InvokeRepeating("cutsceneTime", 0, 1);

	}
	
	// Update is called once per frame
	void Update () {
		///runtime decrements, when it reaches the scrollend value the image stops moving
		/// when it reaches 0, the level jumps to credits
		if (runTime > scrollEnd) 
		{
			cutscene.gameObject.transform.Translate (Vector3.down * Time.deltaTime * speed);
		}
		if (runTime <= 0) 
		{
			Application.LoadLevel (level);
		}


		//Application.LoadLevel ("Credits");
	}
	void cutsceneTime()
	{
		runTime -= 1;
	}
	void Ignite()
	{
		GameObject currentFire = fires[fireIndex];
		currentFire.SetActive (true);
		fireIndex++;
	}
	void FadeToBlack()
	{
		fadeImage.color = Color.Lerp(fadeImage.color, Color.black, fadeSpeed * Time.deltaTime);
		if(fadeImage.color.a >= 0.97f)
		{
			fadeImage.color = Color.black;
			//Application.LoadLevel(nextScene);
		}
	}
	public void FadeOutMusic()
	{
		StartCoroutine(FadeMusic());
	}
	IEnumerator FadeMusic()
	{
		while(audioSource.volume > .1F)
		{
			audioSource.volume = Mathf.Lerp(audioSource.volume,0F,0.2f*Time.deltaTime);
			yield return 0;
		}
		audioSource.volume = 0;

	}
}
